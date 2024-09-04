using MF2024API.Interfaces;
using MF2024API.Service;
using MF2024API_2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MF2024API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signinManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserService _userService;
        private DateTime DateTime;

        public UserController(UserManager<User> userManager, ITokenService tokenService, SignInManager<User> signinManager, RoleManager<IdentityRole> roleManager, UserService userService)
        {
            _userManager = userManager;
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _signinManager = signinManager;
            _roleManager = roleManager;
            _userService = userService;
        }




        [HttpPost]
        [Route("Register")]
        //[Authorize]
        public async Task<IActionResult> Register([FromBody] postUser model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var user = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    UserSlackId = model.Slak_ID,
                    UserSlackUrl = model.Slak_URL,
                    UserNameKana = model.UserNameKana,
                    UserDateOfEntry = DateTime.Now,
                    UserGender = model.UserGender,
                    UserPasswoedUpdataTime = DateTime.Now,
                    UserAddress = model.UserAddress,
                    UserUpdataDate = DateTime.Now,
                    UserUpdataUser = model.UserUpdataUserId,
                    UserIndustry = model.UserIndustry




                };
                var createUser = await _userManager.CreateAsync(user, model.Password);
                if (createUser.Succeeded)
                {
                    var role = await _userManager.AddToRoleAsync(user, model.Role);
                    if (role.Succeeded)
                    {
                        List<string> roles = new List<string>() { model.Role };
                        return Ok
                            ( _tokenService.CreateToken(user, roles)

                            //new returnUser
                            //{
                            //    Id = user.Id,
                            //    UserName = user.UserName,
                            //    Email = user.Email,
                            //    Token = _tokenService.CreateToken(user, roles),
                            //    Role = roles
                            //}
                            );
                    }
                    else
                    {
                        var delete = await _userManager.DeleteAsync(user);
                        return StatusCode(500, role.Errors);
                    }
                }
                else
                {
                    var delete = await _userManager.DeleteAsync(user);
                    return StatusCode(500, createUser.Errors);
                }
            }
            catch (Exception e)
            {
                var delete = await _userManager.FindByNameAsync(model.UserName);
                if (delete != null)
                {
                    var deleteuser = await _userManager.DeleteAsync(delete);
                }
                return StatusCode(500, e);
            }
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUser model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName.ToLower());


                if (user == null) return Unauthorized("Invalid username!");

                var userid = await _userManager.GetUserIdAsync(user);
                if (userid == null) return Unauthorized("Invalid userid!");

                var role = await _userService.GetUserRolesAsync(userid);


                var result = await _signinManager.CheckPasswordSignInAsync(user, model.Password, false);

                if (!result.Succeeded) return Unauthorized("Username not found and/or password incorrect");

                return Ok(
                    _tokenService.CreateToken(user, role)
                //new returnUser
                //{
                //    Id = user.Id,
                //    UserName = user.UserName,
                //    Email = user.Email,
                //    Token = _tokenService.CreateToken(user, role),
                //    Role = role
                //}
                );
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return Ok("Logged out");
        }
    }
    public class postUser
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserNameKana { get; set; }
        [Required]
        public string UserGender { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Slak_ID { get; set; }
        public string Slak_URL { get; set; }
        [Required]
        public string Role { get; set; }

        public string UserAddress { get; set; }
        [Required]
        public string UserUpdataUserId { get; set; }

        public string UserIndustry { get; set; }


    }


    public class returnUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string UserNameKana { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public IList<string> Role { get; set; }
    }

    public class LoginUser
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

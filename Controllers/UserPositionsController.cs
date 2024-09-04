using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MF2024API_2.Models;

namespace MF2024API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPositionsController : ControllerBase
    {
        private readonly Mf2024api2Context _context;

        public UserPositionsController(Mf2024api2Context context)
        {
            _context = context;
        }

        // GET: api/UserPositions
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<UserPosition>>> GetUserPositions()
        //{
        //    return await _context.UserPositions.ToListAsync();
        //}

        // GET: api/UserPositions/5
        [HttpGet]
        public async Task<ActionResult<UserPosition>> GetUserPosition([FromQuery] GetUserPosition userPosition)
        {
            try 
            {
                var query = _context.UserPositions.AsQueryable();

                if (!string.IsNullOrEmpty(userPosition.UserId))
                {
                    query = query.Where(c => c.UserId == userPosition.UserId);
                }
                if (userPosition.SectionId.HasValue)
                {
                    query = query.Where(c => c.SectionId == userPosition.SectionId);
                }
                if (!string.IsNullOrEmpty(userPosition.RoleId))
                {
                    query = query.Where(c => c.RoleId.Contains(userPosition.RoleId));
                }

                var result = await query.ToListAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/UserPositions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutUserPosition( PutUserPosition putuserPosition)
        {
            var userPosition = await _context.UserPositions.FindAsync(putuserPosition.UserId);
            if (userPosition == null)
            {
                return NotFound();
            }
            if (putuserPosition.SectionId.HasValue)
            {
                userPosition.SectionId = putuserPosition.SectionId.Value;
            }
            if (!string.IsNullOrEmpty(putuserPosition.RoleId))
            {
                userPosition.RoleId = putuserPosition.RoleId;
            }
            userPosition.UserPositionUpdateUser = putuserPosition.UserPositionUpdateUser;


            _context.Entry(userPosition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(userPosition);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPositionExists(userPosition.UserId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserPositions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserPosition>> PostUserPosition(PostUserPosition userPosition)
        {
            try 
            {
                var userPositions = new UserPosition
                {
                    UserId = userPosition.UserId,
                    SectionId = userPosition.SectionId,
                    RoleId = userPosition.RoleId,
                    UserPositionUpdateUser = userPosition.UpdateUser,
                };
                _context.UserPositions.Add(userPositions);
                await _context.SaveChangesAsync();

                return Ok(userPositions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/UserPositions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserPosition(string id)
        {
            var userPosition = await _context.UserPositions.FindAsync(id);
            if (userPosition == null)
            {
                return NotFound();
            }

            _context.UserPositions.Remove(userPosition);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserPositionExists(string id)
        {
            return _context.UserPositions.Any(e => e.UserId == id);
        }
    }
    public class PostUserPosition
    {
        public string UserId { get; set; }

        public int SectionId { get; set; }

        public string RoleId { get; set; }

        public string UpdateUser { get; set; }
    }

    public class PutUserPosition
    {
        public string UserId { get; set; }

        public int? SectionId { get; set; }

        public string? RoleId { get; set; }

        public string UserPositionUpdateUser { get; set; }
    }

    public class GetUserPosition
    {
        public string? UserId { get; set; }

        public int? SectionId { get; set; }

        public string? RoleId { get; set; }
    }
}

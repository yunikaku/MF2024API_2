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
    public class CompaniesController : ControllerBase
    {
        private readonly Mf2024api2Context _context;

        public CompaniesController(Mf2024api2Context context)
        {
            _context = context;
        }

        // GET: api/Companies
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        //{
        //    return await _context.Companies.ToListAsync();
        //}

        // GET: api/Companies/5
        [HttpGet]
        public async Task<ActionResult<Company>> GetCompany([FromQuery]GetCompany company)
        {
            try 
            {
                var query = _context.Companies.AsQueryable();

                if (company.Id.HasValue)
                {
                    query = query.Where(c => c.CompanyId == company.Id);
                }
                if (!string.IsNullOrEmpty(company.CompanyName))
                {
                    query = query.Where(c => c.CompanyName.Contains(company.CompanyName));
                }
                var result = await query.ToListAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutCompany(PutCompany putcompany)
        {
            var company = await _context.Companies.FindAsync(putcompany.Id);
            if (company == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(putcompany.UserName))
            {
                company.UserName = putcompany.UserName;
            }
            if (!string.IsNullOrEmpty(putcompany.UserPosition))
            {
                company.UserPosition = putcompany.UserPosition;
            }
            if (!string.IsNullOrEmpty(putcompany.CompanyName))
            {
                company.CompanyName = putcompany.CompanyName;
            }
            if (!string.IsNullOrEmpty(putcompany.CompanySlakId))
            {
                company.CompanySlakId = putcompany.CompanySlakId;
            }
            company.UpdateUser = putcompany.UpdateUserId;

            _context.Entry(company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(company);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(putcompany.Id))
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

        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(PostCompany company)
        {
            try
            {
                var newCompany = new Company
                {
                    UserName = company.UserName,
                    UserPosition = company.UserPosition,
                    CompanyName = company.CompanyName,
                    CompanySlakId = company.CompanySlakId,
                    StandardWorkingHours = company.StandardWorkingHours,
                    DateOfGrantWithPay = company.DateOfGrantWithPay,
                    FirstDayOfTheCalendarYear = company.FirstDayOfTheCalendarYear,
                    UpdateTime = company.UpdateTime,
                    UpdateUser = company.UpdateUser,
                };

                _context.Companies.Add(newCompany);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCompany", new { id = newCompany.CompanyId }, newCompany);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.CompanyId == id);
        }
    }
    public class PostCompany
    {
        public string UserName { get; set; } = null!;

        public string UserPosition { get; set; } = null!;

        public string CompanyName { get; set; } = null!;

        public string CompanySlakId { get; set; } = null!;

        public int StandardWorkingHours { get; set; }

        public DateTime DateOfGrantWithPay { get; set; }

        public DateTime FirstDayOfTheCalendarYear { get; set; }

        public DateTime UpdateTime { get; set; }

        public string UpdateUser { get; set; } = null!;
    }

    public class PutCompany
    {
        public int Id { get; set; }

        public string UpdateUserId { get; set; }

        public string? UserName { get; set; }

        public string? UserPosition { get; set; }

        public string? CompanyName { get; set; }

        public string? CompanySlakId { get; set; }
    }

    public class GetCompany
    {
        public int? Id { get; set; }

        public string? CompanyName { get; set; } = null!;
    }
}

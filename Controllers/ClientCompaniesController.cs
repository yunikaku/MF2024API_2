using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MF2024API_2.Models;
using Microsoft.IdentityModel.Tokens;

namespace MF2024API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientCompaniesController : ControllerBase
    {
        private readonly Mf2024api2Context _context;

        public ClientCompaniesController(Mf2024api2Context context)
        {
            _context = context;
        }

        // GET: api/ClientCompanies
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ClientCompany>>> GetClientCompanies()
        //{
        //    return await _context.ClientCompanies.ToListAsync();
        //}

        // GET: api/ClientCompanies/5
        [HttpGet]
        public async Task<ActionResult<ClientCompany>> GetClientCompany([FromQuery] GetClientCompany company)
        {
            var query = _context.ClientCompanies.AsQueryable();

            if (company.ClientCompanyId.HasValue) 
            {
                query = query.Where(c => c.ClientCompanyId == company.ClientCompanyId);
            }
            if (!string.IsNullOrEmpty(company.ClientCompanyName))
            {
                query = query.Where(c => c.ClientCompanyName.Contains(company.ClientCompanyName));
            }
            var result = await query.ToListAsync();
            return Ok(result);
        }

        // PUT: api/ClientCompanies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutClientCompany(PutClientCompany clientCompany)
        {



            var clientCompanyToUpdate = await _context.ClientCompanies.FindAsync(clientCompany.ClientCompanyId);
            if (clientCompanyToUpdate == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(clientCompany.ClientCompanyName))
            {
                clientCompanyToUpdate.ClientCompanyName = clientCompany.ClientCompanyName;
            }
            if (!string.IsNullOrEmpty(clientCompany.ClientCompanyEmail))
            {
                clientCompanyToUpdate.ClientCompanyEmail = clientCompany.ClientCompanyEmail;
            }

            if (!string.IsNullOrEmpty(clientCompany.ClientCompanyPhoneNumber))
            {
                clientCompanyToUpdate.ClientCompanyPhoneNumber = clientCompany.ClientCompanyPhoneNumber;
            }

            if (!string.IsNullOrEmpty(clientCompany.ClientCompanyAddress))
            {
                clientCompanyToUpdate.ClientCompanyAddress = clientCompany.ClientCompanyAddress;
            }
            _context.Entry(clientCompanyToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(clientCompanyToUpdate);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientCompanyExists(clientCompany.ClientCompanyId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/ClientCompanies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientCompany>> PostClientCompany(PostClientCompany clientCompany)
        {
            try 
            {
                var newClientCompany = new ClientCompany
                {
                    ClientCompanyName = clientCompany.ClientCompanyName,
                    ClientCompanyEmail = clientCompany.ClientCompanyEmail,
                    ClientCompanyPhoneNumber = clientCompany.ClientCompanyPhoneNumber,
                    ClientCompanyAddress = clientCompany.ClientCompanyAddress,
                };
                _context.ClientCompanies.Add(newClientCompany);
                await _context.SaveChangesAsync();
                return Ok(newClientCompany);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/ClientCompanies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientCompany(int id)
        {
            var clientCompany = await _context.ClientCompanies.FindAsync(id);
            if (clientCompany == null)
            {
                return NotFound();
            }

            _context.ClientCompanies.Remove(clientCompany);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientCompanyExists(int id)
        {
            return _context.ClientCompanies.Any(e => e.ClientCompanyId == id);
        }
    }

    public class PostClientCompany
    {
        public string ClientCompanyName { get; set; }

        public string ClientCompanyEmail { get; set; }

        public string ClientCompanyPhoneNumber { get; set; }

        public string ClientCompanyAddress { get; set; }
    }

    public class PutClientCompany
    {
        public int ClientCompanyId { get; set; }

        public string? ClientCompanyName { get; set; }

        public string? ClientCompanyEmail { get; set; }

        public string? ClientCompanyPhoneNumber { get; set; }

        public string? ClientCompanyAddress { get; set; }
    }

    public class GetClientCompany
    {
        public int? ClientCompanyId { get; set; }

        public string? ClientCompanyName { get; set; }

    }
}

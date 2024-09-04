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
    public class ClientCompanyEmployeesController : ControllerBase
    {
        private readonly Mf2024api2Context _context;

        public ClientCompanyEmployeesController(Mf2024api2Context context)
        {
            _context = context;
        }

        // GET: api/ClientCompanyEmployees
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ClientCompanyEmployee>>> GetClientCompanyEmployees()
        //{
        //    return await _context.ClientCompanyEmployees.ToListAsync();
        //}

        // GET: api/ClientCompanyEmployees/5
        [HttpGet]
        public async Task<ActionResult<ClientCompanyEmployee>> GetClientCompanyEmployee([FromQuery]GetClientCompanyEmployee companyEmployee)
        {
            try 
            {
                var query = _context.ClientCompanyEmployees.AsQueryable();

                if (companyEmployee.ClientCompanyEmployeeId.HasValue)
                {
                    query = query.Where(c => c.ClientCompanyEmployeesId == companyEmployee.ClientCompanyEmployeeId);
                }
                if (!string.IsNullOrEmpty(companyEmployee.ClientCompanyEmployeeName))
                {
                    query = query.Where(c => c.ClientCompanyEmployeesName.Contains(companyEmployee.ClientCompanyEmployeeName));
                }
                if (!string.IsNullOrEmpty(companyEmployee.ClientCompanyEmployeeNameKana))
                {
                    query = query.Where(c => c.ClientCompanyEmployeesNameKana.Contains(companyEmployee.ClientCompanyEmployeeNameKana));
                }
                if (companyEmployee.ClientCompanyId.HasValue)
                {
                    query = query.Where(c => c.ClientCompanyId == companyEmployee.ClientCompanyId);
                }
                if (!string.IsNullOrEmpty(companyEmployee.ClientCompanyEmployeeSection))
                {
                    query = query.Where(c => c.ClientCompanyEmployeesSection.Contains(companyEmployee.ClientCompanyEmployeeSection));
                }
                if (!string.IsNullOrEmpty(companyEmployee.ClientCompanyEmployeePosition))
                {
                    query = query.Where(c => c.ClientCompanyEmployeesPosition.Contains(companyEmployee.ClientCompanyEmployeePosition));
                }
                var result = await query.Include(e=>e.ClientCompany).ToListAsync();
                List<returnClientCompanyEmployee> returnClientCompanyEmployees = new List<returnClientCompanyEmployee>();

                if (result != null)
                {
                    foreach (var item in result)
                    {
                        returnClientCompanyEmployee clientCompanyEmployee = new returnClientCompanyEmployee
                        {
                            ClientCompanyEmployeesId = item.ClientCompanyEmployeesId,
                            ClientCompanyId = (int)item.ClientCompanyId,
                            ClientCompanyName = item.ClientCompany.ClientCompanyName,
                            ClientCompanyEmployeesName = item.ClientCompanyEmployeesName,
                            ClientCompanyEmployeesNameKana = item.ClientCompanyEmployeesNameKana,
                            ClientCompanyEmployeesEmail = item.ClientCompanyEmployeesEmail,
                            ClientCompanyEmployeesPhoneNumber = item.ClientCompanyEmployeesPhoneNumber,
                            ClientCompanyEmployeesSection = item.ClientCompanyEmployeesSection,
                            ClientCompanyEmployeesPosition = item.ClientCompanyEmployeesPosition,
                        };
                        returnClientCompanyEmployees.Add(clientCompanyEmployee);
                    }
                }

                return Ok(returnClientCompanyEmployees);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // PUT: api/ClientCompanyEmployees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutClientCompanyEmployee( PutClientCompanyEmployee PutclientCompanyEmployee)
        {


            var clientCompanyEmployee = await _context.ClientCompanyEmployees.FindAsync(PutclientCompanyEmployee.ClientCompanyEmployeesId);
            if (clientCompanyEmployee == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(PutclientCompanyEmployee.ClientCompanyEmployeesName))
            {
                clientCompanyEmployee.ClientCompanyEmployeesName = PutclientCompanyEmployee.ClientCompanyEmployeesName;
            }
            if (!string.IsNullOrEmpty(PutclientCompanyEmployee.ClientCompanyEmployeesNameKana))
            {
                clientCompanyEmployee.ClientCompanyEmployeesNameKana = PutclientCompanyEmployee.ClientCompanyEmployeesNameKana;
            }
            if (PutclientCompanyEmployee.ClientCompanyId.HasValue)
            {
                clientCompanyEmployee.ClientCompanyId = PutclientCompanyEmployee.ClientCompanyId.Value;
            }
            if (!string.IsNullOrEmpty(PutclientCompanyEmployee.ClientCompanyEmployeesPhoneNumber))
            {
                clientCompanyEmployee.ClientCompanyEmployeesPhoneNumber = PutclientCompanyEmployee.ClientCompanyEmployeesPhoneNumber;
            }
            if (!string.IsNullOrEmpty(PutclientCompanyEmployee.ClientCompanyEmployeesEmail))
            {
                clientCompanyEmployee.ClientCompanyEmployeesEmail = PutclientCompanyEmployee.ClientCompanyEmployeesEmail;
            }
            if (!string.IsNullOrEmpty(PutclientCompanyEmployee.ClientCompanyEmployeesSection))
            {
                clientCompanyEmployee.ClientCompanyEmployeesSection = PutclientCompanyEmployee.ClientCompanyEmployeesSection;
            }
            if (!string.IsNullOrEmpty(PutclientCompanyEmployee.ClientCompanyEmployeesPosition))
            {
                clientCompanyEmployee.ClientCompanyEmployeesPosition = PutclientCompanyEmployee.ClientCompanyEmployeesPosition;
            }

            _context.Entry(clientCompanyEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(clientCompanyEmployee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientCompanyEmployeeExists(PutclientCompanyEmployee.ClientCompanyEmployeesId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/ClientCompanyEmployees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClientCompanyEmployee>> PostClientCompanyEmployee(PostClientCompanyEmployee postClientCompanyEmployee)
        {
            try 
            {
                var clientCompanyEmployee = new ClientCompanyEmployee
                {
                    ClientCompanyId = postClientCompanyEmployee.ClientCompanyId,
                    ClientCompanyEmployeesName = postClientCompanyEmployee.ClientCompanyEmployeeName,
                    ClientCompanyEmployeesNameKana = postClientCompanyEmployee.ClientCompanyEmployeeNameKana,
                    ClientCompanyEmployeesEmail = postClientCompanyEmployee.ClientCompanyEmployeeEmail,
                    ClientCompanyEmployeesPhoneNumber = postClientCompanyEmployee.ClientCompanyEmployeePhoneNumber,
                    ClientCompanyEmployeesSection = postClientCompanyEmployee.ClientCompanyEmployeeSection,
                    ClientCompanyEmployeesPosition = postClientCompanyEmployee.ClientCompanyEmployeePosition,
                };

                _context.ClientCompanyEmployees.Add(clientCompanyEmployee);
                await _context.SaveChangesAsync();

                return Ok(clientCompanyEmployee);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // DELETE: api/ClientCompanyEmployees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientCompanyEmployee(int id)
        {
            var clientCompanyEmployee = await _context.ClientCompanyEmployees.FindAsync(id);
            if (clientCompanyEmployee == null)
            {
                return NotFound();
            }

            _context.ClientCompanyEmployees.Remove(clientCompanyEmployee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientCompanyEmployeeExists(int id)
        {
            return _context.ClientCompanyEmployees.Any(e => e.ClientCompanyEmployeesId == id);
        }
    }
    public class PostClientCompanyEmployee
    {
        public string ClientCompanyEmployeeName { get; set; }

        public string ClientCompanyEmployeeNameKana { get; set; }

        public int ClientCompanyId { get; set; }

        public string ClientCompanyEmployeePhoneNumber { get; set; }

        public string ClientCompanyEmployeeEmail { get; set; }

        public string ClientCompanyEmployeeSection { get; set; }

        public string ClientCompanyEmployeePosition { get; set; }
    }

    public class PutClientCompanyEmployee
    {
        public int ClientCompanyEmployeesId { get; set; }

        public string? ClientCompanyEmployeesName { get; set; }

        public string? ClientCompanyEmployeesNameKana { get; set; }

        public int? ClientCompanyId { get; set; }

        public string? ClientCompanyEmployeesPhoneNumber { get; set; }

        public string? ClientCompanyEmployeesEmail { get; set; }

        public string? ClientCompanyEmployeesSection { get; set; }

        public string? ClientCompanyEmployeesPosition { get; set; }
    }

    public class GetClientCompanyEmployee
    {
        public int? ClientCompanyEmployeeId { get; set; }

        public string? ClientCompanyEmployeeName { get; set; }

        public string? ClientCompanyEmployeeNameKana { get; set;}

        public int? ClientCompanyId { get; set; }

        public string? ClientCompanyEmployeeSection { get; set; }

        public string? ClientCompanyEmployeePosition { get; set; }

    }
    public class returnClientCompanyEmployee() 
    {
        public int ClientCompanyEmployeesId { get; set; }

        public int ClientCompanyId { get; set; }

        public string ClientCompanyName { get; set; }

        public string ClientCompanyEmployeesName { get; set; }

        public string ClientCompanyEmployeesNameKana { get; set; }

        public string ClientCompanyEmployeesEmail { get; set; }

        public string ClientCompanyEmployeesPhoneNumber { get; set; }

        public string ClientCompanyEmployeesSection { get; set; }

        public string ClientCompanyEmployeesPosition { get; set; }
    }
}

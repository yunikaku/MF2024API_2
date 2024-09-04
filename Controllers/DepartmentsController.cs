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
    public class DepartmentsController : ControllerBase
    {
        private readonly Mf2024api2Context _context;

        public DepartmentsController(Mf2024api2Context context)
        {
            _context = context;
        }

        // GET: api/Departments
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        //{
        //    return await _context.Departments.ToListAsync();
        //}

        // GET: api/Departments/5
        [HttpGet]
        public async Task<ActionResult<Department>> GetDepartment([FromQuery] GetDepartment department)
        {
            try 
            {
                var query = _context.Departments.AsQueryable();

                if (department.DepartmentId.HasValue)
                {
                    query = query.Where(c => c.DepartmentId == department.DepartmentId);
                }
                if (!string.IsNullOrEmpty(department.DepartmentName))
                {
                    query = query.Where(c => c.DepartmentName.Contains(department.DepartmentName));
                }
                var result = await query.ToListAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutDepartment(PutDepartment putdepartment)
        {
            var department = await _context.Departments.FindAsync(putdepartment.DepartmentId);
            if (department == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(putdepartment.DepartmentName))
            {
                department.DepartmentName = putdepartment.DepartmentName;
            }
            
            if (!string.IsNullOrEmpty(putdepartment.DepartmentSlakId))
            {
                department.DepartmentSlackId = putdepartment.DepartmentSlakId;
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(department);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(putdepartment.DepartmentId))
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

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(PostDepartment department)
        {
            try 
            {
                var newDepartment = new Department
                {
                    DepartmentName = department.DepartmentName,
                    
                    DepartmentSlackId = department.DepartmentSlakId,
                };

                _context.Departments.Add(newDepartment);
                await _context.SaveChangesAsync();

                return Ok(newDepartment);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.DepartmentId == id);
        }
    }
    public class PostDepartment
    {
        public string DepartmentName { get; set; }

        public string DepartmentSlakId { get; set;}
    }

    public class PutDepartment
    {
        public int DepartmentId { get; set; }

        public string? DepartmentName { get; set; }

        public string? DepartmentSlakId { get; set; }
    }

    public class GetDepartment
    {
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
    }
}

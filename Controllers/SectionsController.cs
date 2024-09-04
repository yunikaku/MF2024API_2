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
    public class SectionsController : ControllerBase
    {
        private readonly Mf2024api2Context _context;

        public SectionsController(Mf2024api2Context context)
        {
            _context = context;
        }

        // GET: api/Sections
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Section>>> GetSections()
        //{
        //    return await _context.Sections.ToListAsync();
        //}

        // GET: api/Sections/5
        [HttpGet]
        public async Task<ActionResult<Section>> GetSection([FromQuery] GetSection section)
        {
            try 
            {
                var query = _context.Sections.AsQueryable();
                if (section.SectionId.HasValue) 
                {
                    query = query.Where(c => c.SectionId == section.SectionId);
                }

                if (!string.IsNullOrEmpty(section.SectionName))
                {
                    query = query.Where(c => c.SectionName.Contains(section.SectionName));
                }
                if (section.DepartmentId.HasValue)
                {
                    query = query.Where(c => c.DepartmentId == section.DepartmentId);
                }
                if (!string.IsNullOrEmpty(section.DepartmentName))
                {
                    query = query.Where(c => c.Department.DepartmentName.Contains(section.DepartmentName));
                }

                var result = await query.Include(e=>e.Department).ToListAsync();
                List<RerunSection> rerunSections = new List<RerunSection>();
                foreach (var item in result)
                {
                    rerunSections.Add(new RerunSection
                    {
                        SectionId = item.SectionId,
                        SectionName = item.SectionName,
                        SectionSlackId = item.SectionSlackId,
                        SectionSlackUrl = item.SectionSlakUrl,
                        DepartmentId = item.DepartmentId,
                        DepartmentName = item.Department.DepartmentName
                    });
                }

                return Ok(rerunSections);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Sections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutSection(PutSection putsection)
        {
            var section = await _context.Sections.FindAsync(putsection.SectionId);
            if (section == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(putsection.SectionName)) 
            {
                section.SectionName = putsection.SectionName;
            }
            if (!string.IsNullOrEmpty(putsection.SectionSlakId))
            {
                section.SectionSlackId = putsection.SectionSlakId;
            }
            if (!string.IsNullOrEmpty(putsection.SectionSlackUrl))
            {
                section.SectionSlakUrl = putsection.SectionSlackUrl;
            }
            if (putsection.DepartmentId.HasValue)
            {
                section.DepartmentId = putsection.DepartmentId.Value;
            }

            _context.Entry(section).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(section);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectionExists(putsection.SectionId))
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

        // POST: api/Sections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Section>> PostSection(PostSection section)
        {
            try 
            {
                var newSection = new Section
                {
                    SectionName = section.SectionName,
                    SectionSlackId = section.SectionSlakId,
                    SectionSlakUrl = section.SectionSlackUrl,
                    DepartmentId = section.DepartmentId,
                };

                _context.Sections.Add(newSection);
                await _context.SaveChangesAsync();

                return Ok(newSection);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // DELETE: api/Sections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSection(int id)
        {
            var section = await _context.Sections.FindAsync(id);
            if (section == null)
            {
                return NotFound();
            }

            _context.Sections.Remove(section);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SectionExists(int id)
        {
            return _context.Sections.Any(e => e.SectionId == id);
        }
    }
    
    public class PostSection
    {
        public string SectionName { get; set; }

        public string SectionSlakId { get; set; }

        public string SectionSlackUrl { get; set; }

        public int DepartmentId { get; set; }
    }

    public class PutSection
    {
        public int SectionId { get; set; }

        public string? SectionName { get; set; }

        public string? SectionSlakId { get; set; }

        public string? SectionSlackUrl { get; set; }

        public int? DepartmentId { get; set; }
    }

    public class GetSection
    {
        public int? SectionId { get; set; }
        public string? SectionName { get; set; }

        public int? DepartmentId { get; set; }

        public string? DepartmentName { get; set; }

    }

    public class RerunSection
    {
        public int SectionId { get; set; }

        public string SectionName { get; set; }

        public string SectionSlackId { get; set; }

        public string? SectionSlackUrl { get;set;}

        public int? DepartmentId { get; set; }

        public string? DepartmentName { get; set; }

    }
}

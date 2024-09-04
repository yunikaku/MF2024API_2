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
    public class StatusController : ControllerBase
    {
        private readonly Mf2024api2Context _context;

        public StatusController(Mf2024api2Context context)
        {
            _context = context;
        }

        // GET: api/Status
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Status>>> GetStatuses()
        //{
        //    return await _context.Statuses.ToListAsync();
        //}

        // GET: api/Status/5
        [HttpGet]
        public async Task<ActionResult<Status>> GetStatus([FromQuery] GetStatus status)
        {
            try 
            {
                var query = _context.Statuses.AsQueryable();
                if (!string.IsNullOrEmpty(status.StatusName))
                {
                    query = query.Where(c => c.StatusName.Contains(status.StatusName));
                }
                var result = await query.ToListAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Status/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutStatus(PutStatus putstatus)
        {
            var status = await _context.Statuses.FindAsync(putstatus.StatusId);
            if (status == null)
            {
                return NotFound();
            }
            if (putstatus.StatusName != null)
            {
                status.StatusName = putstatus.StatusName;
            }


            _context.Entry(status).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(status);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusExists(putstatus.StatusId))
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

        // POST: api/Status
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Status>> PostStatus(PostStatus postStatus)
        {
            try 
            {
                var status = new Status
                {
                    StatusName = postStatus.StatusName
                };
                _context.Statuses.Add(status);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetStatus", new { id = status.StatusId }, status);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Status/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            var status = await _context.Statuses.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }

            _context.Statuses.Remove(status);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusExists(int id)
        {
            return _context.Statuses.Any(e => e.StatusId == id);
        }
    }
    public class PostStatus
    {
        public string StatusName { get; set; }
    }

    public class PutStatus
    {
        public int StatusId { get; set; }
        public string? StatusName { get; set; }
    }

    public class GetStatus
    {
        public string? StatusName { get; set; }
    }
}

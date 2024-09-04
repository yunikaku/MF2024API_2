using MF2024API_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MF2024API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotReservationController : ControllerBase
    {
        private readonly Mf2024api2Context _context;

        public NotReservationController(Mf2024api2Context context)
        {
            _context = context;
        }



        // GET: api/NotReservation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotReservation>>> GetNotReservations( GetNotReservation getNotReservation)
        {
            var query = _context.NotReservations.AsQueryable();

            if (getNotReservation.NotReservationId.HasValue)
            {
                query = query.Where(c => c.NotReservationId == getNotReservation.NotReservationId);
            }
            if (!string.IsNullOrEmpty(getNotReservation.NotReservationName))
            {
                query = query.Where(c => c.NotReservationName.Contains(getNotReservation.NotReservationName));
            }
            if (!string.IsNullOrEmpty(getNotReservation.NotReservationRequirement))
            {
                query = query.Where(c => c.NotReservationRequirement.Contains(getNotReservation.NotReservationRequirement));
            }
            if (!string.IsNullOrEmpty(getNotReservation.NotReservationCompanyName))
            {
                query = query.Where(c => c.NotReservationCompanyName.Contains(getNotReservation.NotReservationCompanyName));
            }
            var result = await query.ToListAsync();
            return result;

        }

        // POST: api/NotReservation

        [HttpPost]
        public async Task<ActionResult<NotReservation>> PostNotReservation(postNotReservation notReservation)
        {
            try
            {
                NotReservation NotReservation = new NotReservation()
                {
                    NotReservationName = notReservation.NotReservationName,
                    NotReservationRequirement = notReservation.NotReservationRequirement,
                    NotReservationCompanyName = notReservation.NotReservationCompanyName
                };
                _context.NotReservations.Add(NotReservation);
                await _context.SaveChangesAsync();
                return Ok(NotReservation) ;

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/NotReservation/5

        [HttpPut]
        public async Task<ActionResult<NotReservation>> putNotReservation(PutNotReservation putNotReservation)
        {
            try
            {
                var notReservation = await _context.NotReservations.FindAsync(putNotReservation.NotReservationId);
                if (notReservation == null)
                {
                    return NotFound();
                }
                notReservation.NotReservationName = putNotReservation.NotReservationName;
                notReservation.NotReservationRequirement = putNotReservation.NotReservationRequirement;
                notReservation.NotReservationCompanyName = putNotReservation.NotReservationCompanyName;
                await _context.SaveChangesAsync();
                return Ok(notReservation);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/NotReservation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotReservation(int id)
        {
            var notReservation = await _context.NotReservations.FindAsync(id);
            if (notReservation == null)
            {
                return NotFound();
            }

            _context.NotReservations.Remove(notReservation);
            await _context.SaveChangesAsync();

            return NoContent();
        }



        public class GetNotReservation
        {
            public int? NotReservationId { get; set; }

            public string? NotReservationName { get; set; }

            public string? NotReservationRequirement { get; set; }

            public string? NotReservationCompanyName { get; set; }
        }

        public class PutNotReservation
        {
            public int NotReservationId { get; set; }

            public string NotReservationName { get; set; }

            public string NotReservationRequirement { get; set; }

            public string? NotReservationCompanyName { get; set; }
        }

        public class postNotReservation
        {
            public string NotReservationName { get; set; }

            public string NotReservationRequirement { get; set; }

            public string? NotReservationCompanyName { get; set; }
        }


    }
}

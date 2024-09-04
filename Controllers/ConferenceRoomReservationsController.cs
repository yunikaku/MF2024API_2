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
    public class ConferenceRoomReservationsController : ControllerBase
    {
        private readonly Mf2024api2Context _context;

        public ConferenceRoomReservationsController(Mf2024api2Context context)
        {
            _context = context;
        }

        // GET: api/ConferenceRoomReservations
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ConferenceRoomReservation>>> GetConferenceRoomReservations()
        //{
        //    return await _context.ConferenceRoomReservations.ToListAsync();
        //}

        // GET: api/ConferenceRoomReservations/5
        [HttpGet]
        public async Task<ActionResult<ConferenceRoomReservation>> GetConferenceRoomReservation([FromQuery] GetConferenceRoomReservation roomReservation)
        {
            try
            {
                var query = _context.ConferenceRoomReservations.AsQueryable();

                if (roomReservation.ConferenceRoomId.HasValue)
                {
                    query = query.Where(c => c.ConferenceRoomId == roomReservation.ConferenceRoomId);
                }
                if (!string.IsNullOrEmpty(roomReservation.UserId))
                {
                    query = query.Where(c => c.UserId == roomReservation.UserId);
                }
                if (!string.IsNullOrEmpty(roomReservation.Requirement))
                {
                    query = query.Where(c => c.Requirement.Contains(roomReservation.Requirement));
                }
                if (roomReservation.StartTime.HasValue)
                {
                    query = query.Where(c => c.StartTime >= roomReservation.StartTime);
                }
                if (roomReservation.EndTime.HasValue)
                {
                    query = query.Where(c => c.EndTime <= roomReservation.EndTime);
                }
                var result = await query.ToListAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        
        }

        // PUT: api/ConferenceRoomReservations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutConferenceRoomReservation( PutConferenceRoomReservation putconferenceRoomReservation)
        {
            var conferenceRoomReservation = await _context.ConferenceRoomReservations.FindAsync(putconferenceRoomReservation.ConferenceRoomReservationsId);
            if (conferenceRoomReservation == null)
            {
                return NotFound();
            }
            if (putconferenceRoomReservation.ConferenceRoomId.HasValue)
            {
                conferenceRoomReservation.ConferenceRoomId = putconferenceRoomReservation.ConferenceRoomId.Value;
            }
            if (!string.IsNullOrEmpty(putconferenceRoomReservation.UserId))
            {
                conferenceRoomReservation.UserId = putconferenceRoomReservation.UserId;
            }
            if (!string.IsNullOrEmpty(putconferenceRoomReservation.Requirement))
            {
                conferenceRoomReservation.Requirement = putconferenceRoomReservation.Requirement;
            }
            if (putconferenceRoomReservation.StartTime.HasValue)
            {
                conferenceRoomReservation.StartTime = putconferenceRoomReservation.StartTime.Value;
            }
            if (putconferenceRoomReservation.EndTime.HasValue)
            {
                conferenceRoomReservation.EndTime = putconferenceRoomReservation.EndTime.Value;
            }


            _context.Entry(conferenceRoomReservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(conferenceRoomReservation);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConferenceRoomReservationExists(putconferenceRoomReservation.ConferenceRoomReservationsId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/ConferenceRoomReservations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConferenceRoomReservation>> PostConferenceRoomReservation(PostConferenceRoomReservation conferenceRoomReservation)
        {
            try
            {
                var newConferenceRoomReservation = new ConferenceRoomReservation
                {
                    ConferenceRoomId = conferenceRoomReservation.ConferenceRoomId,
                    UserId = conferenceRoomReservation.UserId,
                    Requirement = conferenceRoomReservation.Requirement,
                    StartTime = conferenceRoomReservation.StartTime,
                    EndTime = conferenceRoomReservation.EndTime,
                    ReservationTime = DateTime.Now,
                };
                await _context.SaveChangesAsync();
                return Ok(newConferenceRoomReservation);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/ConferenceRoomReservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConferenceRoomReservation(int id)
        {
            var conferenceRoomReservation = await _context.ConferenceRoomReservations.FindAsync(id);
            if (conferenceRoomReservation == null)
            {
                return NotFound();
            }

            _context.ConferenceRoomReservations.Remove(conferenceRoomReservation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConferenceRoomReservationExists(int id)
        {
            return _context.ConferenceRoomReservations.Any(e => e.ConferenceRoomReservationsId == id);
        }
    }

    public class PostConferenceRoomReservation
    {
        public int ConferenceRoomId { get; set; }

        public string UserId { get; set; }

        public string Requirement { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }

    public class PutConferenceRoomReservation
    {
        public int ConferenceRoomReservationsId { get; set; }

        public int? ConferenceRoomId { get; set; }

        public string? UserId { get; set; }

        public string? Requirement { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
    }

    public class GetConferenceRoomReservation
    {
        public int? ConferenceRoomId { get; set; }

        public string? UserId { get; set; }

        public string? Requirement { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
    }
}

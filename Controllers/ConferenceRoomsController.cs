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
    public class ConferenceRoomsController : ControllerBase
    {
        private readonly Mf2024api2Context _context;

        public ConferenceRoomsController(Mf2024api2Context context)
        {
            _context = context;
        }

        // GET: api/ConferenceRooms
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<ConferenceRoom>>> GetConferenceRooms()
        //{
        //    return await _context.ConferenceRooms.ToListAsync();
        //}

        // GET: api/ConferenceRooms/5
        [HttpGet]
        public async Task<ActionResult<ConferenceRoom>> GetConferenceRoom([FromQuery] GetConferenceRoom conferenceRoom)
        {
            try 
            {
                var query = _context.ConferenceRooms.AsQueryable();

                if (conferenceRoom.ConferenceRoomId.HasValue)
                {
                    query = query.Where(c => c.ConferenceRoomId == conferenceRoom.ConferenceRoomId);
                }
                if (!string.IsNullOrEmpty(conferenceRoom.ConferenceRoomName))
                {
                    query = query.Where(c => c.ConferenceRoomName.Contains(conferenceRoom.ConferenceRoomName));
                }
                if (conferenceRoom.ConferenceRoomCapacity.HasValue)
                {
                    query = query.Where(c => c.ConferenceRoomCapacity == conferenceRoom.ConferenceRoomCapacity);
                }
                var result = await query.ToListAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/ConferenceRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutConferenceRoom(PutConferenceRoom putconferenceRoom)
        {
            var conferenceRoom = await _context.ConferenceRooms.FindAsync(putconferenceRoom.ConferenceRoomId);
            if (conferenceRoom == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(putconferenceRoom.ConferenceRoomName))
            {
                conferenceRoom.ConferenceRoomName = putconferenceRoom.ConferenceRoomName;
            }
            if (putconferenceRoom.ConferenceRoomCapacity.HasValue)
            {
                conferenceRoom.ConferenceRoomCapacity = putconferenceRoom.ConferenceRoomCapacity.Value;
            }
            conferenceRoom.UpdateTime = DateTime.Now;
            conferenceRoom.UpdateUser = putconferenceRoom.UpdateUser;
            _context.Entry(conferenceRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(conferenceRoom);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConferenceRoomExists(putconferenceRoom.ConferenceRoomId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/ConferenceRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConferenceRoom>> PostConferenceRoom(PostConferenceRoom conferenceRoom)
        {
            try
            {
                var newConferenceRoom = new ConferenceRoom
                {
                    ConferenceRoomName = conferenceRoom.ConferenceRoomName,
                    ConferenceRoomCapacity = conferenceRoom.ConferenceRoomCapacity,
                    UpdateTime = DateTime.Now,
                    UpdateUser = conferenceRoom.UpdateUserId,
                };
                _context.ConferenceRooms.Add(newConferenceRoom);
                await _context.SaveChangesAsync();
                return Ok(newConferenceRoom);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // DELETE: api/ConferenceRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConferenceRoom(int id)
        {
            var conferenceRoom = await _context.ConferenceRooms.FindAsync(id);
            if (conferenceRoom == null)
            {
                return NotFound();
            }

            _context.ConferenceRooms.Remove(conferenceRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConferenceRoomExists(int id)
        {
            return _context.ConferenceRooms.Any(e => e.ConferenceRoomId == id);
        }
    }

    public class PostConferenceRoom
    {
        public string ConferenceRoomName { get; set; }

        public int ConferenceRoomCapacity { get; set; }

        public string UpdateUserId { get; set; }
    }

    public class PutConferenceRoom
    {
        public int ConferenceRoomId { get; set; }

        public string? ConferenceRoomName { get; set; } = null!;

        public int? ConferenceRoomCapacity { get; set; }

        public string? UpdateUser { get; set; } = null!;
    }

    public class GetConferenceRoom
    {
        public int? ConferenceRoomId { get; set; }

        public string? ConferenceRoomName { get; set; }

        public int? ConferenceRoomCapacity { get; set; }
    }
}

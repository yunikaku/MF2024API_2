using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MF2024API_2.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;

namespace MF2024API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly Mf2024api2Context _context;

        public DevicesController(Mf2024api2Context context)
        {
            _context = context;
        }

        // GET: api/Devices
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Device>>> GetDevices()
        //{
        //    return await _context.Devices.ToListAsync();
        //}

        // GET: api/Devices/5
        [HttpGet]
        public async Task<ActionResult<Device>> GetDevice([FromQuery] GetDevice device)
        {
            try 
            {
                var query = _context.Devices.AsQueryable();

                if (device.DeviceId.HasValue)
                {
                    query = query.Where(c => c.DeviceId == device.DeviceId);
                }
                if (!string.IsNullOrEmpty(device.DeviceName))
                {
                    query = query.Where(c => c.DeviceName.Contains(device.DeviceName));
                }
                if (!string.IsNullOrEmpty(device.DeviceLocation))
                {
                    query = query.Where(c => c.DeviceLocation.Contains(device.DeviceLocation));
                }
                var result = await query.Include(e=>e.DeviceUpdateUserNavigation).ToListAsync();
                List<ReturnDevice> returnDevices = new List<ReturnDevice>();
                foreach (var item in result)
                {
                    returnDevices.Add(new ReturnDevice
                    {
                        DeviceId = item.DeviceId,
                        DeviceName = item.DeviceName,
                        DeviceLocation = item.DeviceLocation,
                        CreationTime = item.CreationTime,
                        UpdateTime = item.UpdateTime,
                        DeviceUpdateUserID = item.DeviceUpdateUserID,
                        DeviceUpdateUserName = item.DeviceUpdateUserNavigation.UserName
                    });
                }


                return Ok(returnDevices);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Devices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutDevice(PutDevice putdevice)
        {
            var device = await _context.Devices.FindAsync(putdevice.DeviceId);
            if (device == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(putdevice.DeviceName))
            {
                device.DeviceName = putdevice.DeviceName;
            }
            if (!string.IsNullOrEmpty(putdevice.DeviceLocation))
            {
                device.DeviceLocation = putdevice.DeviceLocation;
            }
            device.DeviceUpdateUserID = putdevice.DeviceUpdateUserID;
            device.UpdateTime = DateTime.Now;
            

            _context.Entry(device).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(device);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(putdevice.DeviceId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Devices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Device>> PostDevice(PostDevice postDevice)
        {
            try
            {
                var device = new Device
                {
                    DeviceName = postDevice.DeviceName,
                    DeviceLocation = postDevice.DeviceLocation,
                    CreationTime = DateTime.Now,
                    DeviceUpdateUserID = postDevice.DeviceUpdateUserID,
                };

                _context.Devices.Add(device);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetDevice", new { id = device.DeviceId }, device);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // DELETE: api/Devices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            _context.Devices.Remove(device);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeviceExists(int id)
        {
            return _context.Devices.Any(e => e.DeviceId == id);
        }
    }

    public class PostDevice
    {
        public string DeviceName { get; set; } = null!;

        public string DeviceLocation { get; set; } = null!;

        public string DeviceUpdateUserID { get; set; } = null!;
    }

    public class PutDevice
    {
        public int DeviceId { get; set; }

        public string? DeviceName { get; set; } = null!;

        public string? DeviceLocation { get; set; } = null!;

        public string DeviceUpdateUserID { get; set; } = null!;
    }

    public class GetDevice
    {
        public int? DeviceId { get; set; }

        public string? DeviceName { get; set; }

        public string? DeviceLocation { get; set; }
    }
    public class ReturnDevice
    {
        public int DeviceId { get; set; }

        public string DeviceName { get; set; }

        public string DeviceLocation { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime UpdateTime { get; set; }

        public string DeviceUpdateUserID { get; set; }

        public string DeviceUpdateUserName { get; set; }
    }
}
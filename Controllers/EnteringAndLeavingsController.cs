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
    public class EnteringAndLeavingsController : ControllerBase
    {
        private readonly Mf2024api2Context _context;

        public EnteringAndLeavingsController(Mf2024api2Context context)
        {
            _context = context;
        }

        // GET: api/EnteringAndLeavings
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<EnteringAndLeaving>>> GetEnteringAndLeavings()
        //{
        //    return await _context.EnteringAndLeavings.ToListAsync();
        //}

        // GET: api/EnteringAndLeavings/5
        [HttpGet]
        public async Task<ActionResult<EnteringAndLeaving>> GetEnteringAndLeaving(GetEnteringAndLeaving enteringAndLeaving)
        {
            var query = _context.EnteringAndLeavings.AsQueryable();
            if(enteringAndLeaving.EnteringAndLeavingId.HasValue)
            {
                query = query.Where(c => c.EnteringAndLeavingId == enteringAndLeaving.EnteringAndLeavingId);
            }
            if (enteringAndLeaving.DeviceId.HasValue)
            {
                query = query.Where(c => c.DeviceId == enteringAndLeaving.DeviceId);
            }
            if (!string.IsNullOrEmpty(enteringAndLeaving.NfcUid))
            {
                query = query.Where(c => c.Nfc.NfcUid == enteringAndLeaving.NfcUid);
            }
            if (enteringAndLeaving.StatusId.HasValue)
            {
                query = query.Where(c => c.StatusId == enteringAndLeaving.StatusId);
            }
            if (enteringAndLeaving.CompleteFlg.HasValue)
            {
                query = query.Where(c => c.CompleteFlg == enteringAndLeaving.CompleteFlg);
            }
            if (!string.IsNullOrEmpty(enteringAndLeaving.UserId)) 
            {
                query = query.Where(c => c.UserId == enteringAndLeaving.UserId);
            }
            if (!string.IsNullOrEmpty(enteringAndLeaving.UserName))
            {
                query = query.Where(c => c.User.UserName.Contains(enteringAndLeaving.UserName));
            }
            if (enteringAndLeaving.ClientCompanyEmployeesId.HasValue)
            {
                query = query.Where(c => c.ClientCompanyEmployeesId == enteringAndLeaving.ClientCompanyEmployeesId);
            }
            if (!string.IsNullOrEmpty(enteringAndLeaving.ClientCompanyEmployeesName))
            {
                query = query.Where(c => c.ClientCompanyEmployees.ClientCompanyEmployeesName.Contains(enteringAndLeaving.ClientCompanyEmployeesName));
            }
            if (enteringAndLeaving.StartTime.HasValue)
            {
                query = query.Where(c => c.EnteringAndLeavingAdmissionTime >= enteringAndLeaving.StartTime);
            }
            if (enteringAndLeaving.EndTime.HasValue)
            {
                query = query.Where(c => c.EnteringAndLeavingAdmissionTime <= enteringAndLeaving.EndTime);
            }
            
            var result = await query.Include(e=>e.User).Include(e=>e.ClientCompanyEmployees).Include(e=>e.Device).ToListAsync();
            List<ReturnEnteringAndLeaving> returnEnteringAndLeavings = new List<ReturnEnteringAndLeaving>();
            foreach (var item in result)
            {
                returnEnteringAndLeavings.Add(new ReturnEnteringAndLeaving
                {
                    EnteringAndLeavingId = item.EnteringAndLeavingId,
                    DeviceId = item.DeviceId,
                    DeviceName = item.Device.DeviceName,
                    NfcUid = item.Nfc.NfcUid,
                    UserId = item.UserId,
                    UserName = item.User.UserName,
                    ClientCompanyEmployeesId = item.ClientCompanyEmployeesId,
                    ClientCompanyEmployeesName = item.ClientCompanyEmployees.ClientCompanyEmployeesName,
                    StatusName = item.Status.StatusName,
                    CompleteFlg = item.CompleteFlg,
                    EnteringAndLeavingAdmissionTime = item.EnteringAndLeavingAdmissionTime,
                    EnteringAndLeavingExitTime = item.EnteringAndLeavingExitTime
                });
            }



            return Ok(returnEnteringAndLeavings);


        }

        [HttpPost("EnteringAndLeavingAdmission")]
        public async Task<ActionResult<EnteringAndLeaving>> EnteringAndLeavingSet(PostEnteringAndLeaving postEnteringAndLeaving)
        {
            try
            {
                var Usesr=await _context.Nfcs.FindAsync(postEnteringAndLeaving.NfcId);
                if (Usesr.UserId!=null) 
                {
                    var EnteringAndLeaving = new EnteringAndLeaving
                    {
                        DeviceId = postEnteringAndLeaving.DeviceId,
                        NfcId = postEnteringAndLeaving.NfcId,
                        StatusId = postEnteringAndLeaving.StatusId,
                        EnteringAndLeavingAdmissionTime = System.DateTime.Now,
                        UserId = Usesr.UserId,
                        CompleteFlg = 0,
                    };
                    _context.EnteringAndLeavings.Add(EnteringAndLeaving);
                    await _context.SaveChangesAsync();

                    return Ok(EnteringAndLeaving.EnteringAndLeavingId);
                }
                else if (Usesr.ClientCompanyEmployeesId!=null)
                {
                     var EnteringAndLeaving = new EnteringAndLeaving
                      {
                            DeviceId = postEnteringAndLeaving.DeviceId,
                            NfcId = postEnteringAndLeaving.NfcId,
                            StatusId = postEnteringAndLeaving.StatusId,
                            EnteringAndLeavingAdmissionTime = System.DateTime.Now,
                            ClientCompanyEmployeesId = (int)Usesr.ClientCompanyEmployeesId,
                            CompleteFlg = 0,
                      };

                        _context.EnteringAndLeavings.Add(EnteringAndLeaving);
                        await _context.SaveChangesAsync();

                        return Ok(EnteringAndLeaving.EnteringAndLeavingId);
                }
                else
                {
                    return BadRequest();
                }


                

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpPut("EnteringAndLeavingExit")]
        public async Task<ActionResult<EnteringAndLeaving>> EnteringAndLeavingExit(PutEnteringAndLeaving putEnteringAndLeaving)
        {
            try
            {
                var EnteringAndLeaving = await _context.EnteringAndLeavings.FindAsync(putEnteringAndLeaving.EnteringAndLeavingId);
                if (EnteringAndLeaving == null)
                {
                    return NotFound();
                }

                EnteringAndLeaving.StatusId = putEnteringAndLeaving.StatusId;
                EnteringAndLeaving.CompleteFlg = 1;
                EnteringAndLeaving.EnteringAndLeavingExitTime = System.DateTime.Now;

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }



        // DELETE: api/EnteringAndLeavings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnteringAndLeaving(int id)
        {
            var enteringAndLeaving = await _context.EnteringAndLeavings.FindAsync(id);
            if (enteringAndLeaving == null)
            {
                return NotFound();
            }

            _context.EnteringAndLeavings.Remove(enteringAndLeaving);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnteringAndLeavingExists(int id)
        {
            return _context.EnteringAndLeavings.Any(e => e.EnteringAndLeavingId == id);
        }
    }

    public class PostEnteringAndLeaving
    {
        public int DeviceId { get; set; }

        public int NfcId { get; set; }

        public int StatusId { get; set; }

    }
    public class PutEnteringAndLeaving
    {
        public int EnteringAndLeavingId { get; set; }

        public int StatusId { get; set; }

    }

    public class GetEnteringAndLeaving
    {
        public int? EnteringAndLeavingId { get; set; }

        public int? DeviceId { get; set; }

        public string? NfcUid { get; set; }

        public string? UserId { get; set; }

        public string? UserName { get; set; }

        public int? ClientCompanyEmployeesId { get; set; }

        public string? ClientCompanyEmployeesName { get; set; }

        public int? StatusId { get; set; }

        public int? CompleteFlg { get; set; }


        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

    }

    public class ReturnEnteringAndLeaving
    {
        public int EnteringAndLeavingId { get; set; }

        public int DeviceId { get; set; }

        public string DeviceName { get; set; }

        public string NfcUid { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public int ClientCompanyEmployeesId { get; set; }

        public string ClientCompanyEmployeesName { get; set; }

        public string StatusName { get; set; }

        public int CompleteFlg { get; set; }

        public DateTime EnteringAndLeavingAdmissionTime { get; set; }

        public DateTime EnteringAndLeavingExitTime { get; set; }

    }
}

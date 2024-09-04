using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MF2024API_2.Models;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;

namespace MF2024API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NfcsController : ControllerBase
    {
        private readonly Mf2024api2Context _context;

        public NfcsController(Mf2024api2Context context)
        {
            _context = context;
        }

        // GET: api/Nfcs
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Nfc>>> GetNfcs()
        //{
        //    return await _context.Nfcs.ToListAsync();
        //}

        // GET: api/Nfcs/5
        [HttpGet]
        public async Task<ActionResult<Nfc>> GetNfc([FromQuery] GetNfc nfc)
        {
            try 
            {
                var query = _context.Nfcs.AsQueryable();

                if (!string.IsNullOrEmpty(nfc.CardUid))
                {
                    query = query.Where(c => c.NfcUid == nfc.CardUid);
                }
                if (!string.IsNullOrEmpty(nfc.UserName))
                {
                    query = query.Where(c => c.User.UserName.Contains(nfc.UserName));
                }
                if (!string.IsNullOrEmpty(nfc.ClientCompanyEmployeesName))
                {
                    query = query.Where(c => c.ClientCompanyEmployees.ClientCompanyEmployeesName.Contains(nfc.ClientCompanyEmployeesName));
                }
                if (!string.IsNullOrEmpty(nfc.NotReservationName))
                {
                    query = query.Where(c => c.NotReservation.NotReservationName.Contains(nfc.NotReservationName));
                }
                var result = await query.Include(e=>e.User).Include(e=>e.ClientCompanyEmployees).Include(e=>e.NotReservation).ToListAsync();


                List<returnNfc> returnNfcs = new List<returnNfc>();

                if (result != null)
                { 
                    foreach (var item in result)
                    {
                        returnNfc Nfc = new returnNfc
                        {
                            NfcId = item.NfcId,
                            NfcUid = item.NfcUid,
                            UserId = item.UserId,
                            UserName = item.User?.UserName,
                            ClientCompanyEmployeesId = item.ClientCompanyEmployeesId,
                            ClientCompanyEmployeesName = item.ClientCompanyEmployees?.ClientCompanyEmployeesName,
                            NotReservationId = item.NotReservationId,
                            NotReservationName = item.NotReservation?.NotReservationName,
                            AlloottedTime = item.AlloottedTime,
                            UpdateTime = item.UpdateTime,
                            NfcPayload = item.NfcPayload,
                        };
                        returnNfcs.Add(Nfc);

                    }
                }
                

                return Ok(returnNfcs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Nfcs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nfc>> PostNfc(PostNfc postNfc)
        {
            try
            {
                var nfc = new Nfc
                {
                    NfcUid = postNfc.CardUid,
                    NfcPayload = "",
                };
                _context.Nfcs.Add(nfc);
                await _context.SaveChangesAsync();
                return Ok(nfc);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // DELETE: api/Nfcs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNfc(int id)
        {
            var nfc = await _context.Nfcs.FindAsync(id);
            if (nfc == null)
            {
                return NotFound();
            }

            _context.Nfcs.Remove(nfc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NfcExists(int id)
        {
            return _context.Nfcs.Any(e => e.NfcId == id);
        }

        [HttpPut("NFCset")]
        public async Task<ActionResult<Nfc>> NFCset(SetNfc setNfc)
        {
            try 
            {
                var NFC = await _context.Nfcs.SingleOrDefaultAsync(c => c.NfcUid == setNfc.CardUid);

                    if (NFC == null)
                    {
                        return NotFound();
                    }

                    if (!string.IsNullOrEmpty(setNfc.UserId))
                    {
                        NFC.UserId = setNfc.UserId;
                        NFC.NfcPayload = setNfc.NfcPayload;
                        NFC.UpdateTime = System.DateTime.Now;
                    }
                    else if (setNfc.ClientCompanyEmployeesId.HasValue)
                    {
                        NFC.ClientCompanyEmployeesId = setNfc.ClientCompanyEmployeesId;
                        NFC.NfcPayload = setNfc.NfcPayload;
                        NFC.UpdateTime = System.DateTime.Now;

                    }
                    else if (setNfc.NotReservationId.HasValue)
                    {
                        NFC.NotReservationId = setNfc.NotReservationId;
                        NFC.NfcPayload = setNfc.NfcPayload;
                        NFC.UpdateTime = System.DateTime.Now;
                    }
                    else
                    {
                        return BadRequest();
                    }

                    await _context.SaveChangesAsync();

                    return Ok(NFC);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpPut("NFCReset")]
        public async Task<ActionResult<Nfc>>NFCReset(PutNfc putNfc) 
        {
            var NFC = await _context.Nfcs.FindAsync(putNfc.NfcUid);
            if (NFC == null)
            {
                return NotFound();
            }
            NFC.UserId = null;
            NFC.ClientCompanyEmployeesId = null;
            NFC.NotReservationId = null;
            NFC.NfcPayload = "";
            NFC.UpdateTime = System.DateTime.Now;
            await _context.SaveChangesAsync();
            return Ok(NFC);
        }
    }

    public class PostNfc
    {
        public string CardUid { get; set; }
    }

    public class PutNfc
    {
        public int? NfcUid { get; set; }
    }

    public class GetNfc
    {
        public string? CardUid { get; set; }

        public string? UserName { get; set; }

        public string? ClientCompanyEmployeesName { get; set; }

        public string? NotReservationName { get; set; }
    }

    public class SetNfc
    {
        public string CardUid { get; set; }

        public string? UserId { get; set; }

        public int? ClientCompanyEmployeesId { get; set; }

        public int? NotReservationId { get; set; }

        public string? NfcPayload { get; set; }

    }

    public class returnNfc()
    {

        public int? NfcId { get; set; }

        public string? NfcUid { get; set; }

        public string? UserId { get; set; }

        public string? UserName { get; set; }

        public int? ClientCompanyEmployeesId { get; set; }

        public string? ClientCompanyEmployeesName { get; set; }

        public int? NotReservationId { get; set; }

        public string? NotReservationName { get; set; }

        public DateTime? AlloottedTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public string? NfcPayload { get; set; }
    }
}

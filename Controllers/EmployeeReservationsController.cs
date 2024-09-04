using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MF2024API_2.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using QRCoder;

namespace MF2024API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeReservationsController : ControllerBase
    {
        private readonly Mf2024api2Context _context;

        public EmployeeReservationsController(Mf2024api2Context context)
        {
            _context = context;
        }

        // GET: api/EmployeeReservations
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<EmployeeReservation>>> GetEmployeeReservations()
        //{
        //    return await _context.EmployeeReservations.ToListAsync();
        //}

        // GET: api/EmployeeReservations/5
        [HttpGet]
        public async Task<ActionResult<EmployeeReservation>> GetEmployeeReservation([FromQuery] GetEmployeeReservations employeeReservations)
        {
            try
            {
                var result = _context.EmployeeReservations.AsQueryable();
                if (employeeReservations.EmployeeReservationsId.HasValue)
                {
                    result = result.Where(c => c.EmployeeReservationsId == employeeReservations.EmployeeReservationsId);
                }
                if (!string.IsNullOrEmpty(employeeReservations.UserId))
                {
                    result = result.Where(c => c.UserId == employeeReservations.UserId);
                }
                if (!string.IsNullOrEmpty(employeeReservations.UserName)) 
                {
                    result = result.Where(c => c.User.UserName.Contains(employeeReservations.UserName));
                }
                if (employeeReservations.ClientCompanyEmployeesId.HasValue)
                {
                    result = result.Where(c => c.ClientCompanyEmployeesId == employeeReservations.ClientCompanyEmployeesId);
                }
                if (!string.IsNullOrEmpty(employeeReservations.ClientCompanyEmployeesName))
                {
                    result = result.Where(c => c.ClientCompanyEmployees.ClientCompanyEmployeesName.Contains(employeeReservations.ClientCompanyEmployeesName));
                }
                if (employeeReservations.ReservationStartTime.HasValue)
                {
                    result = result.Where(c => c.ReservationsTime >= employeeReservations.ReservationStartTime);
                }
                if (employeeReservations.ReservationEndTime.HasValue)
                {
                    result = result.Where(c => c.ReservationsTime <= employeeReservations.ReservationEndTime);
                }
                if (!string.IsNullOrEmpty(employeeReservations.Requirement))
                {
                    result = result.Where(c => c.Requirement.Contains(employeeReservations.Requirement));
                }
                if (employeeReservations.Qr != null)
                {
                    result = result.Where(c => c.Qr == employeeReservations.Qr);
                }
                var employees = await result.Include(o =>o.User).Include(o=>o.ClientCompanyEmployees).ToListAsync();
                //var employees = await result.FirstAsync();
                var resultEmployees = new List<ResultEmployeeReservation>();

                if (employees.Count == 0)
                {
                    return NotFound();
                }
                {
                    foreach (var item in employees)
                    {
                        var list = new ResultEmployeeReservation
                        {
                            UserName = item.User.UserName,
                            ClientCompanyEmployeesName = item.ClientCompanyEmployees.ClientCompanyEmployeesName,
                            ReservationsTime = item.ReservationsTime,
                            Requirement = item.Requirement,
                            UserId = item.UserId,
                            ClientCompanyEmployeesId = item.ClientCompanyEmployeesId,
                            EmployeeReservationsId = item.EmployeeReservationsId,
                            Qr = item.Qr,
                            CompleteFlag = item.CompleteFlag

                        };
                        resultEmployees.Add(list);

                    }

                }
                

                return Ok(resultEmployees);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/EmployeeReservations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutEmployeeReservation(PutEmployeeReservation putemployeeReservation)
        {
            var employeeReservation = await _context.EmployeeReservations.FindAsync(putemployeeReservation.EmployeeReservationsId);
            if (employeeReservation == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(putemployeeReservation.UserId))
            {
                employeeReservation.UserId = putemployeeReservation.UserId;
            }
            if (putemployeeReservation.ClientCompanyEmployeesId.HasValue)
            {
                employeeReservation.ClientCompanyEmployeesId = putemployeeReservation.ClientCompanyEmployeesId.Value;
            }
            if (putemployeeReservation.ReservationTime.HasValue)
            {
                employeeReservation.ReservationsTime = putemployeeReservation.ReservationTime.Value;
            }
            if (!string.IsNullOrEmpty(putemployeeReservation.Requirement))
            {
                employeeReservation.Requirement = putemployeeReservation.Requirement;
            }
            if (!string.IsNullOrEmpty(putemployeeReservation.CompleteFlag))
            {
                employeeReservation.CompleteFlag = putemployeeReservation.CompleteFlag;
            }


            _context.Entry(employeeReservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(employeeReservation);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeReservationExists(putemployeeReservation.EmployeeReservationsId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/EmployeeReservations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeReservation>> PostEmployeeReservation(PostEmployeeReservation employeeReservation)
        {
            try
            {
                


                var employeeReservations = new EmployeeReservation
                {

                    UserId = employeeReservation.UserId,
                    ClientCompanyEmployeesId = employeeReservation.ClientCompanyEmployeesId,
                    Requirement = employeeReservation.Requirement,
                    ReservationsTime = employeeReservation.ReservationTime,
                    CompleteFlag = "未",
                };

                

                var QRGenerator = new QRCodeGenerator();
                //今後　IDを暗号化する必要あり
                var QRData = QRGenerator.CreateQrCode(employeeReservations.EmployeeReservationsId.ToString(), QRCodeGenerator.ECCLevel.Q);
                var QRCode = new PngByteQRCode(QRData);
                var QRCodeImage = QRCode.GetGraphic(10);

                employeeReservations.Qr = QRCodeImage;


                _context.EmployeeReservations.Add(employeeReservations);
                await _context.SaveChangesAsync();

                return Ok(employeeReservations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/EmployeeReservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeReservation(int id)
        {
            var employeeReservation = await _context.EmployeeReservations.FindAsync(id);
            if (employeeReservation == null)
            {
                return NotFound();
            }

            _context.EmployeeReservations.Remove(employeeReservation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeReservationExists(int id)
        {
            return _context.EmployeeReservations.Any(e => e.EmployeeReservationsId == id);
        }

        [HttpGet("QR")]
        public async Task<ActionResult<EmployeeReservation>> QR(byte QRdata)
        {
            ///QRに何をいるかは未定

            var Reservation = await _context.EmployeeReservations.FindAsync(QRdata);

            return Reservation;
        }
    }

    public class PostEmployeeReservation
    {
        public string UserId { get; set; }

        public int ClientCompanyEmployeesId { get; set; }

        public DateTime ReservationTime { get; set; }


        public string Requirement { get; set; }

    }

    public class PutEmployeeReservation
    {
        public int EmployeeReservationsId { get; set; }

        public string? UserId { get; set; }

        public int? ClientCompanyEmployeesId { get; set; }

        public DateTime? ReservationTime { get; set; }

        public string? CompleteFlag { get; set; }

        public string? Requirement { get; set; }
    }

    public class GetEmployeeReservations 
    {
        public int? EmployeeReservationsId { get; set; }

        public string? UserId { get; set; }

        public string? UserName { get; set; }

        public int? ClientCompanyEmployeesId { get; set; }

        public string? ClientCompanyEmployeesName { get; set; }

        public DateTime? ReservationStartTime { get; set; }

        public DateTime? ReservationEndTime { get; set; }
        
        public Byte[]? Qr { get; set; }

        public string? Requirement { get; set; }
    }

    public class ResultEmployeeReservation
    { 
        public int EmployeeReservationsId { get; set; }

        public string UserId { get; set; }

        public int ClientCompanyEmployeesId { get; set; }

        public string UserName { get; set; }

        public string ClientCompanyEmployeesName { get; set; }

        public byte[] Qr { get; set; }

        public string CompleteFlag { get; set; }

        public DateTime ReservationsTime { get; set; }

        public string Requirement { get; set; }
    }
}
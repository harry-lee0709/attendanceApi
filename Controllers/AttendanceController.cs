using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AttendanceMonitor.Models;
using Microsoft.Extensions.Configuration;

namespace AttendanceMonitor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly AttendanceMonitorContext _context;

        public AttendanceController(AttendanceMonitorContext context)
        {
            _context = context;
        }

        // GET: api/Attendance
        [HttpGet]
        public IEnumerable<AttendanceItem> GetAttendanceItem()
        {
            return _context.AttendanceItem;
        }

        // GET: api/Attendance/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttendanceItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var attendanceItem = await _context.AttendanceItem.FindAsync(id);

            if (attendanceItem == null)
            {
                return NotFound();
            }

            return Ok(attendanceItem);
        }

        // PUT: api/Attendance/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttendanceItem([FromRoute] int id, [FromBody] AttendanceItem attendanceItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attendanceItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(attendanceItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttendanceItemExists(id))
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

        // POST: api/Attendance
        [HttpPost]
        public async Task<IActionResult> PostAttendanceItem([FromBody] AttendanceItem attendanceItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AttendanceItem.Add(attendanceItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAttendanceItem", new { id = attendanceItem.Id }, attendanceItem);
        }

        // DELETE: api/Attendance/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendanceItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var attendanceItem = await _context.AttendanceItem.FindAsync(id);
            if (attendanceItem == null)
            {
                return NotFound();
            }

            _context.AttendanceItem.Remove(attendanceItem);
            await _context.SaveChangesAsync();

            return Ok(attendanceItem);
        }

        private bool AttendanceItemExists(int id)
        {
            return _context.AttendanceItem.Any(e => e.Id == id);
        }

        // GET: api/Attendance/Id
        [Route("id")]
        [HttpGet]
        public async Task<List<int>> GetId()
        {
            var attendance = (from m in _context.AttendanceItem
                         select m.Id).Distinct();

            var returned = await attendance.ToListAsync();

            return returned;
        }
    }
}
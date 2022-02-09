using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainTicketSales.Helpers;
using TrainTicketSales.Models.Entity;
using TrainTicketSales.ModelsViews;

namespace TrainTicketSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly DsvnContext _context;
        private readonly IDapper _dapper;

        public SeatsController(DsvnContext context, IDapper dapper)
        {
            _dapper = dapper;
            _context = context;
        }

        // GET: api/Seats
        [HttpGet]
        public async Task<IEnumerable<SeatViewModel>> GetSeatByCabin(long cabinId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@cabinId", cabinId);
            return await _dapper.GetMultiByStoreProcedureAsync<SeatViewModel>("Seat_GetByCabin", parameters, commandType: CommandType.StoredProcedure);
        }

        // GET: api/Seats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Seat>> GetSeat(long id)
        {
            var seat = await _context.Seat.FindAsync(id);

            if (seat == null)
            {
                return NotFound();
            }

            return seat;
        }

        // PUT: api/Seats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeat(long id, Seat seat)
        {
            if (id != seat.Id)
            {
                return BadRequest();
            }

            _context.Entry(seat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeatExists(id))
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

        // POST: api/Seats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Seat>> PostSeat(Seat seat)
        {
            _context.Seat.Add(seat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSeat", new { id = seat.Id }, seat);
        }

        // DELETE: api/Seats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeat(long id)
        {
            var seat = await _context.Seat.FindAsync(id);
            if (seat == null)
            {
                return NotFound();
            }

            _context.Seat.Remove(seat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeatExists(long id)
        {
            return _context.Seat.Any(e => e.Id == id);
        }
    }
}

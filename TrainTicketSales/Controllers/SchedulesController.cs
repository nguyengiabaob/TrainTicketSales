using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TrainTicketSales.Models.Entity;
using TrainTicketSales.ModelsViews;

namespace TrainTicketSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly DsvnContext _context;

        public SchedulesController(DsvnContext context)
        {
            _context = context;
        }

        // GET: api/Schedules
        [HttpGet]
        public async Task<ScheduleViewModel> GetSchedule(long StationBegin, long StationEnd, DateTime date)
        {
            List< TrainViewModel> TrainList = new List<TrainViewModel>();   
            var val= await _context.Schedule.Where(x=>x.BeginStationId==StationBegin && x.EndStationId ==StationEnd && x.DateBegin==date).ToListAsync();
            foreach (var item in val)
            {
                var train= _context.Train.Where(x=>x.Code==item.TrainCode).Include(x=>x.Cabin).ToList()[0];
                TrainViewModel abc= new TrainViewModel();   
                abc.Code=train.Code;    
                abc.Name=train.Name;
                abc.Des=train.Des;
                abc.Cabin= JsonConvert.DeserializeObject<IEnumerable<CabinViewModel>>(JsonConvert.SerializeObject(train.Cabin)) ;
                TrainList.Add(abc);
            }
            //var result = JsonConvert.DeserializeObject<IEnumerable<ScheduleViewModel>>(JsonConvert.SerializeObject(val));
            return new ScheduleViewModel(){ TrainsList=TrainList };
        }

        // GET: api/Schedules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetSchedule(long id)
        {
            var schedule = await _context.Schedule.FindAsync(id);

            if (schedule == null)
            {
                return NotFound();
            }

            return schedule;
        }

        // PUT: api/Schedules/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchedule(long id, Schedule schedule)
        {
            if (id != schedule.Id)
            {
                return BadRequest();
            }

            _context.Entry(schedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleExists(id))
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

        // POST: api/Schedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Schedule>> PostSchedule(Schedule schedule)
        {
            _context.Schedule.Add(schedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchedule", new { id = schedule.Id }, schedule);
        }

        // DELETE: api/Schedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(long id)
        {
            var schedule = await _context.Schedule.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }

            _context.Schedule.Remove(schedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScheduleExists(long id)
        {
            return _context.Schedule.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainTicketSales.Models.Entity;
using TrainTicketSales.ModelsViews;

namespace TrainTicketSales.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SchedulesController : Controller
    {
        private readonly DsvnContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SchedulesController(DsvnContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Admin/Schedules
        public async Task<IActionResult> Index()
        {
            string token = HttpContext.Session.GetString("Token");
            if (token == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var dsvnContext = _context.Schedule.Include(s => s.BeginStation).Include(s => s.EndStation).Include(s => s.TrainCodeNavigation);
            return View(await dsvnContext.ToListAsync());
        }

        // GET: Admin/Schedules/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .Include(s => s.BeginStation)
                .Include(s => s.EndStation)
                .Include(s => s.TrainCodeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Admin/Schedules/Create
        public IActionResult Create()
        {
            ViewData["BeginStationId"] = new SelectList(_context.Station, "Id", "Code");
            ViewData["EndStationId"] = new SelectList(_context.Station, "Id", "Code");
            ViewData["TrainCode"] = new SelectList(_context.Train, "Code", "Code");
            ScheduleAdminViewModel scheduleAdminViewModel = new ScheduleAdminViewModel();
            scheduleAdminViewModel.BeginStation = _context.Station.ToList();
            scheduleAdminViewModel.EndStation = _context.Station.ToList();
            return View();

        }

        // POST: Admin/Schedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> Create([FromBody] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                string domain = _httpContextAccessor.HttpContext.Request.Host.Value;
                string scheme = _httpContextAccessor.HttpContext.Request.Scheme;
                string delimiter = System.Uri.SchemeDelimiter;
                string fullDomainToUse = scheme + delimiter + domain;
                return Json(new { status = true, result = fullDomainToUse + "/Admin/Schedules/Index" });
            }
            return Json(new { status = false, result =  "/Admin/Home/Login" });

        }

        // GET: Admin/Schedules/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            ViewData["BeginStationId"] = new SelectList(_context.Station, "Id", "Code", schedule.BeginStationId);
            ViewData["EndStationId"] = new SelectList(_context.Station, "Id", "Code", schedule.EndStationId);
            ViewData["TrainCode"] = new SelectList(_context.Train, "Code", "Code", schedule.TrainCode);
            return View(schedule);
        }
        [HttpGet]
        public async Task<JsonResult> GetStation()
        {
            string token = HttpContext.Session.GetString("Token");

            if (token == null)
            {

                return null;
            }
            var result = await _context.Station.ToListAsync();

            return Json(new { status = true, result = result });

        }
        [HttpGet]
        public async Task<JsonResult> GetTrain()
        {
            string token = HttpContext.Session.GetString("Token");

            if (token == null)
            {

                return null;
            }
            var result = await _context.Train.ToListAsync();

            return Json(new { status = true, result = result });

        }
        // POST: Admin/Schedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public async Task<IActionResult> Edit(long id, [Bind("Id,BeginStationId,EndStationId,TrainCode,DateBegin,DateEnd")] Schedule schedule)
        {
            if (id != schedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BeginStationId"] = new SelectList(_context.Station, "Id", "Code", schedule.BeginStationId);
            ViewData["EndStationId"] = new SelectList(_context.Station, "Id", "Code", schedule.EndStationId);
            ViewData["TrainCode"] = new SelectList(_context.Train, "Code", "Code", schedule.TrainCode);
            return View(schedule);
        }

        // GET: Admin/Schedules/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .Include(s => s.BeginStation)
                .Include(s => s.EndStation)
                .Include(s => s.TrainCodeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }
            return View(schedule);
        }

        // POST: Admin/Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var schedule = await _context.Schedule.FindAsync(id);
            _context.Schedule.Remove(schedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(long id)
        {
            return _context.Schedule.Any(e => e.Id == id);
        }
    }
}

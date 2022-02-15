using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainTicketSales.Models.Entity;

namespace TrainTicketSales.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SeatDetailsController : Controller
    {
        private readonly DsvnContext _context;

        public SeatDetailsController(DsvnContext context)
        {
            _context = context;
        }

        // GET: Admin/SeatDetails
        public async Task<IActionResult> Index()
        {
            var dsvnContext = _context.SeatDetail.Include(s => s.Schedule).Include(s => s.Seat);
            return View(await dsvnContext.ToListAsync());
        }

        // GET: Admin/SeatDetails/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seatDetail = await _context.SeatDetail
                .Include(s => s.Schedule)
                .Include(s => s.Seat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seatDetail == null)
            {
                return NotFound();
            }

            return View(seatDetail);
        }

        // GET: Admin/SeatDetails/Create
        public IActionResult Create()
        {
            ViewData["ScheduleId"] = new SelectList(_context.Schedule, "Id", "Id");
            ViewData["SeatId"] = new SelectList(_context.Seat, "Id", "Id");
            return View();
        }

        // POST: Admin/SeatDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ScheduleId,SeatId,Price,Status")] SeatDetail seatDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seatDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ScheduleId"] = new SelectList(_context.Schedule, "Id", "Id", seatDetail.ScheduleId);
            ViewData["SeatId"] = new SelectList(_context.Seat, "Id", "Id", seatDetail.SeatId);
            return View(seatDetail);
        }

        // GET: Admin/SeatDetails/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seatDetail = await _context.SeatDetail.FindAsync(id);
            if (seatDetail == null)
            {
                return NotFound();
            }
            ViewData["ScheduleId"] = new SelectList(_context.Schedule, "Id", "Id", seatDetail.ScheduleId);
            ViewData["SeatId"] = new SelectList(_context.Seat, "Id", "Id", seatDetail.SeatId);
            return View(seatDetail);
        }

        // POST: Admin/SeatDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ScheduleId,SeatId,Price,Status")] SeatDetail seatDetail)
        {
            if (id != seatDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seatDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeatDetailExists(seatDetail.Id))
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
            ViewData["ScheduleId"] = new SelectList(_context.Schedule, "Id", "Id", seatDetail.ScheduleId);
            ViewData["SeatId"] = new SelectList(_context.Seat, "Id", "Id", seatDetail.SeatId);
            return View(seatDetail);
        }

        // GET: Admin/SeatDetails/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seatDetail = await _context.SeatDetail
                .Include(s => s.Schedule)
                .Include(s => s.Seat)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seatDetail == null)
            {
                return NotFound();
            }

            return View(seatDetail);
        }

        // POST: Admin/SeatDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var seatDetail = await _context.SeatDetail.FindAsync(id);
            _context.SeatDetail.Remove(seatDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeatDetailExists(long id)
        {
            return _context.SeatDetail.Any(e => e.Id == id);
        }
    }
}

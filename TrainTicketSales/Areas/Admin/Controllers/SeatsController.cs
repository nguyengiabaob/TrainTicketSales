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
    public class SeatsController : Controller
    {
        private readonly DsvnContext _context;

        public SeatsController(DsvnContext context)
        {
            _context = context;
        }

        // GET: Admin/Seats
        public async Task<IActionResult> Index()
        {
            var dsvnContext = _context.Seat.Include(s => s.Cabin).Include(s => s.FloorCodeNavigation).Include(s => s.SeatCategoryCodeNavigation);
            return View(await dsvnContext.ToListAsync());
        }

        // GET: Admin/Seats/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seat = await _context.Seat
                .Include(s => s.Cabin)
                .Include(s => s.FloorCodeNavigation)
                .Include(s => s.SeatCategoryCodeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seat == null)
            {
                return NotFound();
            }

            return View(seat);
        }

        // GET: Admin/Seats/Create
        public IActionResult Create()
        {
            ViewData["CabinId"] = new SelectList(_context.Cabin, "Id", "Id");
            ViewData["FloorCode"] = new SelectList(_context.Floor, "Code", "Code");
            ViewData["SeatCategoryCode"] = new SelectList(_context.SeatCategory, "Code", "Code");
            return View();
        }

        // POST: Admin/Seats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CabinId,SeatCategoryCode,FloorCode,Index")] Seat seat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CabinId"] = new SelectList(_context.Cabin, "Id", "Id", seat.CabinId);
            ViewData["FloorCode"] = new SelectList(_context.Floor, "Code", "Code", seat.FloorCode);
            ViewData["SeatCategoryCode"] = new SelectList(_context.SeatCategory, "Code", "Code", seat.SeatCategoryCode);
            return View(seat);
        }

        // GET: Admin/Seats/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seat = await _context.Seat.FindAsync(id);
            if (seat == null)
            {
                return NotFound();
            }
            ViewData["CabinId"] = new SelectList(_context.Cabin, "Id", "Id", seat.CabinId);
            ViewData["FloorCode"] = new SelectList(_context.Floor, "Code", "Code", seat.FloorCode);
            ViewData["SeatCategoryCode"] = new SelectList(_context.SeatCategory, "Code", "Code", seat.SeatCategoryCode);
            return View(seat);
        }

        // POST: Admin/Seats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,CabinId,SeatCategoryCode,FloorCode,Index")] Seat seat)
        {
            if (id != seat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeatExists(seat.Id))
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
            ViewData["CabinId"] = new SelectList(_context.Cabin, "Id", "Id", seat.CabinId);
            ViewData["FloorCode"] = new SelectList(_context.Floor, "Code", "Code", seat.FloorCode);
            ViewData["SeatCategoryCode"] = new SelectList(_context.SeatCategory, "Code", "Code", seat.SeatCategoryCode);
            return View(seat);
        }

        // GET: Admin/Seats/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seat = await _context.Seat
                .Include(s => s.Cabin)
                .Include(s => s.FloorCodeNavigation)
                .Include(s => s.SeatCategoryCodeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seat == null)
            {
                return NotFound();
            }

            return View(seat);
        }

        // POST: Admin/Seats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var seat = await _context.Seat.FindAsync(id);
            _context.Seat.Remove(seat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeatExists(long id)
        {
            return _context.Seat.Any(e => e.Id == id);
        }
    }
}

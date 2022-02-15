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
    public class TrainsController : Controller
    {
        private readonly DsvnContext _context;

        public TrainsController(DsvnContext context)
        {
            _context = context;
        }

        // GET: Admin/Trains
        public async Task<IActionResult> Index()
        {
            return View(await _context.Train.ToListAsync());
        }

        // GET: Admin/Trains/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var train = await _context.Train.Include(x=>x.Cabin)
                .FirstOrDefaultAsync(m => m.Code == id);
            if (train == null)
            {
                return NotFound();
            }

            return View(train);
        }

        // GET: Admin/Trains/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Trains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Code,Name,Des")] Train train)
        {
            if (ModelState.IsValid)
            {
                _context.Add(train);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(train);
        }

        // GET: Admin/Trains/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var train = await _context.Train.FindAsync(id);
            if (train == null)
            {
                return NotFound();
            }
            return View(train);
        }

        // POST: Admin/Trains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Code,Name,Des")] Train train)
        {
            if (id != train.Code)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(train);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainExists(train.Code))
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
            return View(train);
        }

        // GET: Admin/Trains/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var train = await _context.Train
                .FirstOrDefaultAsync(m => m.Code == id);
            if (train == null)
            {
                return NotFound();
            }

            return View(train);
        }

        // POST: Admin/Trains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var train = await _context.Train.FindAsync(id);
            _context.Train.Remove(train);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainExists(string id)
        {
            return _context.Train.Any(e => e.Code == id);
        }
    }
}

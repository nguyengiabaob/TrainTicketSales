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
    public class CabinsController : Controller
    {
        private readonly DsvnContext _context;

        public CabinsController(DsvnContext context)
        {
            _context = context;
        }

        // GET: Admin/Cabins
        public async Task<IActionResult> Index()
        {
            var dsvnContext = _context.Cabin.Include(c => c.CabinCategoryCodeNavigation).Include(c => c.TrainCodeNavigation);
            return View(await dsvnContext.ToListAsync());
        }

        // GET: Admin/Cabins/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cabin = await _context.Cabin
                .Include(c => c.CabinCategoryCodeNavigation)
                .Include(c => c.TrainCodeNavigation)
                .Include(c => c.Seat).ThenInclude(x=>x.FloorCodeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cabin == null)
            {
                return NotFound();
            }

            return View(cabin);
        }

        // GET: Admin/Cabins/Create
        public IActionResult Create()
        {
            ViewData["CabinCategoryCode"] = new SelectList(_context.CabinCategory, "Code", "Code");
            ViewData["TrainCode"] = new SelectList(_context.Train, "Code", "Code");
            return View();
        }

        // POST: Admin/Cabins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CabinCategoryCode,Index,TrainCode")] Cabin cabin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cabin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CabinCategoryCode"] = new SelectList(_context.CabinCategory, "Code", "Code", cabin.CabinCategoryCode);
            ViewData["TrainCode"] = new SelectList(_context.Train, "Code", "Code", cabin.TrainCode);
            return View(cabin);
        }

        // GET: Admin/Cabins/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cabin = await _context.Cabin.FindAsync(id);
            if (cabin == null)
            {
                return NotFound();
            }
            ViewData["CabinCategoryCode"] = new SelectList(_context.CabinCategory, "Code", "Code", cabin.CabinCategoryCode);
            ViewData["TrainCode"] = new SelectList(_context.Train, "Code", "Code", cabin.TrainCode);
            return View(cabin);
        }

        // POST: Admin/Cabins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,CabinCategoryCode,Index,TrainCode")] Cabin cabin)
        {
            if (id != cabin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cabin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CabinExists(cabin.Id))
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
            ViewData["CabinCategoryCode"] = new SelectList(_context.CabinCategory, "Code", "Code", cabin.CabinCategoryCode);
            ViewData["TrainCode"] = new SelectList(_context.Train, "Code", "Code", cabin.TrainCode);
            return View(cabin);
        }

        // GET: Admin/Cabins/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cabin = await _context.Cabin
                .Include(c => c.CabinCategoryCodeNavigation)
                .Include(c => c.TrainCodeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cabin == null)
            {
                return NotFound();
            }

            return View(cabin);
        }

        // POST: Admin/Cabins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var cabin = await _context.Cabin.FindAsync(id);
            _context.Cabin.Remove(cabin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CabinExists(long id)
        {
            return _context.Cabin.Any(e => e.Id == id);
        }
    }
}

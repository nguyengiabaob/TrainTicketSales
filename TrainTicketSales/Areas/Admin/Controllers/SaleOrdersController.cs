using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainTicketSales.Helpers;
using TrainTicketSales.Models.Entity;
using TrainTicketSales.ModelsViews;

namespace TrainTicketSales.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SaleOrdersController : Controller
    {
        private readonly DsvnContext _context;
        private readonly IDapper _dapper;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SaleOrdersController(DsvnContext context, IDapper dapper, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _dapper = dapper;
            _context = context;
            _hostingEnvironment = webHostEnvironment;
        }

        // GET: Admin/SaleOrders
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var model= await _context.SaleOrder.Include(x=>x.SaleOrderDetail).ToListAsync();
            //return Json(new { status = true, result = model });
            return View(await _context.SaleOrder.Include(x => x.SaleOrderDetail).ToListAsync());
            //return Json(new { status = true, result = model });
        }

        [HttpGet]
        public async Task<JsonResult> Index1()
        {

            string domain = _httpContextAccessor.HttpContext.Request.Host.Value;
            string scheme = _httpContextAccessor.HttpContext.Request.Scheme;
            string delimiter = System.Uri.SchemeDelimiter;
            string fullDomainToUse = scheme + delimiter + domain;
            var parameters = new DynamicParameters();
            parameters.Add("@url", fullDomainToUse + "/Admin/SaleOrders/Edit/");
            parameters.Add("@id", 0);
            var result = await _dapper.GetMultiByStoreProcedureAsync<SaleOrderViewModel>("SaleOrders_GetAll", parameters, commandType: CommandType.StoredProcedure);
           if(result.Count() > 0)
            {
                return Json(new { status = true, result = result });
            }
            return Json(new { status = false, result = "" });

        }

        // GET: Admin/SaleOrders/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleOrder = await _context.SaleOrder
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleOrder == null)
            {
                return NotFound();
            }

            return View(saleOrder);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveSaleOrderStatus(long id, int status)
        {
            var model = _context.SaleOrder.Where(x => x.Id == id).Include(x => x.SaleOrderDetail).FirstOrDefault();

            if (model != null)
            {
                model.Status = status;
                _context.Update(model);
                await _context.SaveChangesAsync();
                switch (status)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:

                        foreach (var item in model.SaleOrderDetail)
                        {
                            var seatDetail = _context.SeatDetail.Find(item.SeatDetailId);
                            if (seatDetail != null)
                            {
                                seatDetail.Status = 2;// dang giu cho
                                _context.Update(model);
                            }

                        }
                        break;
                    case 5:
                        foreach (var item in model.SaleOrderDetail)
                        {
                            var seatDetail = _context.SeatDetail.Find(item.SeatDetailId);
                            if (seatDetail != null)
                            {
                                seatDetail.Status = 1;// dang giu cho
                                _context.Update(model);
                            }

                        }
                        break;
                    case 6:
                    case 7:
                        foreach (var item in model.SaleOrderDetail)
                        {
                            var seatDetail = _context.SeatDetail.Find(item.SeatDetailId);
                            if (seatDetail != null)
                            {
                                seatDetail.Status = 0;// dang giu cho
                                _context.Update(model);
                            }

                        }
                        break;
                    default:
                        break;
                }
                await _context.SaveChangesAsync();
            }

            return View(model);
        }

        // GET: Admin/SaleOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/SaleOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,OrderDate,PhoneNumber,Email,IdentityCard")] SaleOrder saleOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saleOrder);
        }

        // GET: Admin/SaleOrders/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parameters = new DynamicParameters();
            parameters.Add("@url", "");
            parameters.Add("@id", id);
            var result = await _dapper.GetMultiByStoreProcedureAsync<SaleOrderViewModel>("SaleOrders_GetAll", parameters, commandType: CommandType.StoredProcedure);

            var parameters1 = new DynamicParameters();
            parameters1.Add("@id", id);
            result.ToList()[0].SaleOrderDetail = _dapper.GetMultiByStoreProcedure<SaleOrderDetailViewModel>("SaleOrderDetail_GetById", parameters1, commandType: CommandType.StoredProcedure);


            if (result == null)
            {
                return NotFound();
            }
            return View(result.ToList()[0]);
        }

        // POST: Admin/SaleOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,OrderDate,PhoneNumber,Email,IdentityCard")] SaleOrder saleOrder)
        {
            if (id != saleOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleOrderExists(saleOrder.Id))
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
            return View(saleOrder);
        }

        // GET: Admin/SaleOrders/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleOrder = await _context.SaleOrder
                .FirstOrDefaultAsync(m => m.Id == id);
            if (saleOrder == null)
            {
                return NotFound();
            }

            return View(saleOrder);
        }

        // POST: Admin/SaleOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var saleOrder = await _context.SaleOrder.FindAsync(id);
            _context.SaleOrder.Remove(saleOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleOrderExists(long id)
        {
            return _context.SaleOrder.Any(e => e.Id == id);
        }
    }
}

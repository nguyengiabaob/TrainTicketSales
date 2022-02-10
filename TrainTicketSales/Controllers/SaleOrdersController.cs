using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainTicketSales.Models.Entity;

namespace TrainTicketSales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleOrdersController : ControllerBase
    {
        private readonly DsvnContext _context;

        public SaleOrdersController(DsvnContext context)
        {
            _context = context;
        }

        // GET: api/SaleOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleOrder>>> GetSaleOrder()
        {
            return await _context.SaleOrder.Include(x=>x.SaleOrderDetail).ToListAsync();
        }

        // GET: api/SaleOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleOrder>> GetSaleOrder(long id)
        {
            var saleOrder = await _context.SaleOrder.Where(x=>x.Id==id).Include(x=>x.SaleOrderDetail).FirstOrDefaultAsync();

            if (saleOrder == null)
            {
                return NotFound();
            }

            return saleOrder;
        }

        // PUT: api/SaleOrders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaleOrder(long id, SaleOrder saleOrder)
        {
            if (id != saleOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(saleOrder).State = EntityState.Modified;
            foreach (var item in saleOrder.SaleOrderDetail)
            {
                if(item.Id >0)
                {
                    _context.SaleOrderDetail.Add(item);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleOrderExists(id))
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

        // POST: api/SaleOrders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SaleOrder>> PostSaleOrder(SaleOrder saleOrder)
        {
            _context.SaleOrder.Add(saleOrder);
            await _context.SaveChangesAsync();

            //var headId= saleOrder.Id;
            //foreach (var item in saleOrder.SaleOrderDetail)
            //{
            //    item.SaleOrderId = headId;  
            //    _context.SaleOrderDetail.Add(item); 
            //}
            //await _context.SaveChangesAsync();
            return CreatedAtAction("GetSaleOrder", new { id = saleOrder.Id }, saleOrder);
        }

        // DELETE: api/SaleOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaleOrder(long id)
        {
            var saleOrder = await _context.SaleOrder.FindAsync(id);
            if (saleOrder == null)
            {
                return NotFound();
            }

            _context.SaleOrder.Remove(saleOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaleOrderExists(long id)
        {
            return _context.SaleOrder.Any(e => e.Id == id);
        }
    }
}

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
    public class SaleOrderDetailsController : ControllerBase
    {
        private readonly DsvnContext _context;

        public SaleOrderDetailsController(DsvnContext context)
        {
            _context = context;
        }

        // GET: api/SaleOrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleOrderDetail>>> GetSaleOrderDetail()
        {
            return await _context.SaleOrderDetail.ToListAsync();
        }

        // GET: api/SaleOrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleOrderDetail>> GetSaleOrderDetail(long id)
        {
            var saleOrderDetail = await _context.SaleOrderDetail.FindAsync(id);

            if (saleOrderDetail == null)
            {
                return NotFound();
            }

            return saleOrderDetail;
        }

        // PUT: api/SaleOrderDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaleOrderDetail(long id, SaleOrderDetail saleOrderDetail)
        {
            if (id != saleOrderDetail.Id)
            {
                return BadRequest();
            }


            _context.Entry(saleOrderDetail).State = EntityState.Modified;
            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleOrderDetailExists(id))
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

        // POST: api/SaleOrderDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SaleOrderDetail>> PostSaleOrderDetail(SaleOrderDetail saleOrderDetail)
        {
            _context.SaleOrderDetail.Add(saleOrderDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSaleOrderDetail", new { id = saleOrderDetail.Id }, saleOrderDetail);
        }

        // DELETE: api/SaleOrderDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaleOrderDetail(long id)
        {
            var saleOrderDetail = await _context.SaleOrderDetail.FindAsync(id);
            if (saleOrderDetail == null)
            {
                return NotFound();
            }

            _context.SaleOrderDetail.Remove(saleOrderDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaleOrderDetailExists(long id)
        {
            return _context.SaleOrderDetail.Any(e => e.Id == id);
        }
    }
}

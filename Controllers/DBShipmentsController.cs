using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedShipping.Models;

namespace RedShipping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBShipmentsController : ControllerBase
    {
        private readonly redshippingDBContext _context;

        public DBShipmentsController(redshippingDBContext context)
        {
            _context = context;
        }

        // GET: api/DBShipments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DBShipment>>> GetShipments()
        {
            return await _context.Shipments.ToListAsync();
        }

        // GET: api/DBShipments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DBShipment>> GetDBShipment(int id)
        {
            var dBShipment = await _context.Shipments.FindAsync(id);

            if (dBShipment == null)
            {
                return NotFound();
            }

            return dBShipment;
        }

        // PUT: api/DBShipments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDBShipment(int id, DBShipment dBShipment)
        {
            if (id != dBShipment.ID)
            {
                return BadRequest();
            }

            _context.Entry(dBShipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DBShipmentExists(id))
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

        // POST: api/DBShipments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DBShipment>> PostDBShipment(DBShipment dBShipment)
        {
            _context.Shipments.Add(dBShipment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDBShipment", new { id = dBShipment.ID }, dBShipment);
        }

        // DELETE: api/DBShipments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DBShipment>> DeleteDBShipment(int id)
        {
            var dBShipment = await _context.Shipments.FindAsync(id);
            if (dBShipment == null)
            {
                return NotFound();
            }

            _context.Shipments.Remove(dBShipment);
            await _context.SaveChangesAsync();

            return dBShipment;
        }

        private bool DBShipmentExists(int id)
        {
            return _context.Shipments.Any(e => e.ID == id);
        }
    }
}

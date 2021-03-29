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
    public class DBShippersController : ControllerBase
    {
        private readonly redshippingDBContext _context;

        public DBShippersController(redshippingDBContext context)
        {
            _context = context;
        }

        // GET: api/DBShippers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DBShipper>>> GetShippers()
        {
            return await _context.Shippers.ToListAsync();
        }

        // GET: api/DBShippers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DBShipper>> GetDBShipper(int id)
        {
            var dBShipper = await _context.Shippers.FindAsync(id);

            if (dBShipper == null)
            {
                return NotFound();
            }

            return dBShipper;
        }

        // PUT: api/DBShippers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDBShipper(int id, DBShipper dBShipper)
        {
            if (id != dBShipper.ID)
            {
                return BadRequest();
            }

            _context.Entry(dBShipper).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DBShipperExists(id))
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

        // POST: api/DBShippers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DBShipper>> PostDBShipper(DBShipper dBShipper)
        {
            _context.Shippers.Add(dBShipper);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDBShipper", new { id = dBShipper.ID }, dBShipper);
        }

        // DELETE: api/DBShippers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DBShipper>> DeleteDBShipper(int id)
        {
            var dBShipper = await _context.Shippers.FindAsync(id);
            if (dBShipper == null)
            {
                return NotFound();
            }

            _context.Shippers.Remove(dBShipper);
            await _context.SaveChangesAsync();

            return dBShipper;
        }

        private bool DBShipperExists(int id)
        {
            return _context.Shippers.Any(e => e.ID == id);
        }
    }
}

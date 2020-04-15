using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoozeApi.Models;

namespace BoozeApi.Controllers
{
    [Route("api/BoozeItems")]
    [ApiController]
    public class BoozeItemsController : ControllerBase
    {
        private readonly BoozeContext _context;

        public BoozeItemsController(BoozeContext context)
        {
            _context = context;
        }

        // GET: api/BoozeItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoozeItem>>> GetBoozeItems(
            [FromQuery] string category, string source
        )
        {
            if (string.IsNullOrWhiteSpace(category) && string.IsNullOrWhiteSpace(source))
            {
                return await _context.BoozeItems.ToListAsync();
            }

            var collection = _context.BoozeItems as IQueryable<BoozeItem>;
            
            if(!string.IsNullOrWhiteSpace(category))
            {
                category = category.Trim();
                collection = _context.BoozeItems.Where(a => a.Category == category);
            }
            if(!string.IsNullOrWhiteSpace(source)) {
                source = source.Trim();
                collection = _context.BoozeItems.Where(a => a.Source == source);
            }

            return await collection.ToListAsync();
        }

        // GET: api/BoozeItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoozeItem>> GetBoozeItem(Guid id)
        {
            var boozeItem = await _context.BoozeItems.FindAsync(id);

            if (boozeItem == null)
            {
                return NotFound();
            }

            return boozeItem;
        }

        // PUT: api/BoozeItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoozeItem(Guid id, BoozeItem boozeItem)
        {
            _context.Entry(boozeItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoozeItemExists(id))
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

        // POST: api/BoozeItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BoozeItem>> PostBoozeItem(BoozeItem boozeItem)
        {
            _context.BoozeItems.Add(boozeItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoozeItem", new { id = Guid.NewGuid() }, boozeItem);
        }

        // DELETE: api/BoozeItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BoozeItem>> DeleteBoozeItem(Guid id)
        {
            var boozeItem = await _context.BoozeItems.FindAsync(id);
            if (boozeItem == null)
            {
                return NotFound();
            }

            _context.BoozeItems.Remove(boozeItem);
            await _context.SaveChangesAsync();

            return boozeItem;
        }

        private bool BoozeItemExists(Guid id)
        {
            return _context.BoozeItems.Any(e => e.id == id);
        }
    }
}

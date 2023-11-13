using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using firstApi;
using firstApi.Models;

namespace firstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public LawsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Laws
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Law>>> GetLaws()
        {
          if (_context.Laws == null)
          {
              return NotFound();
          }
            return await _context.Laws.ToListAsync();
        }

        // GET: api/Laws/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Law>> GetLaw(Guid id)
        {
          if (_context.Laws == null)
          {
              return NotFound();
          }
            var law = await _context.Laws.FindAsync(id);

            if (law == null)
            {
                return NotFound();
            }

            return law;
        }

        // PUT: api/Laws/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLaw(Guid id, Law law)
        {
            if (id != law.Id)
            {
                return BadRequest();
            }

            _context.Entry(law).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LawExists(id))
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

        // POST: api/Laws
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Law>> PostLaw(Law law)
        {
          if (_context.Laws == null)
          {
              return Problem("Entity set 'DatabaseContext.Laws'  is null.");
          }
            _context.Laws.Add(law);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLaw", new { id = law.Id }, law);
        }

        // DELETE: api/Laws/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLaw(Guid id)
        {
            if (_context.Laws == null)
            {
                return NotFound();
            }
            var law = await _context.Laws.FindAsync(id);
            if (law == null)
            {
                return NotFound();
            }

            _context.Laws.Remove(law);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LawExists(Guid id)
        {
            return (_context.Laws?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

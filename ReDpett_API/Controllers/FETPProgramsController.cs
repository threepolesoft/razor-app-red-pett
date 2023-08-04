using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReDpett_API.Modal;
using ReDpett_API.Service;

namespace ReDpett_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FETPProgramsController : ControllerBase
    {
        private readonly REcontext _context;

        public FETPProgramsController(REcontext context)
        {
            _context = context;
        }

        // GET: api/FETPPrograms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FETPProgram>>> GetFETPPrograms()
        {
          if (_context.FETPPrograms == null)
          {
              return NotFound();
          }
            return await _context.FETPPrograms.ToListAsync();
        }

        // GET: api/FETPPrograms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FETPProgram>> GetFETPProgram(int id)
        {
          if (_context.FETPPrograms == null)
          {
              return NotFound();
          }
            var fETPProgram = await _context.FETPPrograms.FindAsync(id);

            if (fETPProgram == null)
            {
                return NotFound();
            }

            return fETPProgram;
        }

        // PUT: api/FETPPrograms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFETPProgram(int id, FETPProgram fETPProgram)
        {
            if (id != fETPProgram.Id)
            {
                return BadRequest();
            }

            _context.Entry(fETPProgram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FETPProgramExists(id))
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

        // POST: api/FETPPrograms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FETPProgram>> PostFETPProgram(FETPProgram fETPProgram)
        {
          if (_context.FETPPrograms == null)
          {
              return Problem("Entity set 'REcontext.FETPPrograms'  is null.");
          }
            _context.FETPPrograms.Add(fETPProgram);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFETPProgram", new { id = fETPProgram.Id }, fETPProgram);
        }

        // DELETE: api/FETPPrograms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFETPProgram(int id)
        {
            if (_context.FETPPrograms == null)
            {
                return NotFound();
            }
            var fETPProgram = await _context.FETPPrograms.FindAsync(id);
            if (fETPProgram == null)
            {
                return NotFound();
            }

            _context.FETPPrograms.Remove(fETPProgram);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FETPProgramExists(int id)
        {
            return (_context.FETPPrograms?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

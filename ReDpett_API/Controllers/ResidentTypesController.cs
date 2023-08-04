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
    public class ResidentTypesController : ControllerBase
    {
        private readonly REcontext _context;

        public ResidentTypesController(REcontext context)
        {
            _context = context;
        }

        // GET: api/ResidentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResidentType>>> GetResidentTypes()
        {
          if (_context.ResidentTypes == null)
          {
              return NotFound();
          }
            return await _context.ResidentTypes.ToListAsync();
        }

        // GET: api/ResidentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResidentType>> GetResidentType(int id)
        {
          if (_context.ResidentTypes == null)
          {
              return NotFound();
          }
            var residentType = await _context.ResidentTypes.FindAsync(id);

            if (residentType == null)
            {
                return NotFound();
            }

            return residentType;
        }

        // PUT: api/ResidentTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResidentType(int id, ResidentType residentType)
        {
            if (id != residentType.Id)
            {
                return BadRequest();
            }

            _context.Entry(residentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidentTypeExists(id))
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

        // POST: api/ResidentTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResidentType>> PostResidentType(ResidentType residentType)
        {
          if (_context.ResidentTypes == null)
          {
              return Problem("Entity set 'REcontext.ResidentTypes'  is null.");
          }
            _context.ResidentTypes.Add(residentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResidentType", new { id = residentType.Id }, residentType);
        }

        // DELETE: api/ResidentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResidentType(int id)
        {
            if (_context.ResidentTypes == null)
            {
                return NotFound();
            }
            var residentType = await _context.ResidentTypes.FindAsync(id);
            if (residentType == null)
            {
                return NotFound();
            }

            _context.ResidentTypes.Remove(residentType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResidentTypeExists(int id)
        {
            return (_context.ResidentTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

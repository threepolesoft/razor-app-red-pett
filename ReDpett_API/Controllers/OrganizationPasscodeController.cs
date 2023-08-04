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
    public class OrganizationPasscodeController : ControllerBase
    {
        private readonly REcontext _context;

        public OrganizationPasscodeController(REcontext context)
        {
            _context = context;
        }

        // GET: api/OrganizationPasscode
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrganizationPasscode>>> GetOrganizationPasscode()
        {
          if (_context.OrganizationPasscode == null)
          {
              return NotFound();
          }
            return await _context.OrganizationPasscode.ToListAsync();
        }

        // GET: api/OrganizationPasscode/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizationPasscode>> GetOrganizationPasscode(int id)
        {
          if (_context.OrganizationPasscode == null)
          {
              return NotFound();
          }
            var organizationPasscode = await _context.OrganizationPasscode.FindAsync(id);

            if (organizationPasscode == null)
            {
                return NotFound();
            }

            return organizationPasscode;
        }

        // PUT: api/OrganizationPasscode/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganizationPasscode(int id, OrganizationPasscode organizationPasscode)
        {
            if (id != organizationPasscode.Id)
            {
                return BadRequest();
            }

            _context.Entry(organizationPasscode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationPasscodeExists(id))
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

        // POST: api/OrganizationPasscode
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrganizationPasscode>> PostOrganizationPasscode(OrganizationPasscode organizationPasscode)
        {
          if (_context.OrganizationPasscode == null)
          {
              return Problem("Entity set 'REcontext.OrganizationPasscode'  is null.");
          }
            organizationPasscode.Passcodes = PasscodeGenerator.CreateRandomPasswordWithRandomLength();
            _context.OrganizationPasscode.Add(organizationPasscode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganizationPasscode", new { id = organizationPasscode.Id }, organizationPasscode);
        }

        // DELETE: api/OrganizationPasscode/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizationPasscode(int id)
        {
            if (_context.OrganizationPasscode == null)
            {
                return NotFound();
            }
            var organizationPasscode = await _context.OrganizationPasscode.FindAsync(id);
            if (organizationPasscode == null)
            {
                return NotFound();
            }

            _context.OrganizationPasscode.Remove(organizationPasscode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrganizationPasscodeExists(int id)
        {
            return (_context.OrganizationPasscode?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

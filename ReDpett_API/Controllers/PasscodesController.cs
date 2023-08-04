using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using ReDpett_API.Modal;
using ReDpett_API.Service;

namespace ReDpett_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasscodesController : ControllerBase
    {
        private readonly REcontext _context;

        public PasscodesController(REcontext context)
        {
            _context = context;
        }

        // GET: api/Passcodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passcode>>> GetPasscodes()
        {
            return await _context.Passcodes.ToListAsync();
        }

        // GET: api/Passcodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passcode>> GetPasscode(int id)
        {
            var passcode = await _context.Passcodes.FindAsync(id);

            if (passcode == null)
            {
                return NotFound();
            }

            return passcode;
        }

        // PUT: api/Passcodes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPasscode(int id, Passcode passcode)
        {
            if (id != passcode.Id)
            {
                return BadRequest();
            }

            _context.Entry(passcode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasscodeExists(id))
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

        // POST: api/Passcodes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passcode>> PostPasscode(Passcode passcode)
        {
            //var checkIfPasscode = _context.Passcodes.FirstOrDefault(x => x.EmailAssociated == passcode.EmailAssociated);
            var checkIfPasscode = _context.Passcodes.Where(x => x.Country == passcode.Country
              && x.Program == passcode.Program
            ).FirstOrDefault();

            if (checkIfPasscode != null)
            {
                return Ok(new
                {
                    status = false,
                    message = "Passcode already created for selected country and program  \r\n\r\n." + checkIfPasscode.Passcodes,
                    Data = ""
                });


            }

            if (passcode.Passcodes != "string")
            {
       
                    _context.Passcodes.Add(passcode);
                    await _context.SaveChangesAsync();
                    //return CreatedAtAction("GetPasscode", new { id = passcode.Id }, passcode);
                    return Ok(new
                    {
                        status = true,
                        message = "Successfully Generated Passcode \r\n\r\n",
                        Data = passcode
                    });
                
            }
            else
            {
                passcode.Passcodes = PasscodeGenerator.CreateRandomPasswordWithRandomLength();
                _context.Passcodes.Add(passcode);
                await _context.SaveChangesAsync();
                //return CreatedAtAction("GetPasscode", new { id = passcode.Id }, passcode);
                return Ok(new
                {
                    status = true,
                    message = "Successfully Generated Passcode \r\n\r\n",
                    Data = passcode
                });
            }

        }

        // DELETE: api/Passcodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePasscode(int id)
        {
            var passcode = await _context.Passcodes.FindAsync(id);
            if (passcode == null)
            {
                return NotFound();
            }

            _context.Passcodes.Remove(passcode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PasscodeExists(int id)
        {
            return _context.Passcodes.Any(e => e.Id == id);
        }
    }
}

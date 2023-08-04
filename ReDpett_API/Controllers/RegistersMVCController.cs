using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using ReDpett_API.Migrations;
using ReDpett_API.Modal;
using ReDpett_API.Service;
using ReDpett_API.ViewModel;

namespace ReDpett_API.Controllers
{
    public class RegistersMVCController : Controller
    {
        private readonly REcontext _context;

        public RegistersMVCController(REcontext context)
        {
            _context = context;
        }

        // GET: RegistersMVC
        public async Task<IActionResult> Index()
        {
              return View(await _context.Registers.ToListAsync());
        }

        // GET: RegistersMVC/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Registers == null)
            {
                return NotFound();
            }

            var register = await _context.Registers
                .FirstOrDefaultAsync(m => m.RegisterID == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // GET: RegistersMVC/Create
        public IActionResult Create()
        {
            //RegisterViewModel m=new RegisterViewModel();
            ViewBag.COuntryList = new SelectList(_context.Country.ToList(), "CountryId", "CountryName");
            ViewBag.ROles= new SelectList(_context.ROles.ToList(), "RoleId", "RoleName");   
            ViewBag.Taskype= new SelectList(_context.ResidentTypes.ToList(), "ResidentTypesId", "ResidentTypesName"); 
            ViewBag.FETProgram= new SelectList(_context.FETPPrograms.ToList(), "FETPProgramsId", "FETPPrograms"); // ViewBag.COuntryList   ,ViewBag.ROles, ViewBag.Taskype,ViewBag.FETProgram
            return View();
        }

        // POST: RegistersMVC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegisterID,Name,LastName,Email,Password,CountryId,FETPProgramId,RoleId,Passcode")] Register register)
        {
            if (ModelState.IsValid)
            {
                _context.Add(register);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(register);
        }

        // GET: RegistersMVC/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Registers == null)
            {
                return NotFound();
            }

            var register = await _context.Registers.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }
            return View(register);
        }

        // POST: RegistersMVC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegisterID,Name,LastName,Email,Password,CountryId,FETPProgramId,RoleId,Passcode")] Register register)
        {
            if (id != register.RegisterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(register);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterExists(register.RegisterID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(register);
        }

        // GET: RegistersMVC/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Registers == null)
            {
                return NotFound();
            }

            var register = await _context.Registers
                .FirstOrDefaultAsync(m => m.RegisterID == id);
            if (register == null)
            {
                return NotFound();
            }

            return View(register);
        }

        // POST: RegistersMVC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Registers == null)
            {
                return Problem("Entity set 'REcontext.Registers'  is null.");
            }
            var register = await _context.Registers.FindAsync(id);
            if (register != null)
            {
                _context.Registers.Remove(register);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisterExists(int id)
        {
          return _context.Registers.Any(e => e.RegisterID == id);
        }
    }
}

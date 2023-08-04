using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
    public class CountriesController : ControllerBase
    {
        private readonly REcontext _context;
        private IDBService _db;
        public CountriesController(IDBService dBService, REcontext context)
        {
            _context = context;
            _db = dBService;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<List<codeCountryPicklist>> GetCountry()
        {
     
            DataTable dt = _db.GetCountries();
            List<codeCountryPicklist> modelList = new List<codeCountryPicklist>();
            foreach (DataRow row in dt.Rows)
            {
                codeCountryPicklist model = new codeCountryPicklist();

                foreach (DataColumn col in dt.Columns)
                {
                    PropertyInfo property = typeof(codeCountryPicklist).GetProperty(col.ColumnName);
                    if (property != null && row[col] != DBNull.Value)
                    {
                        property.SetValue(model, Convert.ChangeType(row[col], property.PropertyType));
                    }
                }
                modelList.Add(model);
            }
            return modelList;
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
          if (_context.Country == null)
          {
              return NotFound();
          }
            var country = await _context.Country.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
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

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
          if (_context.Country == null)
          {
              return Problem("Entity set 'REcontext.Country'  is null.");
          }
            _context.Country.Add(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            if (_context.Country == null)
            {
                return NotFound();
            }
            var country = await _context.Country.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Country.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return (_context.Country?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

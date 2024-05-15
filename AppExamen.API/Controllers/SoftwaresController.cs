using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppExamen.Entidades;

namespace AppExamen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwaresController : ControllerBase
    {
        private readonly DbContext _context;

        public SoftwaresController(DbContext context)
        {
            _context = context;
        }

        // GET: api/Softwares
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Software>>> GetSoftware()
        {
            return await _context.Softwares.ToListAsync();
        }

        // GET: api/Softwares/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Software>> GetSoftware(int id)
        {
            var software = await _context.Softwares
                                        .Include(s => s.Computadora)
                                        .Where(e => e.Id == id)
                                        .FirstOrDefaultAsync();

            if (software == null)
            {
                return NotFound();
            }

            return software;
        }




        // PUT: api/Softwares/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoftware(int id, Software software)
        {
            if (id != software.Id)
            {
                return BadRequest();
            }

            _context.Entry(software).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoftwareExists(id))
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

        // POST: api/Softwares
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Software>> PostSoftware(Software software)
        {
            _context.Softwares.Add(software);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSoftware", new { id = software.Id }, software);
        }

        // DELETE: api/Softwares/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoftware(int id)
        {
            var software = await _context.Softwares.FindAsync(id);
            if (software == null)
            {
                return NotFound();
            }

            _context.Softwares.Remove(software);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoftwareExists(int id)
        {
            return _context.Softwares.Any(e => e.Id == id);
        }
    }
}

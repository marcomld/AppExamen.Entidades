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
    public class ComputadorasController : ControllerBase
    {
        private readonly DbContext _context;

        public ComputadorasController(DbContext context)
        {
            _context = context;
        }

        // GET: api/Computadoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Computadora>>> GetComputadora()
        {
            return await _context.Computadoras.ToListAsync();
        }

        // GET: api/Computadoras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Computadora>> GetComputadora(int id)
        {
            var computadora = await _context.Computadoras.FindAsync(id);

            if (computadora == null)
            {
                return NotFound();
            }

            return computadora;
        }

        // PUT: api/Computadoras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComputadora(int id, Computadora computadora)
        {
            if (id != computadora.Id)
            {
                return BadRequest();
            }

            _context.Entry(computadora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComputadoraExists(id))
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

        // POST: api/Computadoras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Computadora>> PostComputadora(Computadora computadora)
        {
            _context.Computadoras.Add(computadora);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComputadora", new { id = computadora.Id }, computadora);
        }

        // DELETE: api/Computadoras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComputadora(int id)
        {
            var computadora = await _context.Computadoras.FindAsync(id);
            if (computadora == null)
            {
                return NotFound();
            }

            _context.Computadoras.Remove(computadora);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComputadoraExists(int id)
        {
            return _context.Computadoras.Any(e => e.Id == id);
        }
    }
}

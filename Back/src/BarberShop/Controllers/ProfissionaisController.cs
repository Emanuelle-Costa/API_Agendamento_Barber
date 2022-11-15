using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BarberShop.Data;
using BarberShop.Models;

namespace BarberShop.Controllers
{
    [Route("api/[controller]")]
    public class ProfissionaisController : Controller
    {
      private readonly ContextoBanco _context;

        public ProfissionaisController(ContextoBanco context)
        {
            _context = context;
        }

        // GET: api/profissional
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profissional>>> GetProfissional()
        {
            return await _context.Profissionais.ToListAsync();
        }

        // GET: api/Profissional/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profissional>> GetProfissional(Guid id)
        {
            var profissional = await _context.Profissionais.FindAsync(id);

            if (profissional == null)
            {
                return NotFound();
            }

            return profissional;
        }

        // PUT: api/Profissional/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfissional(Guid id, Profissional profissional)
        {
            if (id != profissional.Id)
            {
                return BadRequest();
            }

            _context.Entry(profissional).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfissionalExists(id))
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

        // POST: api/Profissional
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Profissional>> PostProfissional(Profissional profissional)
        {
            _context.Profissionais.Add(profissional);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfissional", new { id = profissional.Id }, profissional);
        }

        // DELETE: api/Profissional/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfissional(Guid id)
        {
            var profissional = await _context.Profissionais.FindAsync(id);
            if (profissional == null)
            {
                return NotFound();
            }

            _context.Profissionais.Remove(profissional);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfissionalExists(Guid id)
        {
            return _context.Profissionais.Any(e => e.Id == id);
        }
    }
}
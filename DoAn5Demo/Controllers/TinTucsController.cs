using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoAn5Demo.Models;

namespace DoAn5Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TinTucsController : ControllerBase
    {
        private readonly doan5Context _context;

        public TinTucsController(doan5Context context)
        {
            _context = context;
        }

        // GET: api/TinTucs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TinTuc>>> GetTinTuc()
        {
            return await _context.TinTuc.ToListAsync();
        }

        // GET: api/TinTucs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TinTuc>> GetTinTuc(int id)
        {
            var tinTuc = await _context.TinTuc.FindAsync(id);

            if (tinTuc == null)
            {
                return NotFound();
            }

            return tinTuc;
        }

        // PUT: api/TinTucs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTinTuc(int id, TinTuc tinTuc)
        {
            if (id != tinTuc.Id)
            {
                return BadRequest();
            }

            _context.Entry(tinTuc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TinTucExists(id))
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

        // POST: api/TinTucs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TinTuc>> PostTinTuc(TinTuc tinTuc)
        {
            _context.TinTuc.Add(tinTuc);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TinTucExists(tinTuc.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTinTuc", new { id = tinTuc.Id }, tinTuc);
        }

        // DELETE: api/TinTucs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TinTuc>> DeleteTinTuc(int id)
        {
            var tinTuc = await _context.TinTuc.FindAsync(id);
            if (tinTuc == null)
            {
                return NotFound();
            }

            _context.TinTuc.Remove(tinTuc);
            await _context.SaveChangesAsync();

            return tinTuc;
        }

        private bool TinTucExists(int id)
        {
            return _context.TinTuc.Any(e => e.Id == id);
        }
    }
}

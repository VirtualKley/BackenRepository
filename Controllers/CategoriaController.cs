using BackendRepository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AplicationDbContext _ctx;

        public CategoriaController(AplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TBCategoria>>> GetCategoria()
        {
            return await _ctx.TBCategoria.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<TBCategoria>> PostCategoria(TBCategoria categoria)
        {
            _ctx.TBCategoria.Add(categoria);
            await _ctx.SaveChangesAsync();
            return categoria;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, TBCategoria categoria)
        {
            if (categoria.id != id) return BadRequest();
            var _categoria = await _ctx.TBCategoria.FindAsync(categoria.id);
            if (_categoria == null) return BadRequest();

            _categoria.nombre = categoria.nombre;

            await _ctx.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var _categoria = await _ctx.TBCategoria.FindAsync(id);
            if (_categoria == null) return BadRequest();

            _ctx.TBCategoria.Remove(_categoria);
            await _ctx.SaveChangesAsync();

            return StatusCode(200);
        }
    }
}

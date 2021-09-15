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
    public class MarcaController : ControllerBase
    {
        private readonly AplicationDbContext _ctx;

        public MarcaController(AplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TBMarca>>> GetMarca()
        {
            return await _ctx.TBMarca.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostMarca(TBMarca marca)
        {
            await _ctx.TBMarca.AddAsync(marca);
            await _ctx.SaveChangesAsync();

            return StatusCode(200);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarca(int id, TBMarca marca)
        {
            if (marca.id != id) return BadRequest();
            var _marca = await _ctx.TBMarca.FindAsync(marca.id);
            if (_marca.id != id) return BadRequest();

            _marca.nombre = marca.nombre;

            await _ctx.SaveChangesAsync();

            return StatusCode(200);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarca(int id)
        {
            var _marca = await _ctx.TBMarca.FindAsync(id);
            if (_marca == null) return NotFound();

            _ctx.TBMarca.Remove(_marca);

            await _ctx.SaveChangesAsync();

            return StatusCode(200);
        }
    }
}

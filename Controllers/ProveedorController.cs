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
    public class ProveedorController : ControllerBase
    {
        private readonly AplicationDbContext _ctx;

        public ProveedorController(AplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TBProveedor>>> GetProveedor()
        {
            return await _ctx.TBProveedor.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> PostProveedor(TBProveedor proveedor)
        {
            await _ctx.TBProveedor.AddAsync(proveedor);
            await _ctx.SaveChangesAsync();

            return StatusCode(200);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedor(int id, TBProveedor proveedor)
        {
            if (proveedor.id != id) return BadRequest();
            var _proveedor = await _ctx.TBProveedor.FindAsync(id);
            if (_proveedor == null) return BadRequest();

            _proveedor.nombre = proveedor.nombre;

            await _ctx.SaveChangesAsync();

            return StatusCode(200);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProveedor(int id)
        {
            var _proveedor = await _ctx.TBProveedor.FindAsync(id);
            if (_proveedor == null) return BadRequest();

            _ctx.TBProveedor.Remove(_proveedor);
            await _ctx.SaveChangesAsync();

            return StatusCode(200);
        }
    }
}

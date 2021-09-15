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
    public class ProductoController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public ProductoController(AplicationDbContext context)
        {
            _context = context;
        }

        //Get api/Producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TBProducto>>> GetProducto()
        {
            return await _context.TBProducto.Include("marca").Include("categoria").Include("proveedor").ToListAsync();
            //return await _context.TBProducto.FromSqlRaw($"exec SP_listar_productos ''").ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TBProducto>> GetProducto(int id)
        {
            var producto = await _context.TBProducto.FindAsync(id);
            if (producto == null) return NotFound();
            return producto;
        }

        [HttpPost]
        public async Task<ActionResult<TBProducto>> PostProducto(TBProducto producto)
        {
            _context.TBProducto.Add(producto);
            await _context.SaveChangesAsync();

            return producto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, TBProducto producto)
        {
            if (id != producto.Id) return BadRequest();
            _context.Entry(producto).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TBProducto>> DeleteProducto(int id)
        {
            var producto = await _context.TBProducto.FindAsync(id);
            if (producto == null) return NotFound();

            _context.TBProducto.Remove(producto);
            await _context.SaveChangesAsync();
            return producto;
        }
    }
}

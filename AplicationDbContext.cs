using BackendRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendRepository
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }

        public DbSet<TBCategoria> TBCategoria { get; set; }
        public DbSet<TBMarca> TBMarca { get; set; }
        public DbSet<TBProveedor> TBProveedor { get; set; }
        public DbSet<TBProducto> TBProducto { get; set; }
    }
}

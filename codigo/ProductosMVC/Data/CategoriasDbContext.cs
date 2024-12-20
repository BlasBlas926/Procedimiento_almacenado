using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductosMVC.Models;

namespace ProductosMVC.Data
{
    public class CategoriasDbContext:DbContext
    {
         public CategoriasDbContext (DbContextOptions<CategoriasDbContext> options)
            : base(options)
        {
        }

        public DbSet<Categorias> Categorias { get; set; } = default!;
    }
}
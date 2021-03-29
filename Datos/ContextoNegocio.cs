using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab0_1240319_1132718.Models;
using Microsoft.EntityFrameworkCore;
namespace Lab0_1240319_1132718.Datos
{
    public class ContextoNegocio : DbContext
    {
        public ContextoNegocio(DbContextOptions<ContextoNegocio>options) :base(options)
        {
        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().ToTable("Producto");
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
        }
    }
}

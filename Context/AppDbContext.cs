using Microsoft.EntityFrameworkCore;
using ORM.Models;

namespace ORM.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}

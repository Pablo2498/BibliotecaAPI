using BibliotecaAPI.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Repositorios.Contexto
{
    public class BibliotecaContexto : DbContext
    {
        public BibliotecaContexto(DbContextOptions<BibliotecaContexto> options) : base(options)
        {
            Database.EnsureCreated();
        }


        public DbSet<Libro> Libros { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("BibliotecaBD");
            }
        }
    }
}

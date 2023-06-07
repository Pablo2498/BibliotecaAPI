using BibliotecaAPI.Dominio.Entidades;
using BibliotecaAPI.Repositorios.Contexto;
using BibliotecaAPI.Repositorios.Interfaces;
using System.Linq;

namespace BibliotecaAPI.Repositorios
{
    public class RepositorioLibro : IRepositorioLibro
    {
        private readonly BibliotecaContexto bibliotecaContexto;

        public RepositorioLibro(BibliotecaContexto bibliotecaContexto)
        {
            this.bibliotecaContexto = bibliotecaContexto;
        }

        public Libro ObtenerPorIsbn(string isbn)
        {
            return ObtenerLibroEntidadPorIsbn(isbn);
        }

        public void Agregar(Libro libro)
        {
            bibliotecaContexto.Libros.Add(libro);
            bibliotecaContexto.SaveChanges();
        }

        public Libro ObtenerLibroEntidadPorIsbn(string isbn)
        {
            var libroEntidad = bibliotecaContexto.Libros.FirstOrDefault(libro => libro.Isbn == isbn);
            return libroEntidad;
        }
    }
}

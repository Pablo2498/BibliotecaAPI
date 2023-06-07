using BibliotecaAPI.Dominio.Entidades;
using BibliotecaAPI.Dominio.Servicios.Interfaces;
using BibliotecaAPI.Repositorios.Interfaces;

namespace BibliotecaAPI.Dominio.Servicios
{
    public class ServicioLibro : IServicioLibro
    {
        private readonly IRepositorioLibro repositorioLibro;

        public ServicioLibro(IRepositorioLibro repositorioLibro)
        {
            this.repositorioLibro = repositorioLibro;
        }

        public void Agregar(Libro libro)
        {
            repositorioLibro.Agregar(libro);
        }

        public Libro ObtenerPorIsbn(string isbn)
        {
            return repositorioLibro.ObtenerPorIsbn(isbn);
        }
    }
}

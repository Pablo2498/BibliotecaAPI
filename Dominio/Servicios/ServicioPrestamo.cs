using BibliotecaAPI.Dominio.Entidades;
using BibliotecaAPI.Dominio.Servicios.Interfaces;
using BibliotecaAPI.Repositorios.Interfaces;

namespace BibliotecaAPI.Dominio.Servicios
{
    public class ServicioPrestamo : IServicioPrestamo
    {
        private readonly IRepositorioPrestamo repositorioPrestamo;

        public ServicioPrestamo(IRepositorioPrestamo repositorioPrestamo)
        {
            this.repositorioPrestamo = repositorioPrestamo;
        }

        public void Agregar(Prestamo prestamo)
        {
            repositorioPrestamo.Agregar(prestamo);
        }

        public Prestamo Obtener(string isbn)
        {
            return repositorioPrestamo.Obtener(isbn);
        }

        public Libro ObtenerLibroPrestadoPorIsbn(string isbn)
        {
            return repositorioPrestamo.ObtenerLibroPrestadoPorIsbn(isbn);
        }
    }
}

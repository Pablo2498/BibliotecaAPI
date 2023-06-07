using BibliotecaAPI.Dominio.Entidades;

namespace BibliotecaAPI.Dominio.Servicios.Interfaces
{
    public interface IServicioPrestamo
    {
        Libro ObtenerLibroPrestadoPorIsbn(string isbn);

        void Agregar(Prestamo prestamo);

        Prestamo Obtener(string isbn);
    }
}

using BibliotecaAPI.Dominio.Entidades;

namespace BibliotecaAPI.Dominio.Servicios.Interfaces
{
    public interface IServicioLibro
    {
        Libro ObtenerPorIsbn(string isbn);

        void Agregar(Libro libro);
    }
}

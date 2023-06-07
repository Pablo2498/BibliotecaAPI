using BibliotecaAPI.Dominio.Entidades;

namespace BibliotecaAPI.Repositorios.Interfaces
{
    public interface IRepositorioLibro
    {
        Libro ObtenerPorIsbn(string isbn);

        void Agregar(Libro libro);
    }
}

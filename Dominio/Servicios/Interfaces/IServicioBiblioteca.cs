namespace BibliotecaAPI.Dominio.Servicios.Interfaces
{
    public interface IServicioBiblioteca
    {
        void Prestar(string isbn, string nombreUsuario);

        bool EsPrestado(string isbn);
    }
}

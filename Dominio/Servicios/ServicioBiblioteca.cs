using BibliotecaAPI.Dominio.Entidades;
using BibliotecaAPI.Dominio.Servicios.Interfaces;
using BibliotecaAPI.Repositorios.Interfaces;
using System;

namespace BibliotecaAPI.Dominio.Servicios
{
    public class ServicioBiblioteca : IServicioBiblioteca
    {
        public const string EL_LIBRO_NO_SE_ENCUENTRA_DISPONIBLE = "El libro no se encuentra disponible";
        public const string ISBN_PALINDROMO = "Los libros palíndromos solo se pueden utilizar en la biblioteca";
        public const int SUMA_MAXIMA_ISBN = 30;
        private IRepositorioLibro libroRepositorio;
        private IRepositorioPrestamo prestamoRepositorio;

        public ServicioBiblioteca(IRepositorioLibro libroRepositorio, IRepositorioPrestamo prestamoRepositorio)
        {
            this.libroRepositorio = libroRepositorio;
            this.prestamoRepositorio = prestamoRepositorio;
        }

        public void Prestar(string isbn, string nombreUsuario)
        {
            var libroAPrestar = libroRepositorio.ObtenerPorIsbn(isbn);
            var prestamoExistente = prestamoRepositorio.ObtenerLibroPrestadoPorIsbn(isbn);

            if (prestamoExistente != null)
            {
                throw new Exception(EL_LIBRO_NO_SE_ENCUENTRA_DISPONIBLE);
            }
            if (Validaciones.IsbnPalindromo(isbn))
            {
                throw new Exception(ISBN_PALINDROMO);
            }

            if (Validaciones.SumaIsbn(isbn) > SUMA_MAXIMA_ISBN)
            {
                DateTime fechaEntregaMaxima = Validaciones.FechaDeEntrega(DateTime.Now);
                Prestamo nuevoPrestamo = new Prestamo 
                { 
                    FechaSolicitud = DateTime.Now, 
                    Libro = libroAPrestar, 
                    FechaEntregaMaxima = fechaEntregaMaxima, 
                    NombreUsuario = nombreUsuario 
                };
                prestamoRepositorio.Agregar(nuevoPrestamo);
            }
            else
            {
                DateTime? fechaEntregaMaxima = null;
                Prestamo nuevoPrestamo = new Prestamo
                {
                    FechaSolicitud = DateTime.Now,
                    Libro = libroAPrestar,
                    FechaEntregaMaxima = fechaEntregaMaxima,
                    NombreUsuario = nombreUsuario
                };
                prestamoRepositorio.Agregar(nuevoPrestamo);
            }
        }

        public bool EsPrestado(string isbn)
        {
            var libroExistente = prestamoRepositorio.ObtenerLibroPrestadoPorIsbn(isbn);
            if (libroExistente == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

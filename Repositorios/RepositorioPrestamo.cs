using BibliotecaAPI.Dominio.Entidades;
using BibliotecaAPI.Repositorios.Contexto;
using BibliotecaAPI.Repositorios.Interfaces;
using System.Linq;

namespace BibliotecaAPI.Repositorios
{
    public class RepositorioPrestamo : IRepositorioPrestamo
    {
        private readonly BibliotecaContexto bibliotecaContexto;

        public RepositorioPrestamo(BibliotecaContexto bibliotecaContexto)
        {
            this.bibliotecaContexto = bibliotecaContexto;
        }

        public void Agregar(Prestamo prestamo)
        {
            bibliotecaContexto.Prestamos.Add(prestamo);
            bibliotecaContexto.SaveChanges();

        }

        public Libro ObtenerLibroPrestadoPorIsbn(string isbn)
        {
            var prestamo = ObtenerPrestamoEntidadPorIsbn(isbn);

            if (prestamo == null)
            {
                return null;
            }
            else
            {
                return prestamo.Libro;
            }
        }

        private Prestamo ObtenerPrestamoEntidadPorIsbn(string isbn)
        {
            var resultList = bibliotecaContexto.Prestamos.Where(prestamo => prestamo.Libro.Isbn == isbn).ToList();

            return resultList.Count != 0 ? resultList.FirstOrDefault() : null;
        }

        public Prestamo Obtener(string isbn)
        {
            return ObtenerPrestamoEntidadPorIsbn(isbn);
        }
    }
}

using System;

namespace BibliotecaAPI.Dominio.Entidades
{
    public class Prestamo
    {
        public int Id { get; set; }
        public int LibroId { get; set; }
        public Libro Libro { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime? FechaEntregaMaxima { get; set; }
        public string NombreUsuario { get; set; }
    }
}

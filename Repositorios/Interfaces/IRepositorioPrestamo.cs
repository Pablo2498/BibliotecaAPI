﻿using BibliotecaAPI.Dominio.Entidades;

namespace BibliotecaAPI.Repositorios.Interfaces
{
    public interface IRepositorioPrestamo
    {
        Libro ObtenerLibroPrestadoPorIsbn(string isbn);

        void Agregar(Prestamo prestamo);

        Prestamo Obtener(string isbn);
    }
}

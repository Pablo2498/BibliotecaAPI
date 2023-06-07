using BibliotecaAPI.Dominio.Servicios.Interfaces;
using BibliotecaAPI.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BibliotecaController : ControllerBase
    {
        private readonly IServicioBiblioteca servicioBiblioteca;

        public BibliotecaController(IServicioBiblioteca servicioBiblioteca)
        {
            this.servicioBiblioteca = servicioBiblioteca;
        }

        [HttpGet("{isbn}")]
        public ActionResult<Respuesta> ValidarSiUnLibroEstaPrestado([FromRoute] string isbn)
        {
            var validacion = servicioBiblioteca.EsPrestado(isbn);

            if (validacion)
            {
                return new Respuesta { Mensaje = "El libro ya fue prestado" };
            }
            else
            {
                return new Respuesta { Mensaje = "El libro no existe o no ha sido prestado" };
            }
        }

        [HttpPost]
        public ActionResult<Respuesta> PrestarLibro([FromBody] PrestarLibro prestarLibro)
        {
            try
            {
                servicioBiblioteca.Prestar(prestarLibro.Isbn, prestarLibro.NombreUsuario);

                return new Respuesta { Mensaje = "Prestamo exitoso" };
            }
            catch (Exception ex)
            {
                return new Respuesta { Mensaje = ex.Message };
            }
        }
    }
}

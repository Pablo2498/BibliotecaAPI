using BibliotecaAPI.Dominio.Entidades;
using BibliotecaAPI.Dominio.Servicios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly IServicioLibro servicioLibro;

        public LibroController(IServicioLibro servicioLibro)
        {
            this.servicioLibro = servicioLibro;
        }

        [HttpPost]
        public IActionResult CrearLibro(Libro libro)
        {
            servicioLibro.Agregar(libro);
            return Created("", libro);
        }
    }
}

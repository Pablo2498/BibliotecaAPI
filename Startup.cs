using BibliotecaAPI.Dominio.Servicios;
using BibliotecaAPI.Dominio.Servicios.Interfaces;
using BibliotecaAPI.Repositorios;
using BibliotecaAPI.Repositorios.Contexto;
using BibliotecaAPI.Repositorios.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BibliotecaAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BibliotecaContexto>();
            services.AddTransient<IRepositorioLibro, RepositorioLibro>();
            services.AddTransient<IRepositorioPrestamo, RepositorioPrestamo>();
            services.AddTransient<IServicioLibro, ServicioLibro>();
            services.AddTransient<IServicioBiblioteca, ServicioBiblioteca>();
            services.AddTransient<IServicioPrestamo, ServicioPrestamo>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

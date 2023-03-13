using AdminUsuariosRoles.Aplicacion;
using AdminUsuariosRoles.Persistencia;
using AdminUsuariosRoles.RemoteInterface;
using AdminUsuariosRoles.RemoteSerivces;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUsuariosRoles
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container. 1133
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRolesService, RolesService>();
            services.AddControllers();
            services.AddDbContext<UsuarioContexto>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("ConexionDatabase"));
            });
            services.AddMediatR(typeof(apCrearUsuario.Insertar).Assembly);
            services.AddHttpClient("Roles", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:Roles"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

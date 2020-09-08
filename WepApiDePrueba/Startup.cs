using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WepApiDePrueba.Contexts;
using WepApiDePrueba.Entities;
using WepApiDePrueba.Models;

namespace WepApiDePrueba
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
            services.AddResponseCaching();
            services.AddAutoMapper(Configuration =>
            {
                Configuration.CreateMap<Author, AutorDto>();
                Configuration.CreateMap<AutorCreacionDto, Author>().ReverseMap();
                Configuration.CreateMap<Libros, LibrosDto>();
               
            },typeof(Startup));
          
            services.AddDbContext <ApplicationDbContexts>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //ARREGLAMOS LA RELACION CICLICA ENTRE  LIBROS Y AUTORES   (LIBROS n -> 1 autores)
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseResponseCaching();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

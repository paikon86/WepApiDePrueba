using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Azure.Identity;
using WepApiDePrueba.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;

namespace WepApiDePrueba
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args).Build();

            // Segunda forma de realizar las migraciones en IIS. (O donde sea)
            // En Azure no necesitamos este código por lo explicado en el curso
            using (var scope = webHost.Services.CreateScope())
            {
               var services = scope.ServiceProvider;
               var applicationDbContext = services.GetService<ApplicationDbContexts>();
                applicationDbContext.Database.Migrate();
            }

            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
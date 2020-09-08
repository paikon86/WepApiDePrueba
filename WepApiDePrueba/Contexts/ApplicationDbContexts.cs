using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepApiDePrueba.Entities;

namespace WepApiDePrueba.Contexts
{
    public class ApplicationDbContexts:DbContext
    {
        public ApplicationDbContexts(DbContextOptions<ApplicationDbContexts> options)
            :base(options)
        {

        }

        public DbSet<Author> Autores { get; set; }
        public DbSet<Libros> Libros{ get; set; }


    }
}

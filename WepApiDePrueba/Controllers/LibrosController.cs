using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepApiDePrueba.Contexts;
using WepApiDePrueba.Entities;
using WepApiDePrueba.Migrations;

namespace WepApiDePrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {

        private readonly ApplicationDbContexts context;
        public LibrosController(ApplicationDbContexts context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Libros>> Get()
        {
            return context.Libros.Include(x => x.Autor).ToList();
        }
        [HttpGet("{id}", Name = "ObtenerLibros")]
        public ActionResult<Libros> Get(int id)
        {
            var Libro = context.Libros.FirstOrDefault(x => x.Id == id);
            if (Libro == null)
            {
                return NotFound();
            }
            return Libro;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Libros libro)
        {
            context.Libros.Add(libro);
            context.SaveChanges();
            return new CreatedAtRouteResult("Obtenerlibros", new { id = libro.Id }, libro);
        }

        [HttpPut("{id}", Name = "ActualizarLibros")]
        public ActionResult<Libro> Put(int id, [FromBody] Libros value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }

            context.Entry(value).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();


        }

        [HttpDelete("{id}", Name = "BorraLibro")]
        public ActionResult<Libros> Delete(int id)
        {
            var Libro = context.Libros.FirstOrDefault(x => x.Id == id);
            if (Libro == null)
            {
                return NotFound();
            }

            context.Libros.Remove(Libro);
            context.SaveChanges();
            return Libro;


        }

    }
}

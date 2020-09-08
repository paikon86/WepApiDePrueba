using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepApiDePrueba.Contexts;
using WepApiDePrueba.Entities;
using WepApiDePrueba.Models;

namespace WepApiDePrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContexts context;
        private readonly IMapper mapper;
        public AutoresController(ApplicationDbContexts context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<AutorDto>> Get()
        {
            var autores = context.Autores.Include(x=> x.libros).ToList();
            List<AutorDto> listadoAutores = mapper.Map<List<AutorDto>>(autores);
            return listadoAutores;

        }
        [HttpGet("{id}" , Name = "ObtenerAutor")]
        public ActionResult<AutorDto> Get(int id)
        {
            var autor = context.Autores.FirstOrDefault(x => x.Id == id);
            if (autor ==null)
            {
                return NotFound();
            }

            var AutorDto = mapper.Map<AutorDto>(autor);



            return AutorDto;
        }

        [HttpPost]
        public ActionResult Post([FromBody] AutorCreacionDto autor)
        {
            var autorCreacion = mapper.Map<Author>(autor);
            context.Autores.Add(autorCreacion);
            string axel = "axe,";
            context.SaveChanges();
            var autorDto = mapper.Map<AutorDto>(autorCreacion);
            return new CreatedAtRouteResult("ObtenerAutor", new { id = autorDto.Id } , autorDto);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<AutorCreacionDto> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            var autoreLab = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);

            if (autoreLab == null)
            {
                return NotFound();
            }
            var autorDto = mapper.Map<AutorCreacionDto>(autoreLab);
            patchDocument.ApplyTo(autorDto, ModelState);


            mapper.Map(autorDto, autoreLab);
            var isValid = TryValidateModel(autoreLab);
            if (!isValid)
            {
                return BadRequest(ModelState);
            }

            await context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("{id}", Name = "ActualizarAutor")]
        public ActionResult<Author> Put(int id , [FromBody] Author value)
        {
          if (id !=value.Id)
          {
                return BadRequest();
          }

            context.Entry(value).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();


        }

        [HttpDelete("{id}", Name = "ActualizarAutor")]
        public ActionResult<Author> Delete(int id)
        {
            var autor = context.Autores.FirstOrDefault(x => x.Id == id);
            if (autor == null)
            {
                return NotFound();
            }

            context.Autores.Remove(autor);
            context.SaveChanges();
            return autor;


        }


    }
}

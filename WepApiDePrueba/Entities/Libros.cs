using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WepApiDePrueba.Entities
{
    public class Libros
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public int AutorId { get; set; }
        public Author Autor { get; set; }
    }
}

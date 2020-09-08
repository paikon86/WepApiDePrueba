using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WepApiDePrueba.Models
{
    public class AutorCreacionDto
    {
        [Required]
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }
}

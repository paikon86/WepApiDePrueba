﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WepApiDePrueba.Models;

namespace WepApiDePrueba.Models
{
    public class LibrosDto
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public int AutorId { get; set; }
        public AutorDto Autor { get; set; }
    }
}

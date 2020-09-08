using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WepApiDePrueba.Models
{
    public class AutorDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int CreditCard { get; set; }
        public string Url { get; set; }
        public List<LibrosDto> libros { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WepApiDePrueba.Helpers;

namespace WepApiDePrueba.Entities
{
    public class Author:IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
        [Range(18,120)]
        public int Edad { get; set; }
        public string identificador { get; set; }
        public int CreditCard { get; set; }
        [Url]
        public string Url { get; set; }
        public List<Libros> libros { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (! string.IsNullOrEmpty(Nombre))
            {
                var primeraLetra = Nombre[0].ToString();
                if (primeraLetra != primeraLetra.ToUpper())
                {
                    yield return new ValidationResult("La primera letra debe ser mayuscula" , new string[] { nameof(Nombre) });
                }
            }
        }
    }
}

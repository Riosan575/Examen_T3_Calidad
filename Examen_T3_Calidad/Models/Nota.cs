using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T3_Calidad.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Contendio { get; set; }
    }
}

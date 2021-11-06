using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen_T3_Calidad.Models
{
    public class NotaEtiqueta
    {
        public int Id { set; get; }
        public int EtiquetaId { set; get; }
        public int NotaId { set; get; }
        public Etiqueta Etiqueta { set; get; }
        public Nota Nota { set; get; }
    }
}

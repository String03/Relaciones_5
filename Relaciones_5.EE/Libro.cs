using Relaciones_5.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relaciones_5.EE
{
    public class Libro
    {
        [ClavePrimariaAttribute]
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha_reg { get; set; }
    }
}

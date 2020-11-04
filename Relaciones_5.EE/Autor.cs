using Relaciones_5.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relaciones_5.EE
{
    public class Autor
    {
        [ClavePrimariaAttribute]
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha_reg { get; set; }
    }
}

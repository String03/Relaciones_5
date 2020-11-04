using Relaciones_5.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relaciones_5.EE
{
    public class AutorLibro
    {
        [ClavePrimariaAttribute]
        public int Id { get; set; }
        public int Autor_fk { get; set; }
        public int Libro_fk { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relaciones_5.MPP.Mapeo
{
    public interface IMapeo
    {
        T Mapeo<T>(DataRow dataRow) where T: class,new();
    }
}

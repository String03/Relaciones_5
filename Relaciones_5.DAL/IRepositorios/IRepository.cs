using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relaciones_5.DAL.IRepositorios
{
    public interface IRepository<T>
    {
        void Alta(T entidad);
        void Baja(T entidad);
        void Modificacion(T entidad);
        IEnumerable<T> Listar();
    }
}

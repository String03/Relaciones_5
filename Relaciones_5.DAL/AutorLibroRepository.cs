using Relaciones_5.EE;
using Relaciones_5.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relaciones_5.DAL
{
    public class AutorLibroRepository : Repository<AutorLibro>
    {
        public override void Baja(AutorLibro entidad)
        {
            string query = "delete from AutorLibro where autor_fk = @autor_fk and libro_fk = @libro_fk";
            EjecutarQuery.ExecuteNonQuery(query, new Dictionary<string, object>
            {
                {
                    "@autor_fk",entidad.Autor_fk
                },
                {
                    "@libro_fk",entidad.Libro_fk
                }
            });
        }
    }
}

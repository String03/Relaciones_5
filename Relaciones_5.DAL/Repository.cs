using Relaciones_5.DAL.IRepositorios;
using Relaciones_5.Utilities;
using Relaciones_5.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Relaciones_5.DAL
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        public void Alta(T entidad)
        {
            string query = CrearQueryAlta(entidad);
            EjecutarQuery.ExecuteNonQuery(query);
        }

        private string CrearQueryAlta(T entidad)
        {
            string query = $"insert into {CrearTablas()} ({CrearColumnasSinId()}) values ({CrearParametrosAlta(entidad)})";
            return query;
        }

        private object CrearParametrosAlta(T entidad)
        {
            return string.Join(",",typeof(T).GetProperties()
                .Where(k => !TieneClavePrimariaAttributes(k))
                .Select(p => CrearExpresionDerecha(p, entidad))
                .ToList());
        }

        private object CrearExpresionDerecha(PropertyInfo p, T entidad)
        {
            object valor = p.GetValue(entidad);

            try
            {
                if (valor == null)
                {
                    return "NULL";
                }

                Type propertyType = valor.GetType();

                IEnumerable<Type> intPropertyType = new Type[]
                {
                    typeof(int),
                    typeof(short),
                    typeof(long)
                };

                IEnumerable<Type> decimalPropertyType = new Type[]
                {
                    typeof(decimal),
                    typeof(double),
                    typeof(float)
                };


                if (intPropertyType.Contains(propertyType))
                {
                    return Convert.ToInt64(valor).ToString("0", CultureInfo.InvariantCulture);
                }

                else if (decimalPropertyType.Contains(propertyType))
                {
                    return Convert.ToDecimal(valor).ToString("0.00", CultureInfo.InvariantCulture);
                }


                else if (valor.GetType() == typeof(DateTime))
                {
                    return "'" + ((DateTime)valor).ToString("s", CultureInfo.InvariantCulture) + "'";
                }

                else if (valor.GetType() == typeof(bool))
                {
                    return ((bool)valor) ? "1" : "0";
                }

                else
                {
                    return $"'{valor.ToString()}'";
                }

            }
            catch 
            {

                return "'0'";
            }
        }

        private object CrearColumnasSinId()
        {
            var resultado = new T();
            return string.Join(",", resultado.GetType()
                .GetProperties()
                .Where(k => !TieneClavePrimariaAttributes(k))
                .Select(c => c.Name)
                .ToList());
        }

        private bool TieneClavePrimariaAttributes(PropertyInfo k)
        {
            return k.GetCustomAttributes().Any(l => l.GetType() == typeof(ClavePrimariaAttribute));
        }

        public void Baja(T entidad)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Listar()
        {
            string query = CrearQueryListar();
            var ejecutar = EjecutarQuery.ExecuteSelectStatement<T>(query);
            return ejecutar;
        }

        private string CrearQueryListar()
        {
            string query = $"select {CrearColumnas()} from {CrearTablas()}";
            return query;
        }

        private object CrearColumnas()
        {
            var resultado = new T();
            return string.Join(",",resultado.GetType()
                .GetProperties()
                .Select(c => c.Name)
                .ToList());
        }

        private object CrearTablas()
        {
            return typeof(T).Name;
        }

        public void Modificacion(T entidad)
        {
            throw new NotImplementedException();
        }
    }
}

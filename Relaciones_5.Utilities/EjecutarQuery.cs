using Relaciones_5.MPP;
using Relaciones_5.MPP.Mapeo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relaciones_5.Utilities
{
    public static class EjecutarQuery
    {
        private static readonly string connectionStrings = ConfigurationManager.ConnectionStrings["AUTORLIBRODB"].ConnectionString;
        private static readonly IMapeo mapeo = new MapeoGenerico();


        public static void ExecuteNonQuery(string query, Dictionary<string,object> properties = null)
        {
            using (SqlConnection sqlConnection = CrearConexion())
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                PasarPropiedades(properties, sqlCommand);

                sqlCommand.ExecuteNonQuery();
            }
        }

        private static void PasarPropiedades(Dictionary<string, object> properties, SqlCommand sqlCommand)
        {
            if (properties != null)
            {
                foreach (var prop in properties)
                {
                    var propiedades = sqlCommand.CreateParameter();
                    propiedades.ParameterName = prop.Key;
                    propiedades.Value = prop.Value;
                    sqlCommand.Parameters.Add(propiedades);
                }
            }
        }

        public static IEnumerable<T> ExecuteSelectStatement<T>(string query, Dictionary<string,object> properties = null) where T: class, new()
        {
            using (SqlConnection sqlConnection = CrearConexion())
            {
                SqlCommand sqlCommand = new SqlCommand(query,sqlConnection);
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                PasarPropiedades(properties, sqlCommand);
                sqlDataAdapter.Fill(dataSet);

                return dataSet.Tables[0].Rows.Cast<DataRow>().Select(mapeo.Mapeo<T>).ToList();

            }
        }

        private static SqlConnection CrearConexion()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionStrings);
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}

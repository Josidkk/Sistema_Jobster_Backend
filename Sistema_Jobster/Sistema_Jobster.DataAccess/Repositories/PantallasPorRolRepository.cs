using Dapper;
using Microsoft.Data.SqlClient;
using Sistema_Jobster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Jobster.DataAccess.Repositories
{
    public class PantallasPorRolRepository
    {
        public RequestStatus Insert(tbPantallasPorRol item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Role_Id", item.Role_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Pant_Id", item.Pant_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@FechaCreacion", item.PaRo_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("ReturnValue", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            db.Execute("[Acce].[SP_PantallaPorRol_Insertar]", parameter, commandType: System.Data.CommandType.StoredProcedure);

            int result = parameter.Get<int>("ReturnValue");
            string mensaje = (result == 0) ? "Error al insertar" : "Insertado con éxito.";

            return new RequestStatus
            {
                CodeStatus = result,
                MessageStatus = mensaje
            };
        }

        public RequestStatus Delete(tbPantallasPorRol item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Role_Id", item.Role_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            // Capturar el resultado directamente como un valor escalar
            int result = db.ExecuteScalar<int>("[Acce].[SP_PantallaPorRol_Eliminar]", parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error al eliminar" : "Eliminado con éxito.";

            return new RequestStatus
            {
                CodeStatus = result,
                MessageStatus = mensaje
            };
        }
    }
}
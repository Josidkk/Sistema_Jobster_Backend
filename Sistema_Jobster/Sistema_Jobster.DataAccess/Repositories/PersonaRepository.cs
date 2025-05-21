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
    public class PersonaRepository
    {
        public RequestStatus Delete(tbPersonas item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Pers_Id", item.Pers_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("ReturnValue", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            db.Execute("[Gral].[SP_Personas_Eliminar]", parameter, commandType: System.Data.CommandType.StoredProcedure);

            int result = parameter.Get<int>("ReturnValue");
            string mensaje = (result == 0) ? "Error al eliminar " : "Eliminado con éxito.";

            return new RequestStatus
            {
                CodeStatus = result,
                MessageStatus = mensaje
            };
        }

        public tbPersonas Find(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbPersonas> Find(tbPersonas item)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@Pers_Id", item.Pers_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Query<tbPersonas>("[Gral].[SP_Personas_Buscar]", parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result;
        }

        public RequestStatus Insert(tbPersonas item)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@Pers_DNI", item.Pers_DNI, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Pers_Nombres", item.Pers_Nombres, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Pers_Apellidos", item.Pers_Apellidos, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Pers_Telefono", item.Pers_Telefono, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Pers_Sexo", item.Pers_Sexo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Pers_Direccion", item.Pers_Direccion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Pers_Curriculum", item.Pers_Curriculum, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@EsCi_Id", item.EsCi_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Muni_Codigo", item.Muni_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Pers_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", 1, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Execute("[Gral].[SP_Personas_Insertar]", parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";
            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public IEnumerable<tbPersonas> List()
        {
            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Query<tbPersonas>("[Gral].[SP_Personas_Listar]", commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public RequestStatus Update(tbPersonas item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Pers_Id", item.Pers_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Pers_DNI", item.Pers_DNI, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Pers_Nombres", item.Pers_Nombres, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Pers_Apellidos", item.Pers_Apellidos, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Pers_Telefono", item.Pers_Telefono, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Pers_Sexo", item.Pers_Sexo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Pers_Direccion", item.Pers_Direccion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Pers_Curriculum", item.Pers_Curriculum, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@EsCi_Id", item.EsCi_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Muni_Codigo", item.Muni_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Pers_FechaModificacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", 1, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Execute("[Gral].[SP_Personas_Editar]", parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";
            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }
    }
}
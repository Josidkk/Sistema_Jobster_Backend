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
    public class RequisitoRepository
    {

    
        public RequestStatus Delete(tbRequisitos item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Requ_Id", item.Requ_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("ReturnValue", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            db.Execute(ScriptDataBase.Requisito_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);


            int result = parameter.Get<int>("ReturnValue");
            string mensaje = (result == 0) ? "Error al eliminar " : "Eliminado con éxito.";

            return new RequestStatus
            {
                CodeStatus = result,
                MessageStatus = mensaje
            };
        }

        public tbRequisitos Find(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbRequisitos> Find(tbRequisitos item)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@Requ_Id", item.Requ_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Query<tbRequisitos>(ScriptDataBase.Requisito_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure);


            return result;
        }

        public RequestStatus Insert(tbRequisitos item)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@Requ_Descripcion", item.Requ_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Requ_Informacion", item.Requ_Informacion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Plaz_Id", item.Plaz_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            parameter.Add("@Requ_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", 1, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Execute(ScriptDataBase.Requisito_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";
            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public IEnumerable<tbRequisitos> List()
        {
            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Query<tbRequisitos>(ScriptDataBase.Requisitos_Listar, commandType: System.Data.CommandType.StoredProcedure);
            return result;

        }

        public RequestStatus Update(tbRequisitos item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Requ_Id", item.Requ_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Requ_Descripcion", item.Requ_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Requ_Informacion", item.Requ_Informacion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Plaz_Id", item.Plaz_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            parameter.Add("@Requ_FechaModificacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", 1, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Execute(ScriptDataBase.Requisito_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";
            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }
    }
    
}

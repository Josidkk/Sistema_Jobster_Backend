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
    public class GuardadoRepository
    {

    
        public RequestStatus Delete(tbGuardados item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Guar_Id", item.Guar_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("ReturnValue", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            //db.Execute(ScriptDataBase.Guardado_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            var result = db.Execute(ScriptDataBase.Guardado_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            //string mensaje = (result == 0) ? "Error al eliminar " : "Eliminado con éxito.";

            return new RequestStatus
            {
                CodeStatus = result,
                MessageStatus = result > 0 ? "'Guardado' eliminado con éxito." : "Error al eliminar Guardado."

                //CodeStatus = result,
                //MessageStatus = mensaje
            };
        }

        public tbGuardados Find(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbGuardados> Find(tbGuardados item)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@Guar_Id", item.Guar_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Query<tbGuardados>(ScriptDataBase.Guardado_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure);


            return result;
        }

        public RequestStatus Insert(tbGuardados item)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@Plaz_Id", item.Plaz_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Id", item.Usua_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            parameter.Add("@Guar_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", 1, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Execute(ScriptDataBase.Guardado_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";
            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public IEnumerable<tbGuardados> List()
        {
            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Query<tbGuardados>(ScriptDataBase.Guardados_Listar, commandType: System.Data.CommandType.StoredProcedure);
            return result;

        }

        public RequestStatus Update(tbGuardados item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Guar_Id", item.Guar_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Plaz_Id", item.Plaz_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Id", item.Usua_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            parameter.Add("@Guar_FechaModificacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", 1, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Execute(ScriptDataBase.Guardado_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";
            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }
    



    }
}

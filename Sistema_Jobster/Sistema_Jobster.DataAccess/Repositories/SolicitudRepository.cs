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
    public class SolicitudRepository
    {
        
        public RequestStatus Delete(tbSolicitudes item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Soli_Id", item.Soli_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            //db.Execute(ScriptDataBase.Solicitud_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            var result = db.Execute(ScriptDataBase.Solicitud_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            //string mensaje = (result == 0) ? "Error al eliminar " : "Eliminado con éxito.";

            return new RequestStatus
            {
                CodeStatus = result,
                MessageStatus = result > 0 ? "Solicitud eliminada con éxito." : "Error al eliminar solicitud."

                //CodeStatus = result,
                //MessageStatus = mensaje
            };
        }

        public tbSolicitudes Find(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbSolicitudes> Find(tbSolicitudes item)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@Soli_Id", item.Soli_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Query<tbSolicitudes>(ScriptDataBase.Solicitud_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure);


            return result;
        }

        public RequestStatus Insert(tbSolicitudes item)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@Soli_Comentario", item.Soli_Comentario, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Soli_Revision", item.Soli_Revision, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Plaz_Id", item.Plaz_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Id", item.Usua_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            parameter.Add("@Soli_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", 1, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Execute(ScriptDataBase.Solicitud_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";
            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public IEnumerable<tbSolicitudes> List()
        {
            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Query<tbSolicitudes>(ScriptDataBase.Solicitudes_Listar, commandType: System.Data.CommandType.StoredProcedure);
            return result;

        }

        public RequestStatus Update(tbSolicitudes item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Soli_Id", item.Soli_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Soli_Comentario", item.Soli_Comentario, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Soli_Revision", item.Soli_Revision, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Plaz_Id", item.Plaz_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Id", item.Usua_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            parameter.Add("@Soli_FechaModificacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", 1, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Execute(ScriptDataBase.Solicitud_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";
            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }
        
    }
}

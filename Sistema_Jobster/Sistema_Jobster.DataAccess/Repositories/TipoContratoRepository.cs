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
    public class TipoContratoRepository
    {
    
        public RequestStatus Delete(tbTiposContrato item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@TiCo_Id", item.TiCo_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("ReturnValue", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            db.Execute(ScriptDataBase.TipoContrato_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);


            int result = parameter.Get<int>("ReturnValue");
            string mensaje = (result == 0) ? "Error al eliminar " : "Eliminado con éxito.";

            return new RequestStatus
            {
                CodeStatus = result,
                MessageStatus = mensaje
            };
        }

        public tbTiposContrato Find(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbTiposContrato> Find(tbTiposContrato item)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@TiCo_Id", item.TiCo_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Query<tbTiposContrato>(ScriptDataBase.TipoContrato_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure);


            return result;
        }

        public RequestStatus Insert(tbTiposContrato item)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@TiCo_Descripcion", item.TiCo_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@TiCo_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", 1, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Execute(ScriptDataBase.TipoContrato_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";
            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public IEnumerable<tbTiposContrato> List()
        {
            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Query<tbTiposContrato>(ScriptDataBase.TiposContrato_Listar, commandType: System.Data.CommandType.StoredProcedure);
            return result;

        }

        public RequestStatus Update(tbTiposContrato item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@TiCo_Id", item.TiCo_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@TiCo_Descripcion", item.TiCo_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@TiCo_FechaModificacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", 1, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Execute(ScriptDataBase.TipoContrato_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";
            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }
    


    }
}

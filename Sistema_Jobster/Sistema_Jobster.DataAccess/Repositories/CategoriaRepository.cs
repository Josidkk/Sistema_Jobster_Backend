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
    public class CategoriaRepository
    {

        public RequestStatus Delete(tbCategorias item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Cate_Id", item.Cate_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("ReturnValue", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            db.Execute(ScriptDataBase.Categoria_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);


            int result = parameter.Get<int>("ReturnValue");
            string mensaje = (result == 0) ? "Error al eliminar " : "Eliminado con éxito.";

            return new RequestStatus
            {
                CodeStatus = result,
                MessageStatus = mensaje
            };
        }

        public IEnumerable<tbCategorias> Find(tbCategorias item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Cate_Id", item.Cate_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Query<tbCategorias>(ScriptDataBase.Categoria_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure).ToList();
            return result;
        }

        public RequestStatus Insert(tbCategorias item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Cate_Descripcion", item.Cate_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", item.Usua_Creacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Cate_FechaCreacion", item.Cate_FechaCreacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Execute(ScriptDataBase.Categoria_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error Base de Datos" : "Exito";
            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public IEnumerable<tbCategorias> List()
        {
            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Query<tbCategorias>(ScriptDataBase.Categoria_Listar, commandType: System.Data.CommandType.StoredProcedure).ToList();
            return result;
        }

        public RequestStatus Update(tbCategorias item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Cate_Id", item.Cate_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Cate_Descripcion", item.Cate_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", item.Usua_Modificacion, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Cate_FechaModificacion", item.Cate_FechaModificacion, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Execute(ScriptDataBase.Categoria_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error Base de Datos" : "Exito";
            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

    }
}

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
    public class PlazaRepository
    {

        public RequestStatus Delete(tbPlazas item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Plaz_Id", item.Plaz_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("ReturnValue", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.ReturnValue);

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            db.Execute(ScriptDataBase.Plaza_Eliminar, parameter, commandType: System.Data.CommandType.StoredProcedure);


            int result = parameter.Get<int>("ReturnValue");
            string mensaje = (result == 0) ? "Error al eliminar " : "Eliminado con éxito.";

            return new RequestStatus
            {
                CodeStatus = result,
                MessageStatus = mensaje
            };
        }

        public tbPlazas Find(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tbPlazas> Find(tbPlazas item)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@Plaz_Id", item.Plaz_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Query<tbPlazas>(ScriptDataBase.Plaza_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure);


            return result;
        }

        public RequestStatus Insert(tbPlazas item)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@Plaz_Descripcion", item.Plaz_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            parameter.Add("@Plaz_Informacion", item.Plaz_Informacion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Plaz_Direccion", item.Plaz_Direccion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Plaz_Telefono", item.Plaz_Telefono, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            parameter.Add("@Plaz_Correo", item.Plaz_Correo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Plaz_Imagen", item.Plaz_Imagen, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Muni_Codigo", item.Muni_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Id", item.Usua_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            parameter.Add("@Cate_Id", item.Cate_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Carg_Id", item.Carg_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@TiCo_Id", item.TiCo_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);


            parameter.Add("@Plaz_FechaCreacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Creacion", 1, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);


            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Execute(ScriptDataBase.Plaza_Insertar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";
            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }

        public IEnumerable<tbPlazas> List()
        {
            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Query<tbPlazas>(ScriptDataBase.Plazas_Listar, commandType: System.Data.CommandType.StoredProcedure);
            return result;

        }

          public IEnumerable<Object> ListTop5()
        {
            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Query<object>(ScriptDataBase.Plazas_Listartop5, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<Object> CantidadPlazasPorCate(int id)
        {
            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var parameter = new DynamicParameters();
            parameter.Add("@Cate_Id", id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            var result = db.Query<object>(ScriptDataBase.Plaza_CantidadPorCategoria,parameter,commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }


        public RequestStatus Update(tbPlazas item)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@Plaz_Id", item.Plaz_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Plaz_Descripcion", item.Plaz_Descripcion, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            parameter.Add("@Plaz_Informacion", item.Plaz_Informacion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Plaz_Direccion", item.Plaz_Direccion, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Plaz_Telefono", item.Plaz_Telefono, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            parameter.Add("@Plaz_Correo", item.Plaz_Correo, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Plaz_Imagen", item.Plaz_Imagen, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameter.Add("@Muni_Codigo", item.Muni_Codigo, System.Data.DbType.String, System.Data.ParameterDirection.Input);

            parameter.Add("@Cate_Id", item.Cate_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@Carg_Id", item.Carg_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            parameter.Add("@TiCo_Id", item.TiCo_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            parameter.Add("@Plaz_FechaModificacion", DateTime.Now, System.Data.DbType.DateTime, System.Data.ParameterDirection.Input);
            parameter.Add("@Usua_Modificacion", 1, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Execute(ScriptDataBase.Plaza_Actualizar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            string mensaje = (result == 0) ? "Error en base de datos" : "Exito";
            return new RequestStatus { CodeStatus = result, MessageStatus = mensaje };
        }
        
    }
}

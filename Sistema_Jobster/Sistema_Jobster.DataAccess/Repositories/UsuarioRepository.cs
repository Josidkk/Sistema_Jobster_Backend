using Dapper;
using Microsoft.Data.SqlClient;
using Sistema_Jobster.Entities.Entities;
using System;
using System.Collections.Generic;

namespace Sistema_Jobster.DataAccess.Repositories
{
    public class UsuarioRepository
    {
        public IEnumerable<tbUsuarios> ListarUsuarios()
        {
            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Query<tbUsuarios>("[Acce].[SP_Usuarios_Listar]", commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public tbUsuarios BuscarUsuario(int id)
        {
            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var parameters = new { Usua_Id = id };
            var result = db.QueryFirstOrDefault<tbUsuarios>("[Acce].[SP_Usuario_Buscar]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public tbUsuarios IniciarSesion(tbUsuarios item)
        {
            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@Usua_Nombre", item.Usua_Nombre, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            parameters.Add("@Usua_Contrasena", item.Usua_Contrasena, System.Data.DbType.String, System.Data.ParameterDirection.Input);
            var result = db.QueryFirstOrDefault<tbUsuarios>("[Acce].[SP_IniciarSesion]", parameters, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }


        public RequestStatus InsertarUsuario(tbUsuarios usuario)
        {
            var parameters = new
            {
                usuario.Usua_Nombre,
                usuario.Usua_Contrasena,
                usuario.Usua_Correo,
                usuario.Usua_EsAdmin,
                usuario.Usua_Publicador,
                usuario.Usua_Imagen,
                usuario.Pers_Id,
                usuario.Role_Id,
                usuario.Usua_Creacion,
                usuario.Usua_FechaCreacion
            };

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Execute("[Acce].[SP_Usuario_Insertar]", parameters, commandType: System.Data.CommandType.StoredProcedure);

            return new RequestStatus
            {
                CodeStatus = result,
                MessageStatus = result > 0 ? "Usuario insertado con éxito." : "Error al insertar usuario."
            };
        }

        public RequestStatus EliminarUsuario(tbUsuarios usuario)
        {
            var parameters = new { Usua_Id = usuario.Usua_Id };

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Execute("[Acce].[SP_Usuario_Eliminar]", parameters, commandType: System.Data.CommandType.StoredProcedure);

            return new RequestStatus
            {
                CodeStatus = result,
                MessageStatus = result > 0 ? "Usuario eliminado con éxito." : "Error al eliminar usuario."
            };
        }

        public RequestStatus RestablecerContrasena(tbUsuarios usuario)
        {
            var parameters = new
            {
                Usua_Id = usuario.Usua_Id,
                Usua_Contrasena = usuario.Usua_Contrasena,
                Usua_Modificacion = usuario.Usua_Modificacion,
                Usua_FechaModificacion = usuario.Usua_FechaModificacion ?? DateTime.Now
            };

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Execute("[Acce].[SP_Usuario_RestablecerContraseña]", parameters, commandType: System.Data.CommandType.StoredProcedure);

            return new RequestStatus
            {
                CodeStatus = result,
                MessageStatus = result > 0 ? "Contraseña restablecida con éxito." : "Error al restablecer contraseña."
            };
        }

        public RequestStatus EditarUsuario(tbUsuarios usuario)
        {
            var parameters = new
            {
                usuario.Usua_Id,
                usuario.Usua_Nombre,
                usuario.Usua_Contrasena,
                usuario.Usua_Correo,
                usuario.Usua_EsAdmin,
                usuario.Usua_Publicador,
                usuario.Usua_Imagen,
                usuario.Pers_Id,
                usuario.Role_Id,
                usuario.Usua_Modificacion,
                Usua_FechaModificacion = usuario.Usua_FechaModificacion ?? DateTime.Now
            };

            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.ExecuteScalar<int>("[Acce].[SP_Usuarios_Editar]", parameters, commandType: System.Data.CommandType.StoredProcedure);

            return new RequestStatus
            {
                CodeStatus = result,
                MessageStatus = result == 1 ? "Usuario editado con éxito." :
                                result == -1 ? "Nombre o correo ya existen." :
                                "Error al editar usuario."
            };
        }
    }
}

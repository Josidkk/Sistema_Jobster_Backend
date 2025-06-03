using Microsoft.EntityFrameworkCore.Storage;

//using Sistema_Jobster.DataAccess.Repositories;
using Sistema_Jobster.DataAccess.Repositories;
using Sistema_Jobster.Entities;
using Sistema_Jobster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sistema_Jobster.BusinessLogic.Services
{
    public class AccesoService
    {
        //private readonly RolesPorPantallasRepository _rolesPorPantallasRepository;
        //private readonly RolesRepository _rolesRepository;
        //private readonly PantallasRepository _pantallasRepository;
        //private readonly UsuarioRepository _UsuarioRepository;
        private readonly PantallasPorRolRepository _pantallasPorRolRepository;

        private readonly UsuarioRepository _usuarioRepository;
        private readonly RolesRepository _rolesRepository;

        //public AccesoService(RolesPorPantallasRepository rolesPorPantallasRepository,
        //                    RolesRepository rolesRepository,
        //                    PantallasRepository pantallasRepository,
        //                    UsuarioRepository UsuarioRepository)
        public AccesoService(PantallasPorRolRepository pantallasPorRolRepository, UsuarioRepository usuarioRepository, RolesRepository rolesRepository)
        {
            //_rolesPorPantallasRepository = rolesPorPantallasRepository;
            //_rolesRepository = rolesRepository;
            //_pantallasRepository = pantallasRepository;
            //_UsuarioRepository = UsuarioRepository;
            _pantallasPorRolRepository = pantallasPorRolRepository;
            _usuarioRepository = usuarioRepository;
            _rolesRepository = rolesRepository;
        }

        #region Roles

        public ServiceResult InsertarRol(tbRoles item)
        {
            var result = new ServiceResult();
            try
            {
                var nuevoRolId = _rolesRepository.Insert(item);
                return result.Ok(nuevoRolId);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ListarRoles()
        {
            var result = new ServiceResult();
            try
            {
                var list = _rolesRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ListarPantallas(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _rolesRepository.ListPantalla(id);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EditarRol(tbRoles item)
        {
            var result = new ServiceResult();
            try
            {
                var edit = _rolesRepository.Update(item);
                return result.Ok(edit);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarRol(tbRoles item)
        {
            var result = new ServiceResult();
            try
            {
                var delete = _rolesRepository.Delete(item);
                return result.Ok(delete);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarRol(tbRoles item)
        {
            var result = new ServiceResult();
            try
            {
                var roles = _rolesRepository.Find(item);
                return result.Ok(roles);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion Roles

        #region PantallasPorRol

        public ServiceResult InsertarPantallaPorRol(tbPantallasPorRol item)
        {
            var result = new ServiceResult();
            try
            {
                var respuesta = _pantallasPorRolRepository.Insert(item);
                return result.Ok(respuesta);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarPantallaPorRol(tbPantallasPorRol item)
        {
            var result = new ServiceResult();
            try
            {
                var respuesta = _pantallasPorRolRepository.Delete(item);
                return result.Ok(respuesta);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion PantallasPorRol

        #region Usuarios

        public ServiceResult ListarUsuarios()
        {
            var result = new ServiceResult();
            try
            {
                var usuarios = _usuarioRepository.ListarUsuarios();
                return result.Ok(usuarios);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public IEnumerable<object> CantidadUsuariosAprobados(string fechainicio, string fechafin)
        {
            var result = new ServiceResult();
            try
            {
                var list = _usuarioRepository.CantidadUsuariosAprobados(fechainicio, fechafin);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ServiceResult ListarUsuariosAprobados()
        {
            var result = new ServiceResult();
            try
            {
                var usuarios = _usuarioRepository.ListarUsuariosAprobados();
                return result.Ok(usuarios);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarUsuario(tbUsuarios usua)
        {
            var result = new ServiceResult();
            try
            {
                var usuario = _usuarioRepository.BuscarUsuario(usua.Usua_Nombre);
                return result.Ok(usuario);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult IniciarSesion(tbUsuarios usua)
        {
            var result = new ServiceResult();
            try
            {
                var usuario = _usuarioRepository.IniciarSesion(usua);
                return result.Ok(usuario);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult InsertarUsuario(tbUsuarios usuario)
        {
            var result = new ServiceResult();
            try
            {
                var response = _usuarioRepository.InsertarUsuario(usuario);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarUsuario(tbUsuarios usuario)
        {
            var result = new ServiceResult();
            try
            {
                var response = _usuarioRepository.EliminarUsuario(usuario);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult AprobarUsuario(tbUsuarios usuario)
        {
            var result = new ServiceResult();
            try
            {
                var response = _usuarioRepository.AprobarUsuario(usuario);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult RestablecerContrasena(tbUsuarios usuario)
        {
            var result = new ServiceResult();
            try
            {
                var response = _usuarioRepository.RestablecerContrasena(usuario);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EditarUsuario(tbUsuarios usuario)
        {
            var result = new ServiceResult();
            try
            {
                var response = _usuarioRepository.EditarUsuario(usuario);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion Usuarios
    }
}
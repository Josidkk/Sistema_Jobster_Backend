using Microsoft.EntityFrameworkCore.Storage;
using Sistema_Jobster.DataAccess.Repositorios;
using Sistema_Jobster.Entities;
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

        //public AccesoService(RolesPorPantallasRepository rolesPorPantallasRepository,
        //                    RolesRepository rolesRepository,
        //                    PantallasRepository pantallasRepository,
        //                    UsuarioRepository UsuarioRepository)
        public AccesoService()
        {
            //_rolesPorPantallasRepository = rolesPorPantallasRepository;
            //_rolesRepository = rolesRepository;
            //_pantallasRepository = pantallasRepository;
            //_UsuarioRepository = UsuarioRepository;
        }

        #region Roles

        //public ServiceResult InsertarRol(tbRoles item)
        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        var nuevoRolId = _rolesRepository.Insert(item);
        //        return result.Ok(nuevoRolId);
        //    }
        //    catch (Exception ex)
        //    {
        //        return result.Error(ex.Message);
        //    }
        //}

        //public ServiceResult ListarRoles()
        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        var list = _rolesRepository.List();
        //        return result.Ok(list);
        //    }
        //    catch (Exception ex)
        //    {
        //        return result.Error(ex.Message);
        //    }
        //}

        //public ServiceResult EditarRol(tbRoles item)
        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        var edit = _rolesRepository.Edit(item);
        //        return result.Ok(edit);
        //    }
        //    catch (Exception ex)
        //    {
        //        return result.Error(ex.Message);
        //    }
        //}

        //public ServiceResult EliminarRol(tbRoles item)
        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        var delete = _rolesRepository.Delete(item);
        //        return result.Ok(delete);
        //    }
        //    catch (Exception ex)
        //    {
        //        return result.Error(ex.Message);
        //    }
        //}

        //public ServiceResult BuscarRol(tbRoles item)
        //{
        //    var result = new ServiceResult();
        //    try
        //    {
        //        var roles = _rolesRepository.Find(item);
        //        return result.Ok(roles);
        //    }
        //    catch (Exception ex)
        //    {
        //        return result.Error(ex.Message);
        //    }
        //}

        #endregion Roles
    }
}
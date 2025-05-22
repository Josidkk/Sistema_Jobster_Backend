using Sistema_Jobster.DataAccess.Repositories;
using Sistema_Jobster.Entities;
using Sistema_Jobster.Entities.Entities;
using System;

namespace Sistema_Jobster.BusinessLogic.Services
{
    public class GeneralService
    {
        private readonly PersonaRepository _personaRepository;
        private readonly GeneralesRepository _generalesRepository;

        public GeneralService(PersonaRepository personaRepository, GeneralesRepository generalesRepository)
        {
            _personaRepository = personaRepository;
            _generalesRepository = generalesRepository;
        }

        #region Personas

        public ServiceResult InsertarPersona(tbPersonas item)
        {
            var result = new ServiceResult();
            try
            {
                var nuevaPersonaId = _personaRepository.Insert(item);
                return result.Ok(nuevaPersonaId);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult ListarPersonas()
        {
            var result = new ServiceResult();
            try
            {
                var list = _personaRepository.List();
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EditarPersona(tbPersonas item)
        {
            var result = new ServiceResult();
            try
            {
                var edit = _personaRepository.Update(item);
                return result.Ok(edit);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarPersona(tbPersonas item)
        {
            var result = new ServiceResult();
            try
            {
                var delete = _personaRepository.Delete(item);
                return result.Ok(delete);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult BuscarPersona(tbPersonas item)
        {
            var result = new ServiceResult();
            try
            {
                var persona = _personaRepository.Find(item);
                return result.Ok(persona);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion Personas

        #region Departamentos

        public IEnumerable<tbDepartamentos> ListDepartamentos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _generalesRepository.ListDepartamentos();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbDepartamentos> departamentos = new List<tbDepartamentos>();
                return departamentos;
            }
        }

        #endregion

        #region Municipios

        public IEnumerable<tbMunicipios> ListMunicipios()
        {
            var result = new ServiceResult();
            try
            {
                var list = _generalesRepository.ListMunicipios();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbMunicipios> municipios = new List<tbMunicipios>();
                return municipios;
            }
        }

        #endregion

        #region EstadosCiviles

        public IEnumerable<tbEstadosCiviles> ListEstadosCiviles()
        {
            var result = new ServiceResult();
            try
            {
                var list = _generalesRepository.ListEstadosCiviles();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbEstadosCiviles> estadosCiviles = new List<tbEstadosCiviles>();
                return estadosCiviles;
            }
        }

        #endregion
    }
}
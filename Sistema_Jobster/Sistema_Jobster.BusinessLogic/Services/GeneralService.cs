using Sistema_Jobster.DataAccess.Repositories;
using Sistema_Jobster.Entities;
using Sistema_Jobster.Entities.Entities;
using System;

namespace Sistema_Jobster.BusinessLogic.Services
{
    public class GeneralService
    {
        private readonly PersonaRepository _personaRepository;

        public GeneralService(PersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
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
    }
}
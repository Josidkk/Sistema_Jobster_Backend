using Sistema_Jobster.BusinessLogic;
using Sistema_Jobster.DataAccess.Repositories;
using Sistema_Jobster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Jobster.BusinessLogic.Services
{
    public class PlazaServices
    {
        private readonly CargoRepository _cargoRepository;

        public PlazaServices(
            CargoRepository cargoRepository

        )
        {
            //_categoriaRepository = categoriaRepository;
            _cargoRepository = cargoRepository;

        }

        #region cargos
        public IEnumerable<tbCargos> ListCargos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _cargoRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbCargos> carg = null;
                return carg;
            }
        }

        public ServiceResult InsertCargo(tbCargos Cargo)
        {
            var result = new ServiceResult();
            try
            {
                var response = _cargoRepository.Insert(Cargo);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateCargo(tbCargos Cargo)
        {
            var result = new ServiceResult();
            try
            {
                var response = _cargoRepository.Update(Cargo);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }
        public ServiceResult DeleteCargo(tbCargos Cargo)
        {
            var result = new ServiceResult();
            try
            {
                int returnCode = _cargoRepository.Delete(Cargo).CodeStatus;

                switch (returnCode)
                {
                    case 1:
                        return result.Ok("1");
                    case 2:
                        return result.Warning("2");
                    case -1:
                        return result.Error("-1");
                    default:
                        return result.Error("Código de retorno desconocido.");
                }
            }
            catch (Exception ex)
            {
                return result.Error("Ocurrió un error inesperado: " + ex.Message);
            }
        }


        public IEnumerable<tbCargos> FindCargo(tbCargos Cargo)
        {
            //var result = new ServiceResult();
            try
            {
                var result = _cargoRepository.Find(Cargo);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion






    }


}

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
        private readonly CategoriaRepository _categoriaRepository;
        private readonly PlazaRepository _plazaRepository;
        private readonly TipoContratoRepository _tipoContratoRepository;
        private readonly SolicitudRepository _solicitudRepository;
        private readonly RequisitoRepository _requisitoRepository;
        private readonly GuardadoRepository _guardadoRepository;

        public PlazaServices(
            CargoRepository cargoRepository,
            CategoriaRepository categoriaRepository,
            PlazaRepository plazaRepository,
            TipoContratoRepository tipoContratoRepository,
            SolicitudRepository solicitudRepository,
            RequisitoRepository requisitoRepository,
            GuardadoRepository guardadoRepository

        )
        {
            _cargoRepository = cargoRepository;
            _categoriaRepository = categoriaRepository;
            _plazaRepository = plazaRepository;
            _tipoContratoRepository = tipoContratoRepository;
            _solicitudRepository = solicitudRepository;
            _requisitoRepository = requisitoRepository;
            _guardadoRepository = guardadoRepository;
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
                IEnumerable<tbCargos> carg = new List<tbCargos>();
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
                return new List<tbCargos>();
            }
        }

        #endregion cargos

        #region Categorias

        public IEnumerable<tbCategorias> ListCategoria()
        {
            var result = new ServiceResult();
            try
            {
                var list = _categoriaRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbCategorias> categorias = new List<tbCategorias>();
                return categorias;
            }
        }

        public IEnumerable<tbCategorias> BuscarCategoria(tbCategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _categoriaRepository.Find(item);
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbCategorias> categoria = null;
                return categoria;
            }
        }

        public ServiceResult InsertarCategoria(tbCategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _categoriaRepository.Insert(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult EliminarCategoria(tbCategorias item)
        {
            var result = new ServiceResult();

            try
            {
                int returnCode = _categoriaRepository.Delete(item).CodeStatus;

                switch (returnCode)
                {
                    case 1:
                        return result.Ok("Categoría eliminada con éxito.");

                    case 2:
                        return result.Warning("Categoría en uso, no se puede eliminar.");

                    case -1:
                        return result.Error("Error al eliminar la categoría.");

                    default:
                        return result.Error("Código de retorno desconocido.");
                }
            }
            catch (Exception ex)
            {
                return result.Error("Ocurrió un error inesperado: " + ex.Message);
            }
        }

        public ServiceResult ActualizarCategoria(tbCategorias item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _categoriaRepository.Update(item);
                return result.Ok(list);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        #endregion Categorias

        #region Plazas

        public IEnumerable<tbPlazas> ListPlazas()
        {
            var result = new ServiceResult();
            try
            {
                var list = _plazaRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbPlazas> plazas = new List<tbPlazas>();
                return plazas;
            }
        }

        public IEnumerable<object> ListTop5Plazas(DateTime fechaInicio, DateTime FechaFin)
        {
            var result = new ServiceResult();
            try
            {
                var list = _plazaRepository.ListTop5(fechaInicio, FechaFin);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<object> CantidadPlazasPorCate(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _plazaRepository.CantidadPlazasPorCate(id);
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ServiceResult InsertPlaza(tbPlazas Plaza)
        {
            var result = new ServiceResult();
            try
            {
                var response = _plazaRepository.Insert(Plaza);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdatePlaza(tbPlazas Plaza)
        {
            var result = new ServiceResult();
            try
            {
                var response = _plazaRepository.Update(Plaza);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeletePlaza(tbPlazas Plaza)
        {
            var result = new ServiceResult();
            try
            {
                int returnCode = _plazaRepository.Delete(Plaza).CodeStatus;

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

        public IEnumerable<tbPlazas> FindPlaza(tbPlazas Plaza)
        {
            //var result = new ServiceResult();
            try
            {
                var result = _plazaRepository.Find(Plaza);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion Plazas

        #region TiposContrato

        public IEnumerable<tbTiposContrato> ListTiposContrato()
        {
            var result = new ServiceResult();
            try
            {
                var list = _tipoContratoRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbTiposContrato> ticos = null;
                return ticos;
            }
        }

        public ServiceResult InsertTipoContrato(tbTiposContrato TipoContrato)
        {
            var result = new ServiceResult();
            try
            {
                var response = _tipoContratoRepository.Insert(TipoContrato);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateTipoContrato(tbTiposContrato TipoContrato)
        {
            var result = new ServiceResult();
            try
            {
                var response = _tipoContratoRepository.Update(TipoContrato);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeleteTipoContrato(tbTiposContrato TipoContrato)
        {
            var result = new ServiceResult();
            try
            {
                int returnCode = _tipoContratoRepository.Delete(TipoContrato).CodeStatus;

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

        public IEnumerable<tbTiposContrato> FindTipoContrato(tbTiposContrato TipoContrato)
        {
            //var result = new ServiceResult();
            try
            {
                var result = _tipoContratoRepository.Find(TipoContrato);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion TiposContrato

        #region Requisitos

        public IEnumerable<tbRequisitos> ListRequisitos()
        {
            var result = new ServiceResult();
            try
            {
                var list = _requisitoRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbRequisitos> requisitos = null;
                return requisitos;
            }
        }

        public ServiceResult InsertRequisito(tbRequisitos Requisito)
        {
            var result = new ServiceResult();
            try
            {
                var response = _requisitoRepository.Insert(Requisito);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateRequisito(tbRequisitos Requisito)
        {
            var result = new ServiceResult();
            try
            {
                var response = _requisitoRepository.Update(Requisito);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeleteRequisito(tbRequisitos Requisito)
        {
            var result = new ServiceResult();
            try
            {
                int returnCode = _requisitoRepository.Delete(Requisito).CodeStatus;

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

        public IEnumerable<tbRequisitos> FindRequisito(tbRequisitos Requisito)
        {
            //var result = new ServiceResult();
            try
            {
                var result = _requisitoRepository.Find(Requisito);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion Requisitos

        #region Solicitudes

        public IEnumerable<tbSolicitudes> ListSolicitudes()
        {
            var result = new ServiceResult();
            try
            {
                var list = _solicitudRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbSolicitudes> carg = null;
                return carg;
            }
        }

        public ServiceResult InsertSolicitud(tbSolicitudes Solicitud)
        {
            var result = new ServiceResult();
            try
            {
                var response = _solicitudRepository.Insert(Solicitud);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateSolicitud(tbSolicitudes Solicitud)
        {
            var result = new ServiceResult();
            try
            {
                var response = _solicitudRepository.Update(Solicitud);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeleteSolicitud(tbSolicitudes Solicitud)
        {
            var result = new ServiceResult();
            try
            {
                int returnCode = _solicitudRepository.Delete(Solicitud).CodeStatus;

                switch (returnCode)
                {
                    case 1:
                        return result.Ok("1 Completado Exitosamente");

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

        public IEnumerable<tbSolicitudes> FindSolicitud(tbSolicitudes Solicitud)
        {
            //var result = new ServiceResult();
            try
            {
                var result = _solicitudRepository.Find(Solicitud);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion Solicitudes

        #region Guardados

        public IEnumerable<tbGuardados> ListGuardados()
        {
            var result = new ServiceResult();
            try
            {
                var list = _guardadoRepository.List();
                return list;
            }
            catch (Exception ex)
            {
                IEnumerable<tbGuardados> guardados = null;
                return guardados;
            }
        }

        public ServiceResult InsertGuardado(tbGuardados Guardado)
        {
            var result = new ServiceResult();
            try
            {
                var response = _guardadoRepository.Insert(Guardado);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult UpdateGuardado(tbGuardados Guardado)
        {
            var result = new ServiceResult();
            try
            {
                var response = _guardadoRepository.Update(Guardado);
                return result.Ok(response);
            }
            catch (Exception ex)
            {
                return result.Error(ex.Message);
            }
        }

        public ServiceResult DeleteGuardado(tbGuardados Guardado)
        {
            var result = new ServiceResult();
            try
            {
                int returnCode = _guardadoRepository.Delete(Guardado).CodeStatus;

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

        public IEnumerable<tbGuardados> FindGuardado(tbGuardados Guardado)
        {
            //var result = new ServiceResult();
            try
            {
                var result = _guardadoRepository.Find(Guardado);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion Guardados
    }
}
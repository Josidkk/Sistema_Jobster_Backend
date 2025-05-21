using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sistema_Jobster.API.Models;
using Sistema_Jobster.BusinessLogic.Services;
using Sistema_Jobster.Entities.Entities;

namespace Sistema_Jobster.API.Controllers
{
    public class TiposContratoController : Controller
    {
        private readonly PlazaServices _plazaServices;
        private readonly IMapper _mapper;

        public TiposContratoController(PlazaServices plazaServices, IMapper mapper)
        {
            _plazaServices = plazaServices;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ListarTiposContrato")]
        public IActionResult Listar()
        {
            var result = _plazaServices.ListTiposContrato();
            var mapped = _mapper.Map<IEnumerable<TipoContratoViewModel>>(result);
            return Ok(mapped);
        }


        [HttpPost("InsertarTipoContrato")]
        public IActionResult Insertar([FromBody] TipoContratoViewModel item)
        {

            var mapped = _mapper.Map<tbTiposContrato>(item);
            var result = _plazaServices.InsertTipoContrato(mapped);
            return Ok(result);
        }

        [HttpPost("BuscarTipoContrato")]
        public IActionResult Buscar([FromBody] TipoContratoViewModel item)
        {
            var mapped = _mapper.Map<tbTiposContrato>(item);
            var result = _plazaServices.FindTipoContrato(mapped);

            var mapeado = _mapper.Map<IEnumerable<TipoContratoViewModel>>(result);
            return Ok(mapeado);

        }

        [HttpPut("ActualizarTipoContrato")]
        public IActionResult Update([FromBody] TipoContratoViewModel item)
        {
            //var tbPrestamosDetalle = await _context.tbPrestamosDetalle.FindAsync(id);

            var mapped = _mapper.Map<tbTiposContrato>(item);
            var result = _plazaServices.UpdateTipoContrato(mapped);
            return Ok(result);
        }

        //[HttpPost("EliminarTipoContrato")]
        //public IActionResult Delete([FromxBody] TipoContratoViewModel item)
        //{
        //    var mapped = _mapper.Map<tbTiposContrato>(item);
        //    var result = _gralServices.DeleteTipoContrato(mapped);
        //    return Ok(result);
        //}


        [HttpPost("EliminarTipoContrato")]
        public IActionResult Delete([FromBody] TipoContratoViewModel item)
        {
            var mapped = _mapper.Map<tbTiposContrato>(item);
            var result = _plazaServices.DeleteTipoContrato(mapped);

            if (result.Success)
                return Ok(new { Message = result.Message /*, ReturnCode = (int?)result.Data */ });
            else
                return BadRequest(new { Message = result.Message /*, ReturnCode = (int?)result.Data */ });
        }



    }
}

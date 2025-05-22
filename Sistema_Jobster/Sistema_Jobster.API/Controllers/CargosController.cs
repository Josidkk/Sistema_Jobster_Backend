using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sistema_Jobster.API.Helpers;
using Sistema_Jobster.API.Models;
using Sistema_Jobster.BusinessLogic.Services;
using Sistema_Jobster.Entities.Entities;
using System.Diagnostics.Contracts;
using System.Runtime;

namespace Sistema_Jobster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class CargosController : Controller
    {

        private readonly PlazaServices _plazaServices;
        private readonly IMapper _mapper;

        public CargosController(PlazaServices plazaServices, IMapper mapper)
        {
            _plazaServices = plazaServices;
            _mapper = mapper;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ListarCargos")]
        public IActionResult Listar()
        {
            var result = _plazaServices.ListCargos();
            var mapped = _mapper.Map<IEnumerable<CargoViewModel>>(result);
            return Ok(mapped);
        }


        [HttpPost("InsertarCargo")]
        public IActionResult Insertar([FromBody] CargoViewModel item)
        {

            var mapped = _mapper.Map<tbCargos>(item);
            var result = _plazaServices.InsertCargo(mapped);
            return Ok(result);
        }

        [HttpPost("BuscarCargo")]
        public IActionResult Buscar([FromBody] CargoViewModel item)
        {
            var mapped = _mapper.Map<tbCargos>(item);
            var result = _plazaServices.FindCargo(mapped);

            var mapeado = _mapper.Map<IEnumerable<CargoViewModel>>(result);
            return Ok(mapeado);

        }

        [HttpPut("ActualizarCargo")]
        public IActionResult Update([FromBody] CargoViewModel item)
        {
            //var tbPrestamosDetalle = await _context.tbPrestamosDetalle.FindAsync(id);

            var mapped = _mapper.Map<tbCargos>(item);
            var result = _plazaServices.UpdateCargo(mapped);
            return Ok(result);
        }

        //[HttpPost("EliminarCargo")]
        //public IActionResult Delete([FromxBody] CargoViewModel item)
        //{
        //    var mapped = _mapper.Map<tbCargos>(item);
        //    var result = _gralServices.DeleteCargo(mapped);
        //    return Ok(result);
        //}


        [HttpPost("EliminarCargo")]
        public IActionResult Delete([FromBody] CargoViewModel item)
        {
            var mapped = _mapper.Map<tbCargos>(item);
            var result = _plazaServices.DeleteCargo(mapped);

            if (result.Success)
                return Ok(new { Message = result.Message /*, ReturnCode = (int?)result.Data */ });
            else
                return BadRequest(new { Message = result.Message /*, ReturnCode = (int?)result.Data */ });
        }



    }
}

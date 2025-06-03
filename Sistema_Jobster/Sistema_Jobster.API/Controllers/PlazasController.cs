using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sistema_Jobster.API.Helpers;
using Sistema_Jobster.API.Models;
using Sistema_Jobster.BusinessLogic.Services;
using Sistema_Jobster.Entities.Entities;

namespace Sistema_Jobster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class PlazasController : Controller
    {
        private readonly PlazaServices _plazaServices;
        private readonly IMapper _mapper;

        public PlazasController(PlazaServices plazaServices, IMapper mapper)
        {
            _plazaServices = plazaServices;
            _mapper = mapper;
        }

        [HttpGet("ListarPlazas")]
        public IActionResult Listar()
        {
            var result = _plazaServices.ListPlazas();
            var mapped = _mapper.Map<IEnumerable<PlazaViewModel>>(result);
            return Ok(mapped);
        }

        [HttpPost("ListarTop5Plazas")]
        public IActionResult Listar5Plazas(DateTime FechaInicio, DateTime FechaFin)
        {
            var result = _plazaServices.ListTop5Plazas(FechaInicio, FechaFin);
            return Ok(result);
        }

        [HttpGet("CantidadPlazasPorCategoria/{id}")]
        public IActionResult CantidadPlazasPorCate(int id)
        {
            var result = _plazaServices.CantidadPlazasPorCate(id);

            return Ok(result);
        }

        [HttpPost("InsertarPlaza")]
        public IActionResult Insertar([FromBody] PlazaViewModel item)
        {
            var mapped = _mapper.Map<tbPlazas>(item);
            var result = _plazaServices.InsertPlaza(mapped);
            return Ok(result);
        }

        [HttpPost("BuscarPlaza")]
        public IActionResult Buscar([FromBody] PlazaViewModel item)
        {
            var mapped = _mapper.Map<tbPlazas>(item);
            var result = _plazaServices.FindPlaza(mapped);

            var mapeado = _mapper.Map<IEnumerable<PlazaViewModel>>(result);
            return Ok(mapeado);
        }

        [HttpPut("ActualizarPlaza")]
        public IActionResult Update([FromBody] PlazaViewModel item)
        {
            //var tbPrestamosDetalle = await _context.tbPrestamosDetalle.FindAsync(id);

            var mapped = _mapper.Map<tbPlazas>(item);
            var result = _plazaServices.UpdatePlaza(mapped);
            return Ok(result);
        }

        //[HttpPost("EliminarPlaza")]
        //public IActionResult Delete([FromxBody] PlazaViewModel item)
        //{
        //    var mapped = _mapper.Map<tbPlazas>(item);
        //    var result = _gralServices.DeletePlaza(mapped);
        //    return Ok(result);
        //}

        [HttpPost("EliminarPlaza")]
        public IActionResult Delete([FromBody] PlazaViewModel item)
        {
            var mapped = _mapper.Map<tbPlazas>(item);
            var result = _plazaServices.DeletePlaza(mapped);

            if (result.Success)
                return Ok(new { Message = result.Message /*, ReturnCode = (int?)result.Data */ });
            else
                return BadRequest(new { Message = result.Message /*, ReturnCode = (int?)result.Data */ });
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
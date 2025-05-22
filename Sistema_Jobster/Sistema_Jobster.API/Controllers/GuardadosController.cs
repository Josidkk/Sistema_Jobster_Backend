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
    public class GuardadosController : Controller
    {

        private readonly PlazaServices _plazaServices;
        private readonly IMapper _mapper;

        public GuardadosController(PlazaServices plazaServices, IMapper mapper)
        {
            _plazaServices = plazaServices;
            _mapper = mapper;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ListarGuardados")]
        public IActionResult Listar()
        {
            var result = _plazaServices.ListGuardados();
            var mapped = _mapper.Map<IEnumerable<GuardadoViewModel>>(result);
            return Ok(mapped);
        }


        [HttpPost("InsertarGuardado")]
        public IActionResult Insertar([FromBody] GuardadoViewModel item)
        {
            var mapped = _mapper.Map<tbGuardados>(item);
            var result = _plazaServices.InsertGuardado(mapped);
            return Ok(result);
        }

        [HttpPost("BuscarGuardado")]
        public IActionResult Buscar([FromBody] GuardadoViewModel item)
        {
            var mapped = _mapper.Map<tbGuardados>(item);
            var result = _plazaServices.FindGuardado(mapped);

            var mapeado = _mapper.Map<IEnumerable<GuardadoViewModel>>(result);
            return Ok(mapeado);

        }

        [HttpPut("ActualizarGuardado")]
        public IActionResult Update([FromBody] GuardadoViewModel item)
        {
            var mapped = _mapper.Map<tbGuardados>(item);
            var result = _plazaServices.UpdateGuardado(mapped);
            return Ok(result);
        }

        [HttpPost("EliminarGuardado")]
        public IActionResult Delete([FromBody] GuardadoViewModel item)
        {
            var mapped = _mapper.Map<tbGuardados>(item);
            var result = _plazaServices.DeleteGuardado(mapped);

            if (result.Success)
                return Ok(new { Message = result.Message /*, ReturnCode = (int?)result.Data */ });
            else
                return BadRequest(new { Message = result.Message /*, ReturnCode = (int?)result.Data */ });
        }




    }
}

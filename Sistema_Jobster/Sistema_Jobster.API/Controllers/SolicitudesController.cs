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
    public class SolicitudesController : Controller
    {

        private readonly PlazaServices _plazaServices;
        private readonly IMapper _mapper;

        public SolicitudesController(PlazaServices plazaServices, IMapper mapper)
        {
            _plazaServices = plazaServices;
            _mapper = mapper;
        }

        [HttpGet("Index")]

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("ListarSolicitudes")]
        public IActionResult Listar()
        {
            var result = _plazaServices.ListSolicitudes();
            var mapped = _mapper.Map<IEnumerable<SolicitudViewModel>>(result);
            return Ok(mapped);
        }


        [HttpPost("InsertarSolicitud")]
        public IActionResult Insertar([FromBody] SolicitudViewModel item)
        {

            var mapped = _mapper.Map<tbSolicitudes>(item);
            var result = _plazaServices.InsertSolicitud(mapped);
            return Ok(result);
        }

        [HttpPost("BuscarSolicitud")]
        public IActionResult Buscar([FromBody] SolicitudViewModel item)
        {
            var mapped = _mapper.Map<tbSolicitudes>(item);
            var result = _plazaServices.FindSolicitud(mapped);

            var mapeado = _mapper.Map<IEnumerable<SolicitudViewModel>>(result);
            return Ok(mapeado);

        }

        [HttpPut("ActualizarSolicitud")]
        public IActionResult Update([FromBody] SolicitudViewModel item)
        {

            var mapped = _mapper.Map<tbSolicitudes>(item);
            var result = _plazaServices.UpdateSolicitud(mapped);
            return Ok(result);
        }

        [HttpPost("EliminarSolicitud")]
        public IActionResult Delete([FromBody] SolicitudViewModel item)
        {
            var mapped = _mapper.Map<tbSolicitudes>(item);
            var result = _plazaServices.DeleteSolicitud(mapped);

            if (result.Success)
                return Ok(new { Message = result.Message /*, ReturnCode = (int?)result.Data */ });
            else
                return BadRequest(new { Message = result.Message /*, ReturnCode = (int?)result.Data */ });
        }

    }
}

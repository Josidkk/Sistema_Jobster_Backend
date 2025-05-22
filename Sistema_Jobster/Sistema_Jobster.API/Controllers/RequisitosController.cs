using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sistema_Jobster.API.Models;
using Sistema_Jobster.BusinessLogic.Services;
using Sistema_Jobster.Entities.Entities;

namespace Sistema_Jobster.API.Controllers
{
    public class RequisitosController : Controller
    {

        private readonly PlazaServices _plazaServices;
        private readonly IMapper _mapper;

        public RequisitosController(PlazaServices plazaServices, IMapper mapper)
        {
            _plazaServices = plazaServices;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet("ListarRequisitos")]
        public IActionResult Listar()
        {
            var result = _plazaServices.ListRequisitos();
            var mapped = _mapper.Map<IEnumerable<RequisitoViewModel>>(result);
            return Ok(mapped);
        }


        [HttpPost("InsertarRequisito")]
        public IActionResult Insertar([FromBody] RequisitoViewModel item)
        {

            var mapped = _mapper.Map<tbRequisitos>(item);
            var result = _plazaServices.InsertRequisito(mapped);
            return Ok(result);
        }

        [HttpPost("BuscarRequisito")]
        public IActionResult Buscar([FromBody] RequisitoViewModel item)
        {
            var mapped = _mapper.Map<tbRequisitos>(item);
            var result = _plazaServices.FindRequisito(mapped);

            var mapeado = _mapper.Map<IEnumerable<RequisitoViewModel>>(result);
            return Ok(mapeado);

        }

        [HttpPut("ActualizarRequisito")]
        public IActionResult Update([FromBody] RequisitoViewModel item)
        {
            //var tbPrestamosDetalle = await _context.tbPrestamosDetalle.FindAsync(id);

            var mapped = _mapper.Map<tbRequisitos>(item);
            var result = _plazaServices.UpdateRequisito(mapped);
            return Ok(result);
        }

        //[HttpPost("EliminarRequisito")]
        //public IActionResult Delete([FromxBody] RequisitoViewModel item)
        //{
        //    var mapped = _mapper.Map<tbRequisitos>(item);
        //    var result = _gralServices.DeleteRequisito(mapped);
        //    return Ok(result);
        //}


        [HttpPost("EliminarRequisito")]
        public IActionResult Delete([FromBody] RequisitoViewModel item)
        {
            var mapped = _mapper.Map<tbRequisitos>(item);
            var result = _plazaServices.DeleteRequisito(mapped);

            if (result.Success)
                return Ok(new { Message = result.Message /*, ReturnCode = (int?)result.Data */ });
            else
                return BadRequest(new { Message = result.Message /*, ReturnCode = (int?)result.Data */ });
        }



    }
}

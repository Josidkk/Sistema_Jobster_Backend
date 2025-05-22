using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sistema_Jobster.API.Helpers;
using Sistema_Jobster.API.Models;
using Sistema_Jobster.BusinessLogic.Services;

namespace Sistema_Jobster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]

    public class GeneralesController : Controller
    {

        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        public GeneralesController(GeneralService generalService, IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }


        [HttpGet("ListarEstadosCiviles")]
        public IActionResult ListarEstadosCiviles()
        {
            var result = _generalService.ListEstadosCiviles();
            var mapped = _mapper.Map<IEnumerable<EstadoCivilViewModel>>(result);
            return Ok(mapped);
        }

        [HttpGet("ListarDepartamentos")]
        public IActionResult ListarDepartamentos()
        {
            var result = _generalService.ListDepartamentos();
            var mapped = _mapper.Map<IEnumerable<DepartamentoViewModel>>(result);
            return Ok(mapped);
        }

        [HttpGet("ListarMunicipios")]
        public IActionResult ListarMunicipios()
        {
            var result = _generalService.ListMunicipios();
            var mapped = _mapper.Map<IEnumerable<MunicipioViewModel>>(result);
            return Ok(mapped);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}

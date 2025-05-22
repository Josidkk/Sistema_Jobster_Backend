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
            var result = _generalService.ListarEstadosCiviles();
            try
            {
                result.Data = _mapper.Map<IEnumerable<EstadoCivilViewModel>>(result.Data);
            }
            catch (Exception)
            {
            }
            
            return Ok(result);
        }

        [HttpGet("ListarDepartamentos")]
        public IActionResult ListarDepartamentos()
        {
            var result = _generalService.ListarDepartamentos();

            try
            {
                result.Data = _mapper.Map<IEnumerable<DepartamentoViewModel>>(result.Data);
            }
            catch (Exception)
            {
            }
            return Ok(result);
        }

        [HttpGet("ListarMunicipios")]
        public IActionResult ListarMunicipios()
        {
            var result = _generalService.ListarMunicipios();
            try
            {
                result.Data = _mapper.Map<IEnumerable<MunicipioViewModel>>(result.Data);
            }
            catch (Exception)
            {
            }
            return Ok(result);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}

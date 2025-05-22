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
    public class CategoriasController : Controller
    {
        private readonly PlazaServices _plazServices;
        private readonly IMapper _mapper;
        public CategoriasController(PlazaServices plazaServices, IMapper mapper)
        {
            _plazServices = plazaServices;
            _mapper = mapper;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet("ListarCategorias")]
        public IActionResult List()
        {
            var list = _plazServices.ListCategoria();
            return Ok(list);
        }

        [HttpPost("BuscarCategoria")]
        public IActionResult Find([FromBody] CategoriaViewModel item)
        {
            var mapped = _mapper.Map<tbCategorias>(item);
            var list = _plazServices.BuscarCategoria(mapped);
            return Ok(list);
        }

        [HttpPost("InsertarCategoria")]
        public IActionResult Insert([FromBody] CategoriaViewModel item)
        {
            var mapped = _mapper.Map<tbCategorias>(item);
            var result = _plazServices.InsertarCategoria(mapped);
            return Ok(result);
        }

        [HttpPost("EliminarCategoria")]
        public IActionResult Delete([FromBody] CategoriaViewModel item)
        {
            var mapped = _mapper.Map<tbCategorias>(item);
            var result = _plazServices.EliminarCategoria(mapped);
            if (result.Success)
                return Ok(new { Message = result.Message });
            else
                return BadRequest(new { Message = result.Message });
        }

        [HttpPut("ActualizarCategoria")]
        public IActionResult Update([FromBody] CategoriaViewModel item)
        {
            var mapped = _mapper.Map<tbCategorias>(item);
            var result = _plazServices.ActualizarCategoria(mapped);
            return Ok(result);
        }


    }
}

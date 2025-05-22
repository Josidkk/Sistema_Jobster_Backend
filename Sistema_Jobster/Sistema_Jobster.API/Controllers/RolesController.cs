using AutoMapper;
using Azure;
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
    public class RolesController : Controller
    {

        private readonly AccesoService _accesoServices;
        private readonly IMapper _mapper;

        public RolesController(AccesoService accesoServices, IMapper mapper)
        {
            _accesoServices = accesoServices;
            _mapper = mapper;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ListarRoles")]
        public IActionResult Listar()
        {
            var result = _accesoServices.ListarRoles();
            result.Data = _mapper.Map<IEnumerable<RolesViewModel>>((IEnumerable<tbRoles>)result.Data);
            return Ok(result);
        }

        [HttpGet("ListarPantallas")]
        public IActionResult ListarPantallas()
        {
            var result = _accesoServices.ListarPantallas();
            result.Data = _mapper.Map<IEnumerable<PantallasViewModel>>((IEnumerable<tbPantallas>)result.Data);
            return Ok(result);
        }



        [HttpPost("InsertarRoles")]
        public IActionResult Insertar([FromBody] RolesViewModel item)
        {

            var mapped = _mapper.Map<tbRoles>(item);
            var result = _accesoServices.InsertarRol(mapped);
            return Ok(result);
        }

        [HttpPost("BuscarRoles")]
        public IActionResult Buscar([FromBody] RolesViewModel item)
        {
            var mapped = _mapper.Map<tbRoles>(item);
            var result = _accesoServices.BuscarRol(mapped);

           
            result.Data = _mapper.Map<IEnumerable<RolesViewModel>>((IEnumerable<tbRoles>)result.Data);
            return Ok(result);

        }

        [HttpPut("ActualizarRoles")]
        public IActionResult Update([FromBody] RolesViewModel item)
        {
            //var tbPrestamosDetalle = await _context.tbPrestamosDetalle.FindAsync(id);

            var mapped = _mapper.Map<tbRoles>(item);
            var result = _accesoServices.EditarRol(mapped);
            return Ok(result);
        }

        //[HttpPost("EliminarRoles")]
        //public IActionResult Delete([FromxBody] RolesViewModel item)
        //{
        //    var mapped = _mapper.Map<tbRoles>(item);
        //    var result = _gralServices.DeleteRoles(mapped);
        //    return Ok(result);
        //}


        [HttpPost("EliminarRoles")]
        public IActionResult Delete([FromBody] RolesViewModel item)
        {
            var mapped = _mapper.Map<tbRoles>(item);
            var result = _accesoServices.EliminarRol(mapped);

            if (result.Success)
                return Ok(new { Message = result.Message /*, ReturnCode = (int?)result.Data */ });
            else
                return BadRequest(new { Message = result.Message /*, ReturnCode = (int?)result.Data */ });
        }



    }
}

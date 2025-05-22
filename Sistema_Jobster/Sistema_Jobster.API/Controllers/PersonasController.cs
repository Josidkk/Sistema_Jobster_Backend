using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sistema_Jobster.API.Helpers;
using Sistema_Jobster.API.Models;
using Sistema_Jobster.BusinessLogic.Services;
using Sistema_Jobster.Entities.Entities;
using System;

namespace Sistema_Jobster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class PersonasController : ControllerBase
    {
        private readonly GeneralService _generalService;
        private readonly IMapper _mapper;

        public PersonasController(GeneralService generalService, IMapper mapper)
        {
            _generalService = generalService;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult Index()
        {
            var response = _generalService.ListarPersonas();
            return Ok(response);
        }

        [HttpGet("Buscar/{id}")]
        public IActionResult Find(int id)
        {
            var item = new tbPersonas { Pers_Id = id };
            var response = _generalService.BuscarPersona(item);
            return Ok(response);
        }

        [HttpPost("Insertar")]
        public IActionResult Insert(PersonaViewModel personaViewModel)
        {
            var item = _mapper.Map<tbPersonas>(personaViewModel);
            item.Pers_FechaCreacion = DateTime.Now;
            var response = _generalService.InsertarPersona(item);
            return Ok(response);
        }

        [HttpPut("Editar")]
        public IActionResult Update(PersonaViewModel personaViewModel)
        {
            var item = _mapper.Map<tbPersonas>(personaViewModel);
            item.Pers_FechaModificacion = DateTime.Now;
            var response = _generalService.EditarPersona(item);
            return Ok(response);
        }

        [HttpPut("Eliminar")]
        public IActionResult Delete(PersonaViewModel personaViewModel)
        {
            var item = _mapper.Map<tbPersonas>(personaViewModel);
            var response = _generalService.EliminarPersona(item);
            return Ok(response);
        }
    }
}
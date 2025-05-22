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
    public class PantallasPorRolController : ControllerBase
    {
        private readonly AccesoService _accesoService;
        private readonly IMapper _mapper;

        public PantallasPorRolController(AccesoService accesoService, IMapper mapper)
        {
            _accesoService = accesoService;
            _mapper = mapper;
        }

        [HttpPost("Insertar")]
        public IActionResult Insert(PantallasPorRolViewModel pantallasPorRolViewModel)
        {
            var item = _mapper.Map<tbPantallasPorRol>(pantallasPorRolViewModel);
            item.PaRo_FechaCreacion = DateTime.Now;
            item.Usua_Creacion = pantallasPorRolViewModel.Usua_Creacion ?? 1; // Valor predeterminado si es null
            var response = _accesoService.InsertarPantallaPorRol(item);
            return Ok(response);
        }

        [HttpDelete("Eliminar")]
        public IActionResult Delete(PantallasPorRolViewModel pantallasPorRolViewModel)
        {
            var item = _mapper.Map<tbPantallasPorRol>(pantallasPorRolViewModel);
            var response = _accesoService.EliminarPantallaPorRol(item);
            return Ok(response);
        }
    }
}
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
    public class UsuariosController : ControllerBase
    {
        private readonly AccesoService _accesoService;
        private readonly IMapper _mapper;

        public UsuariosController(AccesoService accesoService, IMapper mapper)
        {
            _accesoService = accesoService;
            _mapper = mapper;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var response = _accesoService.ListarUsuarios();
            response.Data = _mapper.Map<IEnumerable<UsuarioViewModel>>((IEnumerable<tbUsuarios>)response.Data);

            return Ok(response);
        }

        [HttpPost("Buscar/")]
        public IActionResult Buscar([FromBody] UsuarioViewModel usua)
        {
            var usuario = _mapper.Map<tbUsuarios>(usua);
            var response = _accesoService.BuscarUsuario(usuario);
            try
            {
                response.Data = _mapper.Map<List<UsuarioViewModel>>(response.Data);
            }
            catch (Exception)
            {
            }
            return Ok(response.Data);
        }

        [HttpPost("IniciarSesion")]
        public IActionResult IniciarSesion([FromBody] UsuarioViewModel usua)
        {
            var usuario = _mapper.Map<tbUsuarios>(usua);

            var response = _accesoService.IniciarSesion(usuario);

            try
            {
                response.Data = _mapper.Map<List<UsuarioViewModel>>(response.Data);
            }
            catch (Exception)
            {
            }
            return Ok(response.Data);
        }

        [HttpPost("Insertar")]
        public IActionResult Insertar([FromBody] UsuarioViewModel usuarioViewModel)
        {
            var usuario = _mapper.Map<tbUsuarios>(usuarioViewModel);
            usuario.Usua_FechaCreacion = DateTime.Now;
            var response = _accesoService.InsertarUsuario(usuario);
            return Ok(response);
        }

        [HttpPut("Eliminar")]
        public IActionResult Eliminar([FromBody] UsuarioViewModel usuarioViewModel)
        {
            var usuario = _mapper.Map<tbUsuarios>(usuarioViewModel);
            var response = _accesoService.EliminarUsuario(usuario);
            return Ok(response);
        }

        [HttpPut("RestablecerContrasena")]
        public IActionResult RestablecerContrasena([FromBody] UsuarioViewModel usuarioViewModel)
        {
            var usuario = _mapper.Map<tbUsuarios>(usuarioViewModel);
            usuario.Usua_FechaModificacion = DateTime.Now;
            var response = _accesoService.RestablecerContrasena(usuario);
            return Ok(response);
        }

        [HttpPut("Editar")]
        public IActionResult Editar([FromBody] UsuarioViewModel usuarioViewModel)
        {
            var usuario = _mapper.Map<tbUsuarios>(usuarioViewModel);
            usuario.Usua_FechaModificacion = DateTime.Now;
            var response = _accesoService.EditarUsuario(usuario);
            return Ok(response);
        }
    }
}
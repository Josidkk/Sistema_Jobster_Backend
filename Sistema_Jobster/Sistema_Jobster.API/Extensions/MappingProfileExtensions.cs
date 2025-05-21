using AutoMapper;
using Sistema_Jobster.API;
using Sistema_Jobster.API.Models;
using Sistema_Jobster.Entities;
using Sistema_Jobster.Entities.Entities;

namespace Sistema_Jobster.API.Extensions
{
    public class MappingProfileExtensions : Profile
    {
        public MappingProfileExtensions()
        {
            //CreateMap<tbDepartamentos, DepartamentoViewModel>().ReverseMap();
            //CreateMap<tbEstadosCiviles, EstadosCivilesViewModel>().ReverseMap();
            //CreateMap<tbMunicipios, MunicipiosViewModel>().ReverseMap();
            //CreateMap<tbUsuarios, UsuariosViewModel>().ReverseMap();
            //CreateMap<tbModelos, ModeloViewModel>().ReverseMap();
            //CreateMap<tbMarcas, MarcasViewModel>().ReverseMap();
            //CreateMap<tbSucursales, SucursalViewModel>().ReverseMap();
            //CreateMap<tbPrestamos, PrestamoViewModel>().ReverseMap();

            //CreateMap<tbClientes, ClientesViewModel>().ReverseMap();
            //CreateMap<tbEmpleados, EmpleadosViewModel>().ReverseMap();

            CreateMap<tbCargos, CargoViewModel>().ReverseMap();
            CreateMap<tbCategorias, CategoriaViewModel>().ReverseMap();
            CreateMap<tbPlazas, PlazaViewModel>().ReverseMap();

            CreateMap<tbTiposContrato, TipoContratoViewModel>().ReverseMap();
            CreateMap<tbRequisitos, RequisitoViewModel>().ReverseMap();
            CreateMap<tbSolicitudes, SolicitudViewModel>().ReverseMap();
            CreateMap<tbGuardados, GuardadoViewModel>().ReverseMap();

            //CreateMap<RolesPorPantallasViewModel, tbPantallasPorRol>().ReverseMap();
            //CreateMap<tbPantallas, PantallasViewModel>().ReverseMap();
            //CreateMap<tbRoles, RolesViewModel>().ReverseMap();
            //CreateMap<tbVehiculos, VehiculoViewModel>().ReverseMap();
            //CreateMap<tbClientes, ClientesViewModel>().ReverseMap();
            //CreateMap<tbPlanes, PlanesViewModel>().ReverseMap();
            //CreateMap<tbPlanesDetalle, PlanesDetallesViewModel>().ReverseMap();
        }
    }
}
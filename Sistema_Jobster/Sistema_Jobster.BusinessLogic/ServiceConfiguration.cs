using Microsoft.Extensions.DependencyInjection;
using Sistema_Jobster.BusinessLogic.Services;
using Sistema_Jobster.DataAccess;
using Sistema_Jobster.DataAccess.Context;
using Sistema_Jobster.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Jobster.BusinessLogic
{
    public static class ServiceConfiguration
    {
        public static void DataAccess(this IServiceCollection services, string connectionString)
        {
            Sistema_JobsterContext.BuildConnectionString(connectionString);

            services.AddScoped<CargoRepository>();
            services.AddScoped<PersonaRepository>();
            //services.AddScoped<DepartamentoRepository>();
            //services.AddScoped<MunicipioRepository>();

            //services.AddScoped<ClienteRepository>();
            //services.AddScoped<EmpleadoRepository>();
            //services.AddScoped<HomeRepository>();
            //services.AddScoped<PantallasRepository>();
            //services.AddScoped<RolesPorPantallasRepository>();
            //services.AddScoped<EstadoCivilRepository>();
            services.AddScoped<PantallasPorRolRepository>();
            services.AddScoped<UsuarioRepository>();
            //services.AddScoped<ModeloRepository>();
            //services.AddScoped<VehiculoRepository>();
            //services.AddScoped<MarcaRepository>();
            //services.AddScoped<PlanesRepository>();
            //services.AddScoped<PlanesDetalleRepository>();
            //services.AddScoped<SucursalRepository>();
            //services.AddScoped<PrestamoRepository>();

            Sistema_JobsterContext.BuildConnectionString(connectionString);
        }

        public static void BusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<PlazaServices>();
            services.AddScoped<GeneralService>();
            services.AddScoped<AccesoService>();
        }
    }
}
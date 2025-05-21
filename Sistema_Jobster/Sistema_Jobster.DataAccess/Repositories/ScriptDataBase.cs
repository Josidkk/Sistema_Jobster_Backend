using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Jobster.DataAccess.Repositories
{
    public class ScriptDataBase
    {

        #region Cargos

        public static string Cargos_Listar    = "[Plaz].[SP_Cargos_Listar]";
        public static string Cargo_Insertar   = "[Plaz].[SP_Cargos_Insertar]";
        public static string Cargo_Actualizar = "[Plaz].[SP_Cargos_Actualizar]";
        public static string Cargo_Eliminar   = "[Plaz].[SP_Cargos_Eliminar]";
        public static string Cargo_Buscar     = "[Plaz].[SP_Cargos_Buscar]";

        #endregion

        #region Categorias
        public static string Categoria_Listar =     "[Plaz].[SP_Categorias_Listar]";
        public static string Categoria_Buscar =     "[Plaz].[SP_Categorias_Buscar]";
        public static string Categoria_Eliminar =   "[Plaz].[SP_Categorias_Eliminar]";
        public static string Categoria_Insertar =   "[Plaz].[SP_Categorias_Insertar]";
        public static string Categoria_Actualizar = "[Plaz].[SP_Categorias_Actualizar]";
        #endregion

        #region Plazas
        public static string Plazas_Listar      = "[Plaz].[SP_Plazas_Listar]";
        public static string Plaza_Buscar       = "[Plaz].[SP_Plazas_Buscar]";
        public static string Plaza_Eliminar     = "[Plaz].[SP_Plazas_Eliminar]";
        public static string Plaza_Insertar     = "[Plaz].[SP_Plazas_Insertar]";
        public static string Plaza_Actualizar   = "[Plaz].[SP_Plazas_Actualizar]";
        #endregion


        #region TiposContrato
        public static string TiposContrato_Listar       = "[Plaz].[SP_TiposContrato_Listar]";
        public static string TipoContrato_Buscar        = "[Plaz].[SP_TiposContrato_Buscar]";
        public static string TipoContrato_Eliminar      = "[Plaz].[SP_TiposContrato_Eliminar]";
        public static string TipoContrato_Insertar      = "[Plaz].[SP_TiposContrato_Insertar]";
        public static string TipoContrato_Actualizar    = "[Plaz].[SP_TiposContrato_Actualizar]";
        #endregion


        #region Requisitos
        public static string Requisitos_Listar       = "[Plaz].[SP_Requisitos_Listar]";
        public static string Requisito_Buscar        = "[Plaz].[SP_Requisitos_Buscar]";
        public static string Requisito_Eliminar      = "[Plaz].[SP_Requisitos_Eliminar]";
        public static string Requisito_Insertar      = "[Plaz].[SP_Requisitos_Insertar]";
        public static string Requisito_Actualizar    = "[Plaz].[SP_Requisitos_Actualizar]";
        #endregion


        #region Solicitudes
        public static string Solicitudes_Listar      = "[Plaz].[SP_Solicitudes_Listar]";
        public static string Solicitud_Buscar        = "[Plaz].[SP_Solicitudes_Buscar]";
        public static string Solicitud_Eliminar      = "[Plaz].[SP_Solicitudes_Eliminar]";
        public static string Solicitud_Insertar      = "[Plaz].[SP_Solicitudes_Insertar]";
        public static string Solicitud_Actualizar    = "[Plaz].[SP_Solicitudes_Actualizar]";
        #endregion


        #region Guardado
        public static string Guardados_Listar       = "[Plaz].[SP_Guardados_Listar]";
        public static string Guardado_Buscar        = "[Plaz].[SP_Guardados_Buscar]";
        public static string Guardado_Eliminar      = "[Plaz].[SP_Guardados_Eliminar]";
        public static string Guardado_Insertar      = "[Plaz].[SP_Guardados_Insertar]";
        public static string Guardado_Actualizar    = "[Plaz].[SP_Guardados_Actualizar]";
        #endregion


    }




}





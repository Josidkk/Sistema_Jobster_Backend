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

        #region pantallassegunrol

        public static string PantSel_Buscar = "[Acce].[SP_Pantallas_ListarSeleccionadas]";

        #endregion





    }




}





using Dapper;
using Microsoft.Data.SqlClient;
using Sistema_Jobster.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Jobster.DataAccess.Repositories
{
    class PantallaRepository
    {

        public IEnumerable<tbPantallasPorRol> Find(tbPantallasPorRol item)
        {
            var parameter = new DynamicParameters();

            parameter.Add("@Carg_Id", item.Role_Id, System.Data.DbType.Int32, System.Data.ParameterDirection.Input);
            using var db = new SqlConnection(Sistema_JobsterContext.ConnectionString);
            var result = db.Query<tbPantallasPorRol>(ScriptDataBase.PantSel_Buscar, parameter, commandType: System.Data.CommandType.StoredProcedure);

            return result;



        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evi_Correio.Dao
{
    internal class cidadesDAO
    {
        public DataTable ListarAtivos()
        {
            string cmdSql = "SELECT codcid,nomecid,estado,uf,ibge,pais FROM cidade WHERE desativado = 'N'";
            var dadosS = Program.cx.ExecutaSql(cmdSql);

            if (dadosS != null)
            {
                DataTable dt = new DataTable();
                using (var reader = dadosS.CreateDataReader())
                {
                    dt.Load(reader);
                }
                return dt;
            }
            return null;
        }
        public DataTable ListarDesativados()
        {
            string cmdSql = "SELECT codcid,nomecid,estado,uf,ibge,pais FROM cidade WHERE desativado = 'S'";
            var dadosS = Program.cx.ExecutaSql(cmdSql);

            if (dadosS != null)
            {
                DataTable dt = new DataTable();
                using (var reader = dadosS.CreateDataReader())
                {
                    dt.Load(reader);
                }
                return dt;
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evi_Correio.Objeto
{
    internal class Cidades
    {
        public int    Codcid        { get; set; } = 0;
        public string Nomecid       { get; set; } = string.Empty;
        public int    Ibge          { get; set; } = 0;
        public string Uf            { get; set; } = string.Empty;
        public string Estado        { get; set; } = string.Empty;
        public string Pais          { get; set; } = string.Empty;
        public string Desativado    { get; set; }
        public string DataHora      { get; set; }


        int padraoCod = 3;

        public int GravaCidade(int Codcid, string Nomecid, string Estado, string Uf, int Ibge, string Pais)
        {
            string codBanco = string.Empty;

            Nomecid = Nomecid.Trim();
            Uf = Uf.Trim();
            Estado = Estado.Trim();

            string cmdSql = "SELECT * FROM cidade WHERE codcid = '" + Codcid + "'";
            var dadosS = Program.cx.ExecutaSql(cmdSql);

            if (dadosS != null)
            {
                string cmdSqlI = "UPDATE cidade SET nomecid = '" + Nomecid + "', estado = '" + Estado + "', uf = '" + Uf + "', ibge = '" + Ibge + "', pais = '" + Pais + "' WHERE codcid = '" + Codcid + "'";
                var dadosI = Program.cx.ExecutaSql(cmdSqlI);
            }
            else
            {
                string cmdSqlS = "SELECT MAX(codcid) as max_codigo FROM cidade";
                var dados = Program.cx.ExecutaSql(cmdSqlS);
                DataRow linhaDados = dados.Rows[0];
                codBanco = linhaDados["max_codigo"].ToString();

                Codcid = int.Parse(codBanco.PadLeft(padraoCod, '0'));
                Codcid++;

                //gravando no banco
                string cmdSqlI = "INSERT INTO cidade (codcid, nomecid, estado, uf, ibge, desativado, pais) values" + "('" + Codcid + "','" + Nomecid + "','" + Estado + "','" + Uf + "','" + Ibge + "', 'N', '" + Pais + "' )";
                var dadosI = Program.cx.ExecutaSql(cmdSqlI);
            }
            return Codcid;
        }
        public void Desativar()
        {
            string cmdSql = "SELECT FROM cidade WHERE codcid = '" + Codcid + "'";
            var dadosS = Program.cx.ExecutaSql(cmdSql);

            if (dadosS != null)
            {
                string cmdSqlI = "INSERT INTO cidade (desativado, datahora) value (" + Desativado + "'," + DataHora + ") WHERE codigo = '" + Codcid + "'";
                var dadosI = Program.cx.ExecutaSql(cmdSqlI);

            }
            else
            {
                string cmdSqlU = "UPDATE cidade SET desativado = '" + Desativado + "', datahora ='" + DataHora + "' WHERE codcid = '" + Codcid + "'";
                var dadosU = Program.cx.ExecutaSql(cmdSqlU);
            }
        }
    }
}

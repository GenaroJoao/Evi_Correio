using Evi_Correio.Objeto;
using Evi_Correio;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
//using System.ServiceModel.Security.Tokens;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evi_Correio.Class
{
    internal class Publico
    {
        public string Empresa       { get; set; } = string.Empty;
        public string Logo          { get; set; } = string.Empty;
        public string Path          { get; set; } = string.Empty;
        public string Cidade        { get; set; } = string.Empty;
        public string Nomecid       { get; set; } = string.Empty;
        public string Estado        { get; set; } = string.Empty;
        public string Uf            { get; set; } = string.Empty;
        public int Codcid           { get; set; } = 0;
        public string Ibge          { get; set; } = string.Empty;
        public string QuantCasa     { get; set; } = string.Empty;
        public string Tabela        { get; set; } = string.Empty;

        bool habHoras;

        string resultado;

        public string PegaCidade(string Nomecid, string Uf, string Estado, string Ibge)
        {
            Nomecid = Nomecid.Trim();
            Uf = Uf.Trim();
            Estado = Estado.Trim();
            Ibge = Ibge.Trim();
            int Codcid = 0;
            string Pais = "";

            Objeto.Cidades cid = new Objeto.Cidades();

            var dados = Program.cx.ExecutaSql("SELECT codcid, nomecid FROM cidade WHERE nomecid = '" + Nomecid + "' and uf = '" + Uf + "'");
            if (dados != null && dados.Rows.Count > 0)
            {
                DataRow linhaDados = dados.Rows[0];
                Cidade = linhaDados["codcid"].ToString();

                return Cidade;
            }

            Codcid = cid.GravaCidade(Codcid, Nomecid, Estado, Uf, int.Parse(Ibge), Pais);
            return Codcid.ToString();
        }

        public void Decimal(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08 && e.KeyChar != 44)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == 44)
            {
                TextBox txt = (TextBox)sender;

                if (txt.Text.Contains(","))
                {
                    e.Handled = true;
                }
            }
        }

        public void Numerico(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 08 && e.KeyChar != 44)
            {
                e.Handled = true;
            }
        }

        public void Letras(object sender, KeyPressEventArgs e)
        {
            // Permite letras, espaços e a tecla "Backspace"
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        //public string QtdaCasaDecimal()
       // {
            /*env_config config = new env_config();
            QuantCasa = config.CasaDecimal();

            if (QuantCasa == 1.ToString())
            {
                QuantCasa = "F1";
            }
            else if (QuantCasa == 2.ToString())
            {
                QuantCasa = "F2";
            }
            else if (QuantCasa == 2.ToString())
            {
                QuantCasa = "F2";
            }
            else if (QuantCasa == 3.ToString())
            {
                QuantCasa = "F3";
            }
            else if (QuantCasa == 4.ToString())
            {
                QuantCasa = "F4";
            }
            else if (QuantCasa == 5.ToString())
            {
                QuantCasa = "F5";
            }
            else if (QuantCasa == 6.ToString())
            {
                QuantCasa = "F6";
            }

            return QuantCasa;*/
        //}

        public string Consulta(int Codigo)
        {
            resultado = "";
            var dados = Program.cx.ExecutaSql("SELECT codpes FROM pessoa WHERE codpes = '" + Codigo + "'");
            if (dados != null && dados.Rows.Count > 0)
            {
                DataRow linhaDados = dados.Rows[0];
                resultado = linhaDados["nome"].ToString();

            }
            return resultado;
        }

        internal bool hab_relogio()
        {
            return habHoras;
        }
    }
}

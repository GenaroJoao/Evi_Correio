using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evi_Correio.Objeto
{
    internal class Pessoas
    {
        public int Codigo           { get; set; }
        public string Nome          { get; set; }
        public string Cpfcnpj       { get; set; }
        public string Endereco      { get; set; }
        public string Bairro        { get; set; }
        public string Numero        { get; set; }
        public string Cep           { get; set; }
        public int Codcid           { get; set; }
        public string Complemento   { get; set; }
        public string Telefone      { get; set; }
        public string Whatsapp      { get; set; }
        public string Email         { get; set; }
        public string Contato       { get; set; }
        public string Desativado    { get; set; }
        public string DataHora      { get; set; }


        //////////////////////////////////////////
        //METODO 
        /////////////////////////////////////////

        public void Gravabanco()
        {
            string cmdSql = "SELECT * FROM pessoas WHERE codpes = '" + Codigo+ "'";
            var dadosS = Program.cx.ExecutaSql(cmdSql);

            if (dadosS != null)
            {
                //atualizar tabela
                string cmdSqlU = "UPDATE pessoas SET nome = '" + Nome + "', cpfcnpj = '" + Cpfcnpj + "' " +
                    ", endereco = '" + Endereco + "', endnum = '" + Numero + "', bairro = '" + Bairro + "', cep = '" + Cep + "', cidade = '" + Codcid + "', complemento = '" + Complemento + "' " +
                    ", telefone = '" + Telefone + "', email = '" + Email + "', whatsapp = '" + Whatsapp + "', contato = '" + Contato + "' WHERE codigo = '" + Codigo + "'";
                var dadosU = Program.cx.ExecutaSql(cmdSqlU);
            }
            else
            {
                //gravando no banco
                string cmdSqlI = "INSERT INTO pessoas (codpes, nome, cpfcnpj, endereco, endnum, bairro, cep, cidade, complemento, telefone, whatsapp, email, contato, desativado) values" +
                     "('" + Codigo + "','" + Nome + "','" + Cpfcnpj + "','" + Endereco + "','" + Numero + "','" + Bairro + "'," +
                     "'" + Cep + "','" + Codcid + "','" + Complemento + "','" + Telefone + "','" + Whatsapp + "','" + Email + "','" + Contato + "','N')";
                var dadosI = Program.cx.ExecutaSql(cmdSqlI);
            }
        }
        public void Desativar()
        {
            string cmdSql = "SELECT FROM pessoas WHERE codpes = '" + Codigo + "'";
            var dadosS = Program.cx.ExecutaSql(cmdSql);

            if (dadosS != null)
            {
                string cmdSqlI = "INSERT INTO pessoas (desativado, datahora) value (" + Desativado + "'," + DataHora + ") WHERE codpes = '" + Codigo + "'";
                var dadosI = Program.cx.ExecutaSql(cmdSqlI);

            }
            else
            {
                string cmdSqlU = "UPDATE pessoas SET desativado = '" + Desativado + "', datahora ='" + DataHora + "' WHERE codpes = '" + Codigo + "'";
                var dadosU = Program.cx.ExecutaSql(cmdSqlU);
            }
        }
    }
}

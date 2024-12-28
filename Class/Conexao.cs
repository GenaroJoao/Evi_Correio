using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Evi_Correio.Class
{
    internal class Conexao
    {
        private NpgsqlConnection objConexao = new NpgsqlConnection();
        private NpgsqlCommand objComandos = new NpgsqlCommand();
        private NpgsqlDataAdapter objDadoEmMemoria;
        private string MsgErro;
        public string strDeConexao;
        private int lastId;

        public Conexao(string server, string porta, string dataBase, string user, string password)
        {
            strDeConexao = "Server=" + server + ";";
            strDeConexao += "Port=" + porta + ";";
            strDeConexao += "DataBase=" + dataBase + ";";
            strDeConexao += "User Id=" + user + ";";
            strDeConexao += "Password=" + password + ";";
        }

        public int getLastId()
        {
            return this.lastId;
        }

        public string getMsgErro()
        {
            return this.MsgErro;
        }
        private bool conectar()
        {
            try
            {
                desconectar();
                objConexao.ConnectionString = strDeConexao;
                objComandos.Connection = objConexao;
                objConexao.Open();
                return true;
            }
            catch (Exception erro)
            {
                MsgErro = erro.Message.ToString();
                return false;
            }
        }

        private bool desconectar()
        {
            try
            {
                if (objConexao.State == ConnectionState.Open)
                {
                    objConexao.Close();

                }
                return true;
            }
            catch (Exception erro)
            {
                this.MsgErro = erro.Message.ToString();
                return false;
            }
        }
        public bool testarConexao()
        {
            return conectar();
        }

        //comando SQL

        // Método para executar comandos SQL com parâmetros
        public bool ComandoSql(string comandoSql, params NpgsqlParameter[] parametros)
        {
            try
            {
                if (conectar())
                {
                    objComandos.CommandText = comandoSql;
                    objComandos.Parameters.Clear();
                    objComandos.Parameters.AddRange(parametros);

                    int result = objComandos.ExecuteNonQuery();
                    return result > 0;
                }
                return false;
            }
            catch (Exception erro)
            {
                MsgErro = erro.Message;
                return false;
            }
            finally
            {
                desconectar();
            }
        }

        // Método para executar SELECT com segurança
        public DataTable ExecutaSql(string comandoSql, params NpgsqlParameter[] parametros)
        {
            try
            {
                if (conectar())
                {
                    objComandos.CommandText = comandoSql;
                    objComandos.Parameters.Clear();
                    objComandos.Parameters.AddRange(parametros);

                    objDadoEmMemoria = new NpgsqlDataAdapter(objComandos);
                    DataTable tabelaDeDados = new DataTable();
                    objDadoEmMemoria.Fill(tabelaDeDados);
                    return tabelaDeDados.Rows.Count > 0 ? tabelaDeDados : null;
                }
                return null;
            }
            catch (Exception erro)
            {
                MsgErro = erro.Message;
                return null;
            }
            finally
            {
                desconectar();
            }
        }
    }
}

using Evi_Correio.Api;
using Evi_Correio.Class;
using Evi_Correio.Dao;
using Evi_Correio.Objeto;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Evi_Correio.Api.CepService;

namespace Evi_Correio
{
    public partial class env_pessoa : MaterialForm
    {
        public env_pessoa()
        {
            InitializeComponent();

            bcidades.Click -= bcidades_Click;
            bcidades.Click += new EventHandler(bcidades_Click);
            this.ShowInTaskbar = false;

            // Configura o MaterialSkinManager para gerenciar o formulário atual
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            // Força o tema inicial para LIGHT
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200,
                TextShade.WHITE);
        }
        DataTable pessoa = new DataTable();

        // Instancia a classe de consulta//
        pessoasDAO pessoasDAO = new pessoasDAO();
        CepService consulta = new CepService();
        env_cidade cidade = new env_cidade();
        Pessoas pessoas = new Pessoas();
        Publico pb = new Publico();
        Msg msg = new Msg();

        DataRow linhaDados;
        CepResponse resultado;

        string pesq,
               format,
               cmdSql,
               valor;

        bool encontrado;

        object lastRow;

        int cod = 0,
            padraoCodcid = 3,
            padraoCod    = 9,
            codBanco     = 0,
            cellCod      = 0,
            lastRowIndex = 0,
            rowIndex     = 0,
            lastIndex    = 0;

        private void bincluir_Click(object sender, EventArgs e)
        {
            lbstatus.Text = "INCLUIR";
            ppessoa.Visible   = true;

            tbcodigo.Enabled  = false;
            gbdados2.Enabled  = true;
            bcancela.Enabled  = true;
            bconfirma.Enabled = true;

            codBanco = 0;

            tbcodigo.Text = cod.ToString().PadLeft(padraoCod, '0');

            cmdSql = "SELECT MAX(codpes) as max_codigo FROM pessoas";
            var dadosS = Program.cx.ExecutaSql(cmdSql);

            if (dadosS != null)
            {
                linhaDados = dadosS.Rows[0];
                codBanco = int.Parse(linhaDados["max_codigo"].ToString());
                if (codBanco == 0)
                {
                    cod = codBanco;
                    cod++;
                }
                cod = codBanco;
                cod++;
            }
            else
            {
                cod++;
            }
            tbcodigo.Text = cod.ToString().PadLeft(padraoCod, '0');
        }

        private void blterar_Click(object sender, EventArgs e)
        {
            lbstatus.Text = "ALTERAR";
            ppessoa.Visible = true;

            gbdados.Enabled = true;
            tbcodigo.Enabled = false;

            codBanco = cellCod;

            if (!(cellCod == 0))
            {
                cmdSql = "SELECT * FROM pessoa WHERE codpes = '" + codBanco + "'";
                var dadosS = Program.cx.ExecutaSql(cmdSql);

                if ((dadosS != null))
                {
                    linhaDados = dadosS.Rows[0];


                    tbcodigo.Text = linhaDados["codpes"].ToString().PadLeft(padraoCod, '0');
                    tbnome.Text = linhaDados["nome"].ToString();
                    mkcpfcnpj.Text = linhaDados["cpfcnpj"].ToString();
                    tbendereco.Text = linhaDados["endereco"].ToString();
                    tbbairro.Text = linhaDados["bairro"].ToString();
                    mkcep.Text = linhaDados["cep"].ToString();
                    mktelefone.Text = linhaDados["telefone"].ToString();
                    mkwhats.Text = linhaDados["whatsapp"].ToString();
                    tbemail.Text = linhaDados["email"].ToString();
                    tbnumero.Text = linhaDados["endnum"].ToString();
                    tbcodcid.Text = linhaDados["codcid"].ToString();
                    tbcomplemento.Text = linhaDados["complemento"].ToString();
                    tbcontato.Text = linhaDados["contato"].ToString();
                }
            }
            else
            {
                msg.Mensagem = "Não a dados a serem alterados";
                msg.Show();
                ppessoa.Visible = false;
            }
        }     

        private void bvisualizar_Click(object sender, EventArgs e)
        {
            lbstatus.Text   = "VISUALIZAR";
            ppessoa.Visible = true;

            tbcodigo.Enabled  = false;
            gbdados2.Enabled  = false;
            bcancela.Enabled  = true;
            bconfirma.Enabled = false;

            codBanco = cellCod;

            if (!(cellCod == 0))
            {
                cmdSql = "SELECT * FROM pessoa WHERE codpes = '" + codBanco + "'";
                var dadosS = Program.cx.ExecutaSql(cmdSql);

                if ((dadosS != null))
                {
                    linhaDados = dadosS.Rows[0];

                    tbcodigo.Text = linhaDados["codpes"].ToString().PadLeft(padraoCod, '0');
                    tbnome.Text = linhaDados["nome"].ToString();
                    mkcpfcnpj.Text = linhaDados["cpfcnpj"].ToString();
                    tbendereco.Text = linhaDados["endereco"].ToString();
                    tbbairro.Text = linhaDados["bairro"].ToString();
                    mkcep.Text = linhaDados["cep"].ToString();
                    mktelefone.Text = linhaDados["telefone"].ToString();
                    mkwhats.Text = linhaDados["whatsapp"].ToString();
                    tbemail.Text = linhaDados["email"].ToString();
                    tbnumero.Text = linhaDados["endnum"].ToString();
                    tbcodcid.Text = linhaDados["codcid"].ToString();
                    tbcomplemento.Text = linhaDados["complemento"].ToString();
                    tbcontato.Text = linhaDados["contato"].ToString();
                }
            }
            else
            {
                msg.Mensagem = "Não a dados a serem visualizados";
                msg.Show();
                ppessoa.Visible = false;
            }
        }

        private void bexcluir_Click(object sender, EventArgs e)
        {
            if (bexcluir.Text == "Desativar")
            {
                var dataHora = DateTime.Now;

                pessoas.Codigo = cellCod;
                pessoas.DataHora = dataHora.ToString();
                pessoas.Desativado = "S";
                pessoas.Desativar();

                pessoa = pessoasDAO.ListarDesativados();
                dgpessoa.DataSource = pessoa;

            }
            else if (bexcluir.Text == "Ativar")
            {
                var dataHora = DateTime.Now;


                pessoas.Codigo = cellCod;
                pessoas.DataHora = dataHora.ToString();
                pessoas.Desativado = "N";
                pessoas.Desativar();


                pessoa = pessoasDAO.ListarAtivos();
                dgpessoa.DataSource = pessoa;
            }
        }
                
        private void bfechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bpesquisar_Click(object sender, EventArgs e)
        {
            pesq = lpesq.Text;
            Pesquisar(lpesq.Text, pesq);
        }
        private void Pesquisar(string tipoPesquisa, string valorPesquisa)
        {
            encontrado = false;
            rowIndex = 0;

            foreach (DataGridViewRow row in dgpessoa.Rows)
            {
                valor = row.Cells[tipoPesquisa].Value.ToString();
                if (valor.Contains(valorPesquisa))
                {
                    dgpessoa.CurrentCell = row.Cells[tipoPesquisa];
                    dgpessoa.FirstDisplayedScrollingRowIndex = rowIndex;
                    encontrado = true;
                    break;
                }
                rowIndex++;
            }

            if (!encontrado)
            {
                msg.Mensagem = "Nenhum resultado encontrado!";
                msg.Show();
            }
        }

        private void bcancela_Click(object sender, EventArgs e)
        {
            ppessoa.Visible = false;
        }

        private void tbcodcid_KeyPress(object sender, KeyPressEventArgs e)
        {
            pb.Numerico(sender, e);
        }

        private void bconfirma_Click(object sender, EventArgs e)
        {
            pessoas.Codigo      = int.Parse(tbcodigo.Text);
            pessoas.Nome        = tbnome.Text;
            pessoas.Cpfcnpj     = mkcpfcnpj.Text;
            pessoas.Endereco    = tbendereco.Text;
            pessoas.Bairro      = tbbairro.Text;
            pessoas.Cep         = mkcep.Text;
            pessoas.Telefone    = mktelefone.Text;
            pessoas.Whatsapp    = mkwhats.Text;
            pessoas.Email       = tbemail.Text;
            pessoas.Numero      = tbnumero.Text;
            pessoas.Codcid      = int.Parse(tbcodcid.Text);
            pessoas.Complemento = tbcomplemento.Text;
            pessoas.Contato     = tbcontato.Text;

            pessoas.Gravabanco();
        }

        private void dgpessoa_SelectionChanged(object sender, EventArgs e)
        {
            if (dgpessoa.SelectedCells.Count == 0 && dgpessoa.Rows.Count > 0)
            {

                // Selecione a última linha
                lastIndex = dgpessoa.Rows.Count - 1;
                dgpessoa.Rows[lastIndex].Selected = true;
                if (dgpessoa.Rows[lastIndex].Cells.Count > 0 && dgpessoa.Rows[lastIndex].Cells[0].Value != null)
                {
                    cellCod = int.Parse(dgpessoa.Rows[lastIndex].Cells[0].Value.ToString());
                }
            }
            else if (dgpessoa.SelectedCells.Count > 0)
            {
                rowIndex = dgpessoa.SelectedCells[0].RowIndex;
                // Selecione a linha inteira
                dgpessoa.Rows[rowIndex].Selected = true;
                if (dgpessoa.Rows.Count > rowIndex && dgpessoa.Rows[rowIndex].Cells.Count > 0 && dgpessoa.Rows[rowIndex].Cells[0].Value != null)
                {
                    cellCod = int.Parse(dgpessoa.Rows[rowIndex].Cells[0].Value.ToString());
                }
            }
        }

        private void mkcep_KeyPress(object sender, KeyPressEventArgs e)
        {
            pb.Numerico(sender, e);
        }

        private void mkcpfcnpj_KeyPress(object sender, KeyPressEventArgs e)
        {
            pb.Numerico(sender, e);
        }

        private void mktelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            pb.Numerico(sender, e);
        }

        private void mkwhats_KeyPress(object sender, KeyPressEventArgs e)
        {
            pb.Numerico(sender, e);
        }

        private void baltpesq_Click(object sender, EventArgs e)
        {
            switch (lpesq.Text)
            {
                case "( Codigo )":
                    lpesq.Text = "( Nome )";
                    break;
                case "( Nome )":
                    lpesq.Text = "( Apelido )";
                    break;
                case "( Apelido )":
                    lpesq.Text = "( Cpf / Cnpj )";
                    break;
                case "( Cpf / Cnpj )":
                    lpesq.Text = "( Codigo )";
                    break;
            }
        }

        private void balternar_Click(object sender, EventArgs e)
        {
            if (labas.Text == "Pessoas Ativas")
            {
                labas.Text = "Pessoas Desativadas";
                labas.ForeColor = Color.Red;
                bexcluir.Text = "Ativar";

                bconfirma.Enabled = true;
                bincluir.Enabled = true;

                pessoa = pessoasDAO.ListarDesativados();
                dgpessoa.DataSource = pessoa;
                dgpessoa.Refresh();

                dgpessoa.DefaultCellStyle.BackColor = Color.Tomato;
            }
            else
            {
                labas.Text = "Pessoas Ativas";
                labas.ForeColor = Color.Blue;
                bexcluir.Text = "Desativar";

                bconfirma.Enabled = true;
                bincluir.Enabled = true;

                pessoa = pessoasDAO.ListarAtivos();
                dgpessoa.DataSource = pessoa;
                dgpessoa.Refresh();

                dgpessoa.DefaultCellStyle.BackColor = Color.LightSteelBlue;
            }
        }

        private async void bcidades_Click(object sender, EventArgs e)
        {
            try
            {
                // Simula uma tarefa assíncrona
                await Task.Delay(1000); // Aguarda 1 segundo (simulação de tarefa)

                // Cria e exibe o formulário
                cidade.Owner = this; // Define o formulário atual como proprietário
                cidade.Show();
            }
            catch (Exception ex)
            {
                // Trata possíveis erros
                msg.Mensagem = $"Erro: {ex.Message}" + "Erro";
                msg.Show();
            }
        }

        private void env_pessoa_Load(object sender, EventArgs e)
        {
            ppessoa.Visible  = false;
            gbdados2.Enabled = true;

            tbcodigo.Text       = string.Empty;
            tbnome.Text         = string.Empty;
            mkcpfcnpj.Text      = string.Empty;
            tbendereco.Text     = string.Empty;
            tbcodcid.Text       = string.Empty;
            mkcep.Text          = string.Empty;
            tbbairro.Text       = string.Empty;
            mktelefone.Text     = string.Empty;
            mkwhats.Text        = string.Empty;
            tbcontato.Text      = string.Empty;
            tbemail.Text        = string.Empty;

            pessoa = pessoasDAO.ListarAtivos();
            dgpessoa.DataSource = pessoa;
            dgpessoa.Refresh();

            //configuracao de data grid//
            dgpessoa.DefaultCellStyle.BackColor = Color.LightSteelBlue;
            format = "000000000";
            dgpessoa.Columns[0].DefaultCellStyle.Format = format;
            dgpessoa.AutoGenerateColumns = false;
            /////////////////////////////////////////////////////////////

            if (dgpessoa.Rows.Count > 0)
            {
                lastRowIndex = dgpessoa.Rows.Count - 1;
                lastRow = dgpessoa.Rows[lastRowIndex];

                // Definir o foco na última linha
                dgpessoa.FirstDisplayedScrollingRowIndex = lastRowIndex;
                dgpessoa.CurrentCell = dgpessoa.Rows[lastRowIndex].Cells[0];
                // Definir o foco na última linha
            }
        }

        private async void bcep_ClickAsync(object sender, EventArgs e)
        {
            // Recebe o CEP informado pelo usuário
            pessoas.Cep = mkcep.Text?.Trim();

            // Verifica se o campo CEP está preenchido
            if (!string.IsNullOrEmpty(pessoas.Cep))
            {
                try
                {
                    // Consulta o CEP
                    resultado = await consulta.ConsultarCepAsync(pessoas.Cep);

                    // Verifica se a consulta retornou um resultado válido
                    if (resultado != null && !string.IsNullOrEmpty(resultado.Cep))
                    {
                        // Preenche os campos do formulário com os dados retornados
                        tbendereco.Text = resultado.Logradouro ?? "N/A";
                        tbbairro.Text = resultado.Bairro?.Trim() ?? "N/A";
                        lbcidade.Text = (resultado.Localidade?.Trim() ?? "N/A") + " / " + (resultado.Uf?.Trim() ?? "N/A");
                        tbcodcid.Text = pb.PegaCidade(resultado.Localidade, resultado.Uf, resultado.Estado, resultado.Ibge).PadLeft(padraoCodcid, '0');
                        mkcep.Text = resultado.Cep?.Trim();
                        mkcep.Mask = "#####-###";
                    }
                    else
                    {
                        msg.Mensagem = "CEP inválido, por favor informe um CEP válido";
                        msg.Show();
                    }
                }
                catch (Exception ex)
                {
                    // Caso ocorra algum erro durante a consulta
                    msg.Mensagem = ($"Erro ao consultar CEP: {ex.Message}");
                    msg.Show();
                }
            }
            else
            {
                // Caso o campo CEP esteja vazio ou inválido
                msg.Mensagem = "CEP inválido ou campo está vazio, por favor preencher o campo corretamente.";
                msg.Show();
            }
        }
    }
}

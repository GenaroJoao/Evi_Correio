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

namespace Evi_Correio
{
    public partial class env_cidade : MaterialForm
    {
        private readonly CustomThemeManager themeManager = CustomThemeManager.Instance;

        public env_cidade()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;

            themeManager.ApplyTheme(this);

            // Força o tema inicial para LIGHT
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200,
                TextShade.WHITE);
        }
        DataTable cidades = new DataTable();

        cidadesDAO cidadesDAO = new cidadesDAO();
        Publico pb = new Publico();
        Cidades cidade = new Cidades();
        Msg msg = new Msg();

        DataRow linhaDados;

        string pesq,
               format,
               cmdSql,
               valor;

        bool encontrado;

        object lastRow;

        int cod = 0,
            padraoCod = 9,
            codBanco = 0,
            cellCod = 0,
            lastRowIndex = 0,
            rowIndex = 0,
            lastIndex = 0;

        private void dgcidade_SelectionChanged_1(object sender, EventArgs e)
        {
            if (dgcidade.SelectedCells.Count == 0 && dgcidade.Rows.Count > 0)
            {
                // Selecione a última linha
                lastIndex = dgcidade.Rows.Count - 1;
                dgcidade.Rows[lastIndex].Selected = true;
                if (dgcidade.Rows[lastIndex].Cells.Count > 0 && dgcidade.Rows[lastIndex].Cells[0].Value != null)
                {
                    int valorConvertido;
                    if (int.TryParse(dgcidade.Rows[lastIndex].Cells[0].Value.ToString(), out valorConvertido))
                    {
                        cellCod = valorConvertido;
                    }
                    else
                    {
                        // Tratar o caso de falha na conversão
                        cellCod = 0; // ou um valor padrão adequado
                    }
                }
            }
            else if (dgcidade.SelectedCells.Count > 0)
            {
                rowIndex = dgcidade.SelectedCells[0].RowIndex;
                // Selecione a linha inteira
                dgcidade.Rows[rowIndex].Selected = true;
                if (dgcidade.Rows.Count > rowIndex && dgcidade.Rows[rowIndex].Cells.Count > 0 && dgcidade.Rows[rowIndex].Cells[0].Value != null)
                {
                    int valorConvertido;
                    if (int.TryParse(dgcidade.Rows[rowIndex].Cells[0].Value.ToString(), out valorConvertido))
                    {
                        cellCod = valorConvertido;
                    }
                    else
                    {
                        // Tratar o caso de falha na conversão
                        cellCod = 0; // ou um valor padrão adequado
                    }
                }
            }
        }

        private void bincluir_Click(object sender, EventArgs e)
        {
            lbstatus.Text = "INCLUIR";
            pcidade.Visible = true;

            tbcodcid.Enabled = false;
            gbdados2.Enabled = true;
            bcancela.Enabled = true;
            bconfirma.Enabled = true;

            codBanco = 0;

            tbcodcid.Text = cod.ToString().PadLeft(padraoCod, '0');

            cmdSql = "SELECT MAX(codcid) as max_codigo FROM cidade";
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
        }

        private void tbibge_KeyPress(object sender, KeyPressEventArgs e)
        {
            pb.Numerico(sender, e);
        }

        private void baltpesq_Click(object sender, EventArgs e)
        {
            switch (lpesq.Text)
            {
                case "( Codigo )":
                    lpesq.Text = "( Cidade )";
                    break;
                case "( Cidade )":
                    lpesq.Text = "( Codigo )";
                    break;
            }
        }

        private void balternar_Click(object sender, EventArgs e)
        {
            if (labas.Text == "Cidades Ativas")
            {
                labas.Text = "Cidades Desativadas";
                labas.ForeColor = Color.Red;
                bexcluir.Text = "Ativar";

                bincluir.Enabled = false;

                cidades = cidadesDAO.ListarDesativados();
                dgcidade.DataSource = cidades;
                dgcidade.Refresh();

                dgcidade.DefaultCellStyle.BackColor = Color.Tomato;
            }
            else
            {
                labas.Text = "Cidades Ativas";
                labas.ForeColor = Color.Blue;
                bexcluir.Text = "Desativar";

                bconfirma.Enabled = true;
                bincluir.Enabled = true;

                cidades = cidadesDAO.ListarAtivos();
                dgcidade.DataSource = cidades;
                dgcidade.Refresh();
                dgcidade.DefaultCellStyle.BackColor = Color.LightSteelBlue;
            }
        }

        private void blterar_Click(object sender, EventArgs e)
        {
            lbstatus.Text   = "ALTERAR";
            pcidade.Visible = true;

            gbdados.Enabled  = true;
            tbcodcid.Enabled = false;

            codBanco = cellCod;

            if (!(cellCod == 0))
            {
                cmdSql = "SELECT * FROM cidade WHERE codcid = '" + codBanco + "'";
                var dadosS = Program.cx.ExecutaSql(cmdSql);

                if ((dadosS != null))
                {
                    linhaDados = dadosS.Rows[0];


                    tbcodcid.Text = linhaDados["codcid"].ToString().PadLeft(padraoCod, '0');
                    tbnomecid.Text = linhaDados["nomecid"].ToString();
                    tbestado.Text = linhaDados["estado"].ToString();
                    tbuf.Text = linhaDados["uf"].ToString();
                    tbibge.Text = linhaDados["ibge"].ToString();
                    tbpais.Text = linhaDados["pais"].ToString();
                }
            }
            else
            {
                msg.Mensagem = "Não a dados a serem alterados";
                msg.Show();
                pcidade.Visible = false;
            }
        }

        private void bvisualizar_Click(object sender, EventArgs e)
        {
            lbstatus.Text   = "VISUALIZAR";
            pcidade.Visible = true;

            tbcodcid.Enabled  = false;
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

                    tbcodcid.Text = linhaDados["codcid"].ToString().PadLeft(padraoCod, '0');
                    tbnomecid.Text = linhaDados["nomecid"].ToString();
                    tbestado.Text = linhaDados["estado"].ToString();
                    tbuf.Text = linhaDados["uf"].ToString();
                    tbibge.Text = linhaDados["ibge"].ToString();
                    tbpais.Text = linhaDados["pais"].ToString();
                }
            }
            else
            {
                msg.Mensagem = "Não a dados a serem visualizados";
                msg.Show();
                pcidade.Visible = false;
            }
        }

        private void bexcluir_Click(object sender, EventArgs e)
        {
            if (bexcluir.Text == "Desativar")
            {
                var dataHora = DateTime.Now;

                cidade.Codcid = cellCod;
                cidade.DataHora = dataHora.ToString();
                cidade.Desativado = "S";
                cidade.Desativar();

                cidades = cidadesDAO.ListarDesativados();
                dgcidade.DataSource = cidades;

            }
            else if (bexcluir.Text == "Ativar")
            {
                var dataHora = DateTime.Now;


                cidade.Codcid = cellCod;
                cidade.DataHora = dataHora.ToString();
                cidade.Desativado = "N";
                cidade.Desativar();


                cidades = cidadesDAO.ListarAtivos();
                dgcidade.DataSource = cidades;
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

            foreach (DataGridViewRow row in dgcidade.Rows)
            {
                valor = row.Cells[tipoPesquisa].Value.ToString();
                if (valor.Contains(valorPesquisa))
                {
                    dgcidade.CurrentCell = row.Cells[tipoPesquisa];
                    dgcidade.FirstDisplayedScrollingRowIndex = rowIndex;
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
            pcidade.Visible = false;
        }

        private void bconfirma_Click(object sender, EventArgs e)
        {
            cidade.Codcid       = int.Parse(tbcodcid.Text);
            cidade.Nomecid      = tbnomecid.Text;
            cidade.Estado       = tbestado.Text;
            cidade.Uf           = tbuf.Text;
            cidade.Ibge         = int.Parse(tbibge.Text);
            cidade.Pais         = tbpais.Text;

            cidade.GravaCidade(cidade.Codcid, cidade.Nomecid, cidade.Estado, cidade.Uf, cidade.Ibge, cidade.Pais);
            pcidade.Visible = false;
        }

        private void env_cidade_Load(object sender, EventArgs e)
        {
            pcidade.Visible  = false;
            gbdados2.Enabled = true;
            
            tbcodcid.Text  = string.Empty;
            tbnomecid.Text  = string.Empty;
            tbestado.Text  = string.Empty;
            tbuf.Text      = string.Empty;
            tbpais.Text    = string.Empty;
            tbibge.Text    = string.Empty;

            labas.ForeColor = Color.Blue;

            cidades = cidadesDAO.ListarAtivos();
            dgcidade.DataSource = cidades;
            dgcidade.Refresh();

            //configuracao de data grid//
            dgcidade.DefaultCellStyle.BackColor = Color.LightSteelBlue;
            format = "000000000";
            dgcidade.Columns[0].DefaultCellStyle.Format = format;
            dgcidade.AutoGenerateColumns = false;
            /////////////////////////////////////////////////////////////

            if (dgcidade.Rows.Count > 0)
            {
                lastRowIndex = dgcidade.Rows.Count - 1;
                lastRow = dgcidade.Rows[lastRowIndex];

                // Definir o foco na última linha
                dgcidade.FirstDisplayedScrollingRowIndex = lastRowIndex;
                dgcidade.CurrentCell = dgcidade.Rows[lastRowIndex].Cells[0];
                // Definir o foco na última linha
            }
        }
    }
}

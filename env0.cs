using Evi_Correio.Class;
using Evi_Correio.Objeto;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Evi_Correio
{
    public partial class evn0 : MaterialForm
    {
        private readonly CustomThemeManager themeManager = CustomThemeManager.Instance;

        public evn0()
        {

            InitializeComponent();

            // Exemplo: adicionando o evento Click a um botão já existente chamado 
            bpessoa.Click  -=  bpessoa_Click;
            bcidades.Click -=  bcidades_Click;
            pbconfig.Click -=  pbconfig_Click;

            bpessoa.Click  += new EventHandler(bpessoa_Click);
            bcidades.Click += new EventHandler(bcidades_Click);
            pbconfig.Click += new EventHandler(pbconfig_Click);

            themeManager.ApplyTheme(this);

            // Configura o MaterialSkinManager para gerenciar o formulário atual
            // var materialSkinManager = MaterialSkinManager.Instance;
            // materialSkinManager.AddFormToManage(this);

            // Força o tema inicial para LIGHT
            /* materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
             materialSkinManager.ColorScheme = new ColorScheme(
                 Primary.BlueGrey800, Primary.BlueGrey900,
                 Primary.BlueGrey500, Accent.LightBlue200,
                 TextShade.WHITE);*/
        }

        Msg msg = new Msg();
        Publico pb = new Publico();

        string pesq,
               format,
               cmdSql,
               valor,
               dh;

        bool encontrado = false,
             ligaHoras  = false;

        object lastRow;

        int cod = 0,
            padraoCodcid = 3,
            padraoCod = 9,
            codBanco = 0,
            cellCod = 0,
            lastRowIndex = 0,
            rowIndex = 0,
            lastIndex = 0;

        string[] DataHora;

        private async void bpessoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Simula uma tarefa assíncrona
                await Task.Delay(1000); // Aguarda 1 segundo (simulação de tarefa)
                env_pessoa pessoa = new env_pessoa();
                // Cria e exibe o formulário
                pessoa.Owner = this; // Define o formulário atual como proprietário
                pessoa.Show();
            }
            catch (Exception ex)
            {
                // Trata possíveis erros
                msg.Mensagem = $"Erro: {ex.Message}" + "Erro";
                msg.Show();
            }
        }

        private async void pbconfig_Click(object sender, EventArgs e)
        {
            try
            {
                // Simula uma tarefa assíncrona
                await Task.Delay(1000); // Aguarda 1 segundo (simulação de tarefa)
                env_config config = new env_config();
                config.Owner = this; // Define o formulário atual como proprietário
                config.Show();
            }
            catch (Exception ex)
            {
                // Trata possíveis erros
                msg.Mensagem = $"Erro: {ex.Message}" + "Erro";
                msg.Show();
            }
        }

        private void bimprimir_Click(object sender, EventArgs e)
        {
            ///metodo para abrir uma previsualizado onde pode escolhor mandar
            ///para impressora ou gerar pdf
        }

        private void bconfirma_Click(object sender, EventArgs e)
        {
           
        }

        private void evn0_Load(object sender, EventArgs e)
        {
            DateTime dataHora = DateTime.Now;
            dh = dataHora.ToString();
            DataHora = dh.Split(' ');
            ldata.Text = DataHora[0].Trim();
            ligaHoras = pb.hab_relogio();

            penvio.Visible = false;

            if (ligaHoras = false)
            {
                thoras.Enabled = false;
            }
            else
            {
                thoras.Enabled = true;
            }
        }

        private void bcancela_Click(object sender, EventArgs e)
        {
            penvio.Visible = false;
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

            foreach (DataGridViewRow row in dgenvio.Rows)
            {
                valor = row.Cells[tipoPesquisa].Value.ToString();
                if (valor.Contains(valorPesquisa))
                {
                    dgenvio.CurrentCell = row.Cells[tipoPesquisa];
                    dgenvio.FirstDisplayedScrollingRowIndex = rowIndex;
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

        private async void bcidades_Click(object sender, EventArgs e)
        {
            try
            {
                // Simula uma tarefa assíncrona
                await Task.Delay(1000); // Aguarda 1 segundo (simulação de tarefa)
                // Cria e exibe o formulário

                env_cidade cidade = new env_cidade();
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

        private void thoras_Tick(object sender, EventArgs e)
        {
            DateTime dataHora = DateTime.Now;
            dh          = dataHora.ToString();
            DataHora    = dh.Split(' ');
            lhora.Text  = DataHora[1].Trim();
        }

        private void bincluir_Click(object sender, EventArgs e)
        {
            penvio.Visible = true;
        }

        private void blterar_Click(object sender, EventArgs e)
        {
           
        }

        private void bvisualizar_Click(object sender, EventArgs e)
        {
           
        }

        private void bexcluir_Click(object sender, EventArgs e)
        {

        }

        private void bstatus_Click(object sender, EventArgs e)
        {
            ///metodo para mudar o status do lancamento
        }

        private void baltpesq_Click(object sender, EventArgs e)
        {
            switch (lpesq.Text)
            {
                case "( Codigo )":
                    lpesq.Text = "( Remetente )";
                    break;
                case "( Remetente )":
                    lpesq.Text = "( Destinatario )";
                    break;
                case "( Destinatario )":
                    lpesq.Text = "( Cidade )";
                    break;
                case "( Cidade )":
                    lpesq.Text = "( Cod. Rastreio )";
                    break;
                case "( Cod. Rastreio )":
                    lpesq.Text = "( Codigo )";
                    break;
            }
        }

        private void brastreio_Click(object sender, EventArgs e)
        {
            ///metodo para abrir uma tela para colocar o rastrio, caso ja tenho o rastrio abrir o site
            ///do correio para efetuar a consulta
            
        }
    }
}

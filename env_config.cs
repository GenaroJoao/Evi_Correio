using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace Evi_Correio
{
    public partial class env_config : MaterialForm
    {
        string qtda,
              cmdSql,
              hab_modo_escuro,
              qtdaCasa;

        bool isDarkMode;

        private readonly CustomThemeManager themeManager = CustomThemeManager.Instance;

        public env_config()
        {
            InitializeComponent();

            // Inicializa o gerenciador de temas
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);

            // Carrega as configurações salvas
            themeManager.LoadThemeSettings();

            // Aplica o tema inicial
            themeManager.ApplyTheme(this);

            // Configura os eventos dos radio buttons
            rbred.CheckedChanged += RadioButton_CheckedChanged;
            rbblue.CheckedChanged += RadioButton_CheckedChanged;
            rbgreen.CheckedChanged += RadioButton_CheckedChanged;
            rborange.CheckedChanged += RadioButton_CheckedChanged;
        }

        private void env_config_Load(object sender, EventArgs e)
        {
            if (hab_modo_escuro == "S")
            {
                msescuro.Text = "Desativar";
                hab_modo_escuro = "N";
                isDarkMode = false;
                msescuro.Checked = false;

                // Atualiza o tema com base no estado do switch
                themeManager.SetDarkMode(isDarkMode);

                // Atualiza a interface
                this.Refresh();
            }
            else if (hab_modo_escuro == "N")
            {
                msescuro.Text = "Ativar";
                hab_modo_escuro = "S";
                isDarkMode = true;
                msescuro.Checked = true;

                // Atualiza o tema com base no estado do switch
                themeManager.SetDarkMode(isDarkMode);

                // Atualiza a interface
                this.Refresh();
            }
        }

        private void msescuro_CheckedChanged(object sender, EventArgs e)
        {
            isDarkMode = msescuro.Checked;
            themeManager.SetDarkMode(isDarkMode);
            themeManager.SaveThemeSettings();

            if (isDarkMode)
            {
                msescuro.Text = "Desativar";
                hab_modo_escuro = "N";
            }
            else
            {
                msescuro.Text = "Ativar";
                hab_modo_escuro = "S";
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rb && rb.Checked)
            {
                CustomThemeManager.ThemeColor selectedTheme = CustomThemeManager.ThemeColor.Blue;

                if (rb == rbred)
                    selectedTheme = CustomThemeManager.ThemeColor.Red;
                else if (rb == rbblue)
                    selectedTheme = CustomThemeManager.ThemeColor.Blue;
                else if (rb == rbgreen)
                    selectedTheme = CustomThemeManager.ThemeColor.Green;
                else if (rb == rborange)
                    selectedTheme = CustomThemeManager.ThemeColor.Orange;

                themeManager.SetThemeColor(selectedTheme);
                themeManager.SaveThemeSettings();
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Evi_Correio
{
    public class CustomThemeManager
    {
        private static CustomThemeManager _instance;
        private bool _isDarkTheme = false;
        private ThemeColor _currentTheme = ThemeColor.Blue;
        private readonly List<MaterialForm> _managedForms = new List<MaterialForm>();

        // Cores padrão
        private readonly Color DarkBackground = Color.FromArgb(45, 45, 45);
        private readonly Color LightBackground = Color.FromArgb(240, 240, 240);
        private readonly Color DarkSurface = Color.FromArgb(50, 50, 50);
        private readonly Color LightSurface = Color.White;

        public enum ThemeColor
        {
            Red,
            Blue,
            Green,
            Orange,
            Custom
        }

        // Cores para cada tema no modo claro
        private readonly ColorScheme[] LightThemes = {
            // Vermelho
            new ColorScheme(
                Primary.Red800,
                Primary.Red900,
                Primary.Red500,
                Accent.Red200,
                TextShade.BLACK),
            // Azul
            new ColorScheme(
                Primary.Blue800,
                Primary.Blue900,
                Primary.Blue500,
                Accent.Blue200,
                TextShade.BLACK),
            // Verde
            new ColorScheme(
                Primary.Green800,
                Primary.Green900,
                Primary.Green500,
                Accent.Green200,
                TextShade.BLACK),
            // Laranja
            new ColorScheme(
                Primary.Orange800,
                Primary.Orange900,
                Primary.Orange500,
                Accent.Orange200,
                TextShade.BLACK),
            // Custom (default azul acinzentado)
            new ColorScheme(
                Primary.BlueGrey800,
                Primary.BlueGrey900,
                Primary.BlueGrey500,
                Accent.LightBlue200,
                TextShade.BLACK)
        };

        // Cores para cada tema no modo escuro
        private readonly ColorScheme[] DarkThemes = {
            // Vermelho
            new ColorScheme(
                Primary.Red900,
                Primary.Red900,
                Primary.Red500,
                Accent.Red200,
                TextShade.WHITE),
            // Azul
            new ColorScheme(
                Primary.Blue900,
                Primary.Blue900,
                Primary.Blue500,
                Accent.Blue200,
                TextShade.WHITE),
            // Verde
            new ColorScheme(
                Primary.Green900,
                Primary.Green900,
                Primary.Green500,
                Accent.Green200,
                TextShade.WHITE),
            // Laranja
            new ColorScheme(
                Primary.Orange900,
                Primary.Orange900,
                Primary.Orange500,
                Accent.Orange200,
                TextShade.WHITE),
            // Custom (default azul acinzentado escuro)
            new ColorScheme(
                Primary.BlueGrey900,
                Primary.BlueGrey900,
                Primary.BlueGrey500,
                Accent.LightBlue200,
                TextShade.WHITE)
        };

        private CustomThemeManager()
        {
            LoadThemeSettings();
        }

        public static CustomThemeManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomThemeManager();
                }
                return _instance;
            }
        }

        public bool IsDarkTheme => _isDarkTheme;
        public ThemeColor CurrentTheme => _currentTheme;

        public void SetThemeColor(ThemeColor color)
        {
            _currentTheme = color;
            SaveThemeSettings();
            UpdateAllForms();
        }

        public void ToggleDarkMode()
        {
            _isDarkTheme = !_isDarkTheme;
            SaveThemeSettings();
            UpdateAllForms();
        }

        public void SetDarkMode(bool isDark)
        {
            if (_isDarkTheme != isDark)
            {
                _isDarkTheme = isDark;
                SaveThemeSettings();
                UpdateAllForms();
            }
        }

        public void ApplyTheme(MaterialForm form)
        { 
            try
            {
                if (form == null || form.IsDisposed) return;

                var materialSkinManager = MaterialSkinManager.Instance;

                // Adiciona o form à lista de gerenciamento se ainda não estiver
                if (!_managedForms.Contains(form))
                {
                    _managedForms.Add(form);
                    form.FormClosed += (s, e) => RemoveForm(form);
                }

                // Aplica o tema (claro/escuro)
                materialSkinManager.Theme = _isDarkTheme ?
                    MaterialSkinManager.Themes.DARK :
                    MaterialSkinManager.Themes.LIGHT;

                // Aplica o esquema de cores
                materialSkinManager.ColorScheme = _isDarkTheme ?
                    DarkThemes[(int)_currentTheme] :
                    LightThemes[(int)_currentTheme];

                UpdateFormControls(form);
                form.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao aplicar tema: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateAllForms()
        {
            foreach (var form in _managedForms.ToList())
            {
                if (form != null && !form.IsDisposed)
                {
                    ApplyTheme(form);
                }
                else
                {
                    RemoveForm(form);
                }
            }
        }

        public void RemoveForm(MaterialForm form)
        {
            if (form != null && _managedForms.Contains(form))
            {
                _managedForms.Remove(form);
            }
        }

        private void UpdateFormControls(Control control)
        {
            if (control == null) return;

            try
            {
                // Atualiza controles MaterialSkin
                if (control is MaterialButton materialButton)
                {
                    materialButton.UseAccentColor = true;
                }
                else if (control is MaterialLabel materialLabel)
                {
                    materialLabel.UseAccent = true;
                }

                // Atualiza controles Windows Forms padrão
                switch (control)
                {
                    case Label label when !(control is MaterialLabel):
                        label.ForeColor = _isDarkTheme ? Color.White : Color.Black;
                        label.BackColor = Color.Transparent;
                        break;

                    case TextBox textBox:
                        textBox.ForeColor = _isDarkTheme ? Color.White : Color.Black;
                        textBox.BackColor = _isDarkTheme ? DarkSurface : LightSurface;
                        break;

                    case Panel panel:
                        UpdatePanelColors(panel);
                        break;

                    case DataGridView grid:
                        UpdateDataGridViewColors(grid);
                        break;

                    case GroupBox groupBox:
                        UpdateGroupBoxColors(groupBox);
                        break;

                    case Button button when !(button is MaterialButton):
                        button.BackColor = _isDarkTheme ? DarkSurface : LightSurface;
                        button.ForeColor = _isDarkTheme ? Color.White : Color.Black;
                        break;
                }

                // Atualiza recursivamente todos os controles filhos
                foreach (Control child in control.Controls)
                {
                    UpdateFormControls(child);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao atualizar controle: {ex.Message}");
            }
        }

        private void UpdatePanelColors(Panel panel)
        {
            // Verifica se é um painel que deve permanecer escuro
            bool isAlwaysDark = panel.Name.ToLower().Contains("dark") ||
                               panel.Name.ToLower().Contains("escuro");

            if (isAlwaysDark)
            {
                panel.BackColor = DarkBackground;
                panel.ForeColor = Color.White;
            }
            else
            {
                panel.BackColor = _isDarkTheme ? DarkBackground : LightBackground;
                panel.ForeColor = _isDarkTheme ? Color.White : Color.Black;
            }

            // Atualiza a borda se existir
            if (panel.BorderStyle == BorderStyle.FixedSingle ||
                panel.BorderStyle == BorderStyle.Fixed3D)
            {
                panel.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void UpdateDataGridViewColors(DataGridView grid)
        {
            if (grid == null) return;

            var materialSkinManager = MaterialSkinManager.Instance;
            var colorScheme = materialSkinManager.ColorScheme;

            grid.EnableHeadersVisualStyles = false;
            grid.BackgroundColor = _isDarkTheme ? DarkBackground : LightBackground;
            grid.GridColor = _isDarkTheme ? Color.FromArgb(70, 70, 70) : Color.FromArgb(200, 200, 200);

            // Estilo do cabeçalho
            grid.ColumnHeadersDefaultCellStyle.BackColor = colorScheme.PrimaryColor;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = _isDarkTheme ? Color.White : Color.Black;
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = colorScheme.DarkPrimaryColor;
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = _isDarkTheme ? Color.White : Color.Black;

            // Estilo das células
            grid.DefaultCellStyle.BackColor = _isDarkTheme ? DarkSurface : LightSurface;
            grid.DefaultCellStyle.ForeColor = _isDarkTheme ? Color.White : Color.Black;
            grid.DefaultCellStyle.SelectionBackColor = colorScheme.AccentColor;
            grid.DefaultCellStyle.SelectionForeColor = _isDarkTheme ? Color.White : Color.Black;

            // Atualiza as barras de rolagem
            grid.EnableHeadersVisualStyles = false;

            grid.Refresh();
        }

        private void UpdateGroupBoxColors(GroupBox groupBox)
        {
            if (groupBox == null) return;

            groupBox.ForeColor = _isDarkTheme ? Color.White : Color.Black;
            groupBox.BackColor = _isDarkTheme ? DarkBackground : LightBackground;

            foreach (Control control in groupBox.Controls)
            {
                if (!(control is MaterialButton))
                {
                    control.BackColor = _isDarkTheme ? DarkSurface : LightSurface;
                    control.ForeColor = _isDarkTheme ? Color.White : Color.Black;
                }
            }

            groupBox.Refresh();
        }

        public void SaveThemeSettings()
        {
            try
            {
                Properties.Settings.Default.IsDarkMode = _isDarkTheme;
                Properties.Settings.Default.ThemeColor = (int)_currentTheme;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao salvar configurações: {ex.Message}");
            }
        }

        public void LoadThemeSettings()
        {
            try
            {
                _isDarkTheme = Properties.Settings.Default.IsDarkMode;
                _currentTheme = (ThemeColor)Properties.Settings.Default.ThemeColor;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erro ao carregar configurações: {ex.Message}");
                // Use valores padrão em caso de erro
                _isDarkTheme = false;
                _currentTheme = ThemeColor.Blue;
            }
        }
    }
}
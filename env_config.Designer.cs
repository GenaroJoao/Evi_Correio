namespace Evi_Correio
{
    partial class env_config
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msescuro = new MaterialSkin.Controls.MaterialSwitch();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbcores = new System.Windows.Forms.GroupBox();
            this.rbcuston = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbblue = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbred = new MaterialSkin.Controls.MaterialRadioButton();
            this.rborange = new MaterialSkin.Controls.MaterialRadioButton();
            this.rbgreen = new MaterialSkin.Controls.MaterialRadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.materialRadioButton6 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton7 = new MaterialSkin.Controls.MaterialRadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.materialRadioButton8 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton9 = new MaterialSkin.Controls.MaterialRadioButton();
            this.groupBox1.SuspendLayout();
            this.gbcores.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // msescuro
            // 
            this.msescuro.AutoSize = true;
            this.msescuro.Depth = 0;
            this.msescuro.Location = new System.Drawing.Point(21, 27);
            this.msescuro.Margin = new System.Windows.Forms.Padding(0);
            this.msescuro.MouseLocation = new System.Drawing.Point(-1, -1);
            this.msescuro.MouseState = MaterialSkin.MouseState.HOVER;
            this.msescuro.Name = "msescuro";
            this.msescuro.Ripple = true;
            this.msescuro.Size = new System.Drawing.Size(99, 37);
            this.msescuro.TabIndex = 0;
            this.msescuro.Text = "Ativar";
            this.msescuro.UseVisualStyleBackColor = true;
            this.msescuro.CheckedChanged += new System.EventHandler(this.msescuro_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.msescuro);
            this.groupBox1.Location = new System.Drawing.Point(876, 73);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(184, 87);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modo Escuro";
            this.groupBox1.UseCompatibleTextRendering = true;
            // 
            // gbcores
            // 
            this.gbcores.Controls.Add(this.rbcuston);
            this.gbcores.Controls.Add(this.rbblue);
            this.gbcores.Controls.Add(this.rbred);
            this.gbcores.Controls.Add(this.rborange);
            this.gbcores.Controls.Add(this.rbgreen);
            this.gbcores.Location = new System.Drawing.Point(923, 167);
            this.gbcores.Name = "gbcores";
            this.gbcores.Size = new System.Drawing.Size(137, 230);
            this.gbcores.TabIndex = 2;
            this.gbcores.TabStop = false;
            this.gbcores.Text = "Cor do Sistema";
            // 
            // rbcuston
            // 
            this.rbcuston.AutoSize = true;
            this.rbcuston.Depth = 0;
            this.rbcuston.Location = new System.Drawing.Point(12, 176);
            this.rbcuston.Margin = new System.Windows.Forms.Padding(0);
            this.rbcuston.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbcuston.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbcuston.Name = "rbcuston";
            this.rbcuston.Ripple = true;
            this.rbcuston.Size = new System.Drawing.Size(90, 37);
            this.rbcuston.TabIndex = 5;
            this.rbcuston.TabStop = true;
            this.rbcuston.Text = "Custom";
            this.rbcuston.UseVisualStyleBackColor = true;
            // 
            // rbblue
            // 
            this.rbblue.AutoSize = true;
            this.rbblue.Depth = 0;
            this.rbblue.Location = new System.Drawing.Point(12, 65);
            this.rbblue.Margin = new System.Windows.Forms.Padding(0);
            this.rbblue.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbblue.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbblue.Name = "rbblue";
            this.rbblue.Ripple = true;
            this.rbblue.Size = new System.Drawing.Size(66, 37);
            this.rbblue.TabIndex = 4;
            this.rbblue.TabStop = true;
            this.rbblue.Text = "Azul";
            this.rbblue.UseVisualStyleBackColor = true;
            this.rbblue.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbred
            // 
            this.rbred.AutoSize = true;
            this.rbred.Depth = 0;
            this.rbred.Location = new System.Drawing.Point(12, 28);
            this.rbred.Margin = new System.Windows.Forms.Padding(0);
            this.rbred.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbred.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbred.Name = "rbred";
            this.rbred.Ripple = true;
            this.rbred.Size = new System.Drawing.Size(102, 37);
            this.rbred.TabIndex = 3;
            this.rbred.TabStop = true;
            this.rbred.Text = "Vermelho";
            this.rbred.UseVisualStyleBackColor = true;
            this.rbred.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rborange
            // 
            this.rborange.AutoSize = true;
            this.rborange.Depth = 0;
            this.rborange.Location = new System.Drawing.Point(12, 139);
            this.rborange.Margin = new System.Windows.Forms.Padding(0);
            this.rborange.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rborange.MouseState = MaterialSkin.MouseState.HOVER;
            this.rborange.Name = "rborange";
            this.rborange.Ripple = true;
            this.rborange.Size = new System.Drawing.Size(89, 37);
            this.rborange.TabIndex = 2;
            this.rborange.TabStop = true;
            this.rborange.Text = "Laranja";
            this.rborange.UseVisualStyleBackColor = true;
            this.rborange.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // rbgreen
            // 
            this.rbgreen.AutoSize = true;
            this.rbgreen.Depth = 0;
            this.rbgreen.Location = new System.Drawing.Point(12, 102);
            this.rbgreen.Margin = new System.Windows.Forms.Padding(0);
            this.rbgreen.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rbgreen.MouseState = MaterialSkin.MouseState.HOVER;
            this.rbgreen.Name = "rbgreen";
            this.rbgreen.Ripple = true;
            this.rbgreen.Size = new System.Drawing.Size(75, 37);
            this.rbgreen.TabIndex = 1;
            this.rbgreen.TabStop = true;
            this.rbgreen.Text = "Verde";
            this.rbgreen.UseVisualStyleBackColor = true;
            this.rbgreen.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(49, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Remetente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(49, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Casa decimal";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(139, 92);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(49, 26);
            this.textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(160, 139);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(49, 26);
            this.textBox2.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.materialRadioButton6);
            this.groupBox2.Controls.Add(this.materialRadioButton7);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox2.Location = new System.Drawing.Point(555, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(145, 81);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Habilita Horas?";
            this.groupBox2.UseCompatibleTextRendering = true;
            // 
            // materialRadioButton6
            // 
            this.materialRadioButton6.AutoSize = true;
            this.materialRadioButton6.Depth = 0;
            this.materialRadioButton6.Location = new System.Drawing.Point(72, 28);
            this.materialRadioButton6.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton6.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton6.Name = "materialRadioButton6";
            this.materialRadioButton6.Ripple = true;
            this.materialRadioButton6.Size = new System.Drawing.Size(64, 37);
            this.materialRadioButton6.TabIndex = 10;
            this.materialRadioButton6.TabStop = true;
            this.materialRadioButton6.Text = "Nao";
            this.materialRadioButton6.UseVisualStyleBackColor = true;
            // 
            // materialRadioButton7
            // 
            this.materialRadioButton7.AutoSize = true;
            this.materialRadioButton7.Depth = 0;
            this.materialRadioButton7.Location = new System.Drawing.Point(9, 28);
            this.materialRadioButton7.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton7.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton7.Name = "materialRadioButton7";
            this.materialRadioButton7.Ripple = true;
            this.materialRadioButton7.Size = new System.Drawing.Size(63, 37);
            this.materialRadioButton7.TabIndex = 9;
            this.materialRadioButton7.TabStop = true;
            this.materialRadioButton7.Text = "Sim";
            this.materialRadioButton7.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.materialRadioButton8);
            this.groupBox3.Controls.Add(this.materialRadioButton9);
            this.groupBox3.Location = new System.Drawing.Point(706, 79);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(163, 81);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sicroniza cadastro?";
            // 
            // materialRadioButton8
            // 
            this.materialRadioButton8.AutoSize = true;
            this.materialRadioButton8.Depth = 0;
            this.materialRadioButton8.Location = new System.Drawing.Point(77, 28);
            this.materialRadioButton8.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton8.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton8.Name = "materialRadioButton8";
            this.materialRadioButton8.Ripple = true;
            this.materialRadioButton8.Size = new System.Drawing.Size(64, 37);
            this.materialRadioButton8.TabIndex = 12;
            this.materialRadioButton8.TabStop = true;
            this.materialRadioButton8.Text = "Nao";
            this.materialRadioButton8.UseVisualStyleBackColor = true;
            // 
            // materialRadioButton9
            // 
            this.materialRadioButton9.AutoSize = true;
            this.materialRadioButton9.Depth = 0;
            this.materialRadioButton9.Location = new System.Drawing.Point(14, 28);
            this.materialRadioButton9.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton9.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton9.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton9.Name = "materialRadioButton9";
            this.materialRadioButton9.Ripple = true;
            this.materialRadioButton9.Size = new System.Drawing.Size(63, 37);
            this.materialRadioButton9.TabIndex = 11;
            this.materialRadioButton9.TabStop = true;
            this.materialRadioButton9.Text = "Sim";
            this.materialRadioButton9.UseVisualStyleBackColor = true;
            // 
            // env_config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 497);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbcores);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "env_config";
            this.Padding = new System.Windows.Forms.Padding(4, 89, 4, 4);
            this.Sizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Configurações";
            this.Load += new System.EventHandler(this.env_config_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbcores.ResumeLayout(false);
            this.gbcores.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSwitch msescuro;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbcores;
        private MaterialSkin.Controls.MaterialRadioButton rbblue;
        private MaterialSkin.Controls.MaterialRadioButton rbred;
        private MaterialSkin.Controls.MaterialRadioButton rborange;
        private MaterialSkin.Controls.MaterialRadioButton rbgreen;
        private MaterialSkin.Controls.MaterialRadioButton rbcuston;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton6;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton7;
        private System.Windows.Forms.GroupBox groupBox3;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton8;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton9;
    }
}
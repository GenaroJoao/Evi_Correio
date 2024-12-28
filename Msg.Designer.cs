namespace Evi_Correio
{
    partial class Msg
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
            this.lbmsg = new System.Windows.Forms.Label();
            this.bok = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // lbmsg
            // 
            this.lbmsg.AutoSize = true;
            this.lbmsg.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmsg.Location = new System.Drawing.Point(40, 164);
            this.lbmsg.Name = "lbmsg";
            this.lbmsg.Size = new System.Drawing.Size(0, 18);
            this.lbmsg.TabIndex = 0;
            // 
            // bok
            // 
            this.bok.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bok.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.bok.Depth = 0;
            this.bok.HighEmphasis = true;
            this.bok.Icon = null;
            this.bok.Location = new System.Drawing.Point(327, 354);
            this.bok.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.bok.MouseState = MaterialSkin.MouseState.HOVER;
            this.bok.Name = "bok";
            this.bok.NoAccentTextColor = System.Drawing.Color.Empty;
            this.bok.Size = new System.Drawing.Size(64, 36);
            this.bok.TabIndex = 1;
            this.bok.Text = "ok";
            this.bok.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.bok.UseAccentColor = false;
            this.bok.UseVisualStyleBackColor = true;
            this.bok.Click += new System.EventHandler(this.bok_Click);
            // 
            // Msg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bok);
            this.Controls.Add(this.lbmsg);
            this.Name = "Msg";
            this.Text = "Msg";
            this.Load += new System.EventHandler(this.Msg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbmsg;
        private MaterialSkin.Controls.MaterialButton bok;
    }
}
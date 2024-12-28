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

namespace Evi_Correio
{
    public partial class Msg : MaterialForm
    {
        public Msg()
        {
            InitializeComponent();
        }
        public string Mensagem { get; set; }

        private void bok_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Msg_Load(object sender, EventArgs e)
        {
            if (!this.Mensagem.Equals(""))
            {
                lbmsg.Text = this.Mensagem;
            }
        }
    }
}

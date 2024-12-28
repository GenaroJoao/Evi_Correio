using Evi_Correio.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evi_Correio
{
    internal static class Program
    {
        public static Conexao cx = new Conexao("localhost", "5432", "Envi_Correio", "postgres", "root");
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new evn0());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacultativosEscritorio
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            
            string[] separators = { "cun://"};
            string value = args[0];
            string[] nombre = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);            
            string strFinal = nombre[0].Remove(nombre[0].Length - 1);

            //MessageBox.Show(Uri.UnescapeDataString(strFinal));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 formulario = new Form1(Uri.UnescapeDataString(strFinal));
            
            //formulario.WindowState = FormWindowState.Maximized;
            formulario.FormBorderStyle = FormBorderStyle.FixedSingle;
            formulario.MaximizeBox = false;
            formulario.MinimizeBox = false;
            
            //formulario.ShowDialog();
                                   
            Application.Run(formulario);            
        }       
    }


   
}

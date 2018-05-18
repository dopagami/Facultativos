using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacultativosEscritorio
{
    public partial class Form1 : Form
    {
        public string parametros;
        public Form1(string args)
        {
            parametros = args;
            InitializeComponent();
        }

       

        private void Form1_LostFocus(object sender, EventArgs e)
        {
            //if (!this.Focused)
            //{
            //    this.Focus();
            //}
            this.Focus();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.cun.es");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // this.textBox1.Text = parametros;
            this.label1.Text = parametros;
        }

     
    }
}

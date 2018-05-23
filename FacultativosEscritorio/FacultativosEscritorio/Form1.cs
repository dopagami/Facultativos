using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                //IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 38217);

                Socket sSender = new Socket(ipAddress.AddressFamily, SocketType.Dgram, ProtocolType.Udp);

                try
                {
                    sSender.Connect(remoteEP);

                    //Console.WriteLine("Conectado a {0}", sender.RemoteEndPoint.ToString());

                    byte[] msg = Encoding.ASCII.GetBytes("AgendaIntervenciones");

                    int bytesSent = sSender.Send(msg);

                    //int bytesRec = sender.Receive(bytes);
                    //Console.WriteLine("Echoed test = {0}", Encoding.ASCII.GetString(bytes, 0, bytesRec));

                    sSender.Shutdown(SocketShutdown.Both);
                    sSender.Close();

                }
                catch (ArgumentNullException ane)
                {
                    throw ane;
                }
                catch (SocketException se)
                {
                    throw se;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception exc)
            {
            }

        }    
    }
}

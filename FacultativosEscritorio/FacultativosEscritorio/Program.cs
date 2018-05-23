using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
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
            string strFinal = "";

            if (args.Length > 0)
            {
                string[] separators = { "cun://" };
                string value = args[0];
                string[] nombre = value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                strFinal = nombre[0].Remove(nombre[0].Length - 1);
            }

            //MessageBox.Show(Uri.UnescapeDataString(strFinal));

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Form1 formulario = new Form1(Uri.UnescapeDataString(strFinal));

            //formulario.WindowState = FormWindowState.Maximized;
            //formulario.FormBorderStyle = FormBorderStyle.FixedSingle;
            //formulario.MaximizeBox = false;
            //formulario.MinimizeBox = false;

            //formulario.ShowDialog();

            //Application.Run(formulario);            

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

                    byte[] msg = Encoding.ASCII.GetBytes("ActualizarCun||AgendaIntervenciones||" + strFinal);

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

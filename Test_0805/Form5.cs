using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;


namespace Test_0805
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress[] ips = null;
            string hostname = textBox1.Text;
            textBox2.Text = Dns.GetHostName() + Environment.NewLine;


            try
            {
                ips = Dns.GetHostAddresses(hostname);

                foreach (IPAddress ip in ips)
                {
                    textBox2.Text += ip.ToString() + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strURI = null;
            if (textBox3.Text.Length < 1)
            {
                MessageBox.Show("請輸入 URI");
                return;
            }

            try
            {
                strURI = textBox3.Text;
                StringBuilder sb = new StringBuilder();
                Uri theUri = new Uri(strURI);

                sb.AppendLine("AbsoluteUri: " + theUri.AbsoluteUri);
                sb.AppendLine("AbsolutePath: " + theUri.AbsolutePath);
                sb.AppendLine("Authority: " + theUri.Authority);
                sb.AppendLine("Host: " + theUri.Host);
                sb.AppendLine("HostNameType: " + theUri.HostNameType.ToString());
                sb.AppendLine("IsDefaultPort: " + theUri.IsDefaultPort.ToString());
                textBox2.Text = sb.ToString();

                UriBuilder myUri = new UriBuilder(textBox3.Text);
                MessageBox.Show(myUri.Port.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

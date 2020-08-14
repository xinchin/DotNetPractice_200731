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
using System.Net.NetworkInformation;

namespace Test_0805
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            string strIP = textBox1.Text;

            Ping thePing = new Ping();


            try
            {
                PingReply theReply = thePing.Send(strIP);

                sb.AppendLine(theReply.Status.ToString());
                sb.AppendLine(theReply.Address.ToString());
                sb.AppendLine(theReply.RoundtripTime.ToString());
                textBox2.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NetworkInterface[] nwiArray = NetworkInterface.GetAllNetworkInterfaces();
            if (nwiArray.Equals(null) | nwiArray.Length < 1)
            {
                MessageBox.Show("沒有網路介面卡");
                return;
            }
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (NetworkInterface item in nwiArray)
                {
                    sb.AppendLine(item.Id.ToString());
                    sb.AppendLine("--------------------------------");
                    sb.AppendLine(item.Description.ToString());
                    sb.AppendLine("--------------------------------");
                    sb.AppendLine();
                }
                textBox2.Text = sb.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

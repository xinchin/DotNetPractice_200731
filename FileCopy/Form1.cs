using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileCopy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs1 = default(FileStream);
            FileStream fs2 = default(FileStream);
            byte[] bteRead = new byte[2048];
            long intByte = 0;
            byte[] bteMessage = new byte[129];
            string strCopyMessage = null;
            strCopyMessage = " -- copy message : from " +
                textBox1.Text + " To " +
                textBox2.Text + " -- ";
            try
            {
                fs2 = new FileStream(textBox2.Text, FileMode.OpenOrCreate, FileAccess.Write);
                bteMessage = Encoding.ASCII.GetBytes(strCopyMessage);
                fs2.Write(bteMessage, 0, bteMessage.Length);

                fs1 = new FileStream(textBox1.Text, FileMode.OpenOrCreate, FileAccess.Read);
                intByte = fs1.Length;
                fs1.Read(bteRead, 0, int.Parse(intByte.ToString()));
                fs2.Write(bteRead, 0, int.Parse(intByte.ToString()));
                fs1.Close();
                fs2.Close();
                MessageBox.Show("OK");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }
    }
}

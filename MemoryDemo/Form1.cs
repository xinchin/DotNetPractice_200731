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


namespace MemoryDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] bteArray = new byte[256];
            MemoryStream ms = default(MemoryStream);
            FileStream fs = default(FileStream);
            byte[] bteRead = null;
            try
            {
                fs = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read);
                int len = int.Parse(fs.Length.ToString());
                bteRead = new byte[len];
                fs.Read(bteRead, 0, len - 1);

                ms = new MemoryStream(len);
                ms.Write(bteRead, 0, 20);
                bteArray = ms.ToArray();
                textBox2.Text = Encoding.UTF8.GetString(bteArray);
                ms.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

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


namespace Test_0805
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = default(FileStream);
            long intRead = 0;
            long intByte = 0;
            byte[] mydata = null;
            FileInfo theFile = new FileInfo(textBox1.Text);

            StringBuilder sb = new StringBuilder();
            try
            {
                fs = theFile.OpenRead();
                intByte = fs.Length;
                mydata = new byte[intByte + 1];

                for (int i = 0; i < fs.Length; i++)
                {
                    intRead = fs.ReadByte();
                    if (-1 != intRead)
                    {
                        mydata[i] = Convert.ToByte(intRead);
                    }
                }
                textBox2.Text = Encoding.UTF8.GetString(mydata);
                fs.Close();
                MessageBox.Show("資料讀取完畢！！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string msg = "";
            msg = Encoding.ASCII.GetBytes(textBox3.Text).Length.ToString();
            toolStripLabel1.Text = msg;



            /*
                        FileStream fs = default(FileStream);
                        byte[] mydata = null;
                        int intByte = 0;
                        try
                        {
                            FileInfo theFile = new FileInfo(textBox1.Text);
                            intByte = Encoding.UTF8.GetBytes(textBox3.Text).Length;
                            mydata = new byte[intByte + 1];
                            mydata = Encoding.UTF8.GetBytes(textBox3.Text);
                            fs = theFile.OpenWrite();
                            for (int i = 0; i < intByte; i++)
                            {
                                fs.WriteByte(mydata[i]);
                            }
                            fs.Close();
                            MessageBox.Show("寫入完畢");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
            */
        }
    }
}

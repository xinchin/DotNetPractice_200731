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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            byte[] mydata = Encoding.UTF8.GetBytes(textBox1.Text);
            sb.Append(">> ");
            for (int i = 0; i < mydata.Length; i++)
            {
                sb.Append(" ");
                sb.Append(string.Format("{0:X2}", mydata[i]));

            }
            sb.Append(" |");
            toolStripLabel5.Text = sb.ToString();
            toolStripLabel6.Text = mydata.Length.ToString();

            toolStripLabel1.Text = Encoding.ASCII.GetBytes(textBox1.Text).Length.ToString();
            toolStripLabel2.Text = Encoding.UTF8.GetBytes(textBox1.Text).Length.ToString();
            toolStripLabel3.Text = Encoding.UTF32.GetBytes(textBox1.Text).Length.ToString();
            toolStripLabel4.Text = Encoding.Unicode.GetBytes(textBox1.Text).Length.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            FileStream fs = default(FileStream);
            FileStream fs2 = default(FileStream);
            byte[] mydata = null;

            StringBuilder sb = new StringBuilder();
            sb.Append(">> ");

            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                textBox2.Text = openFileDialog1.FileName;

                try
                {
                    FileInfo theFile = new FileInfo(textBox2.Text);
                    fs = theFile.OpenRead();

                    mydata = new byte[fs.Length];

                    fs.Read(mydata, 0, int.Parse(fs.Length.ToString()));

                    for (int i = 0; i < mydata.Length; i++)
                    {
                        sb.Append(string.Format(" {0:x2}", mydata[i]));
                    }

                    textBox3.Text = sb.ToString();

                    toolStripLabel1.Text = theFile.Length.ToString();
                    toolStripLabel2.Text = fs.Length.ToString();
                    toolStripLabel3.Text = mydata.Length.ToString();
                    toolStripLabel4.Text = mydata.GetUpperBound(0).ToString();

                    fs.Close();
                    if (DialogResult.OK == saveFileDialog1.ShowDialog())
                    {
                        fs2 = File.OpenWrite(saveFileDialog1.FileName);
                        fs2.Write(mydata, 0, int.Parse(mydata.Length.ToString()));

                    }


                    //this.BackgroundImage = Image.FromStream(fs);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            FileStream fs = default(FileStream);


            if (DialogResult.OK == saveFileDialog1.ShowDialog())
            {
                FileInfo theFile = new FileInfo(saveFileDialog1.FileName);
                fs = theFile.Create();


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {


            FileStream fs = default(FileStream);
            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            try
            {
                if (DialogResult.OK == openFileDialog1.ShowDialog())
                {
                    textBox4.Text = openFileDialog1.FileName;
                    FileInfo theFile = new FileInfo(textBox4.Text);
                    fs = theFile.OpenRead();

                    //fs.Read(mydata, 0, int.Parse(fs.Length.ToString()));

                    int[] mydata = new int[int.Parse(fs.Length.ToString())];

                    for (int i = 0; i < fs.Length; i++)
                    {
                        mydata[i] = fs.ReadByte();
                        sb.Append(string.Format("{0:X2}\t", mydata[i] ).ToString());
                        sb2.Append(string.Format("{0}\t", mydata[i] ).ToString());
                    }

                    fs.Close();
                    textBox3.Text = sb.ToString();
                    textBox5.Text = sb2.ToString();

                    MessageBox.Show("...End...");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

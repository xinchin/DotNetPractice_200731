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
using System.Security;


namespace Test_0805
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string theLine = "";
            try
            {
                if (DialogResult.OK == openFileDialog1.ShowDialog())
                {

                    using (StreamReader sr = File.OpenText(openFileDialog1.FileName))
                    {


                        do
                        {
                            theLine = sr.ReadLine();
                            textBox2.Text += theLine + Environment.NewLine;
                            theLine = sr.ReadLine();

                        } while (null != theLine);

                        //while (null != theLine)
                        //{
                        //    textBox2.Text += theLine + Environment.NewLine;
                        //    theLine = sr.ReadLine();
                        //}

                        sr.Close();

                        //textBox2.Text = sr.ReadToEnd();
                        //sr.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string strFile = "";
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                strFile = openFileDialog1.FileName;

                StreamWriter sw = new StreamWriter(strFile);

                try
                {
                    sw.Write(textBox2.Text);
                    sw.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string strFile = "";
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                strFile = openFileDialog1.FileName;
                textBox1.Text = strFile;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string strContent = File.ReadAllText(textBox1.Text);
            textBox2.Text = strContent;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            File.WriteAllText(textBox1.Text, textBox2.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Image img001;
            string strFile = "";
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                strFile = openFileDialog1.FileName;

                this.BackgroundImage = Image.FromStream(new MemoryStream(File.ReadAllBytes(strFile)));


                using (FileStream fs = File.OpenRead(strFile))
                {
                    try
                    {
                        Byte[] myData = new Byte[(int)(fs.Length)];
                        fs.Read(myData, 0, (int)fs.Length);

                        MemoryStream ms = new MemoryStream(myData);
                        ms.Position = 0;
                        img001 = Image.FromStream(ms);
                        this.BackgroundImage = img001;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string strPath = "";

            this.toolStripLabel1.Text = "";

            try
            {
                strPath = Path.GetTempFileName(); ;
                this.toolStripLabel1.Text = strPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            toolStripLabel1.Text = Path.GetFullPath(".");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace AsyncCallbackDemo
{
    public partial class Form1 : Form
    {

        private FileStream myFileStream = default(FileStream);
        private Boolean blnProcess = default(Boolean);
        private string nl = Environment.NewLine;
        private byte[] bteData = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void ReadBulkData()
        {
            long intI = 0;
            string strFilePathe = null;
            try
            {
                strFilePathe = textBox1.Text;
                myFileStream = new FileStream(strFilePathe, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite, 1024, true);
                AsyncCallback myAC = new AsyncCallback(AsyncReadCallBack);
                blnProcess = true;
                myFileStream.BeginRead(bteData, 0, 1024, myAC, null);
                ProcessMessage("R");
                myFileStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProcessMessage(string strRW)
        {
            string strMessage = "";
            if (strRW == "R")
            {
                strMessage = "Read";
            }
            else
            {
                strMessage = "Write";
            }
            while (blnProcess == true)
            {
                textBox2.Text = textBox2.Text + "---" + strMessage + "----" + nl;
            }
            Thread.Sleep(1000);
            textBox2.Text = textBox2.Text + "------" + blnProcess.ToString() + "------" + nl;

        }

        private void AsyncReadCallBack(IAsyncResult myIar)
        {
            long lngRead = 0;
            Thread.Sleep(1000);
            blnProcess = false;
            lngRead = myFileStream.EndRead(myIar);
            textBox2.Text = textBox2.Text + "----" + lngRead.ToString() + "-------" + nl;
        }

        private void AsyncWriteCallBack(IAsyncResult myIar)
        {
            Thread.Sleep(1000);
            blnProcess = false;
            myFileStream.EndWrite(myIar);
            textBox2.Text = textBox2.Text + "---- Writed -------" + nl;
        }




        private void button1_Click(object sender, EventArgs e)
        {
            Thread myThread = default(Thread);
            TextBox.CheckForIllegalCrossThreadCalls = false;
            textBox2.Text = "";
            try
            {
                if (true == radioButton1.Checked)
                {
                    myThread = new Thread(WriteBulkData);
                    myThread.Start();

                }
                else if (true == radioButton2.Checked)
                {
                    myThread = new Thread(ReadBulkData);
                    myThread.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void WriteBulkData()
        {
            long intI = 0;
            string strFilePath = null;
            try
            {
                strFilePath = textBox1.Text;
                myFileStream = new FileStream(strFilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite, 1024, true);
                AsyncCallback myAC = new AsyncCallback(AsyncWriteCallBack);
                blnProcess = true;
                bteData = new byte[int.Parse(myFileStream.Length.ToString())];
                myFileStream.BeginWrite(bteData, 0, 1024, myAC, null);
                ProcessMessage("W");
                myFileStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

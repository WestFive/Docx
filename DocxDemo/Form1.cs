using Novacode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocxDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenProcess(System.AppDomain.CurrentDomain.BaseDirectory + "/Template.docx");
        }


        public void OpenProcess(string fileName)
        {
            Process process = new Process();
            ProcessStartInfo processStartInfo = new ProcessStartInfo(fileName);
            process.StartInfo = processStartInfo;
            process.StartInfo.UseShellExecute = true;
            process.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DocX docX =DocX.Load(System.AppDomain.CurrentDomain.BaseDirectory + "/Template.docx");

            //use underline
            docX.InsertAtBookmarkWithFormat("the words will replace .2 space", "BookMark1");
            //do not use underline
            //docX.InsertAtBookmark("the words will replace .2 space", "BookMark1");
            string savePath = System.AppDomain.CurrentDomain.BaseDirectory + "/" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".docx";
            docX.SaveAs(savePath);
            OpenProcess(savePath);

        }
    }
}

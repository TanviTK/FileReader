using PDFReaderLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFReader
{
    public partial class UI : Form
    {
        //Keep pdf file location
        string pdfPath = System.String.Empty;

        public UI()
        {
            InitializeComponent();
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            var dummy = new FileReaderLibrary.ProcessManager();
            dummy.ProcessFiles();
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.CheckFileExists = true;
            //openFileDialog.AddExtension = true;
            //openFileDialog.Multiselect = false;
            //openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";

            //if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    pdfPath = openFileDialog.FileName;
            //    TxtPdf.Text = Path.GetFileName(pdfPath);
            //}
        }
    }
}

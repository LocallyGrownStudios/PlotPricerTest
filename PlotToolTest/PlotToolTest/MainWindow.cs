using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.pdfclown.files;
using org.pdfclown.objects;
using org.pdfclown.tools;
using org.pdfclown.documents;

namespace PlotToolTest
{
    public partial class MainWindow : Form
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        public void buttonX1_Click(object sender, EventArgs e)
        {
            itemPanel1.Controls.Clear();                                                                              // Clears everything in itemPanel1
            textboxFileName.Clear();                                                                                  // Clears content of textboxFileName                                                                               // Clears content of textboxNumPages
            openFileDialog1.InitialDirectory = "c:\\";                                                                // Sets the default location for file browser to start in
            openFileDialog1.Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*";                                   // Sets the filter of selectable files
            openFileDialog1.FilterIndex = 1;                                                                          // Sets the default file type to be selected
            openFileDialog1.RestoreDirectory = true;
            DialogResult result = openFileDialog1.ShowDialog();
            string currentFileName = openFileDialog1.FileName;
            if (result == DialogResult.OK)
            {
                textboxFileName.Text += currentFileName;
            }
        }

        private void textboxFileName_TextChanged(object sender, EventArgs e)
        {
        }
    }
}

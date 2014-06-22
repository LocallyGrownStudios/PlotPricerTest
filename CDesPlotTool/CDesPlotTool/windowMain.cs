using System;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.pdfclown.files;
using org.pdfclown.objects;
using org.pdfclown.tools;
using org.pdfclown.documents;
using org.pdfclown.documents.contents;
using org.pdfclown.documents.contents.objects;
using org.pdfclown.documents.interaction;
using org.pdfclown.documents.interchange.metadata;
using org.pdfclown.documents.interaction.viewer;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using io = System.IO;
using files = org.pdfclown.files;
using bytes = org.pdfclown.bytes;

namespace CDesPlotTool
{
    public partial class windowMain : Form
    {
        public windowMain()
        {
            InitializeComponent();
        }

        private void windowMain_Load(object sender, EventArgs e)
        {

        }

        private void textboxFileName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textboxFileSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void textboxNumPages_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonFileBrowse_Click(object sender, EventArgs e)
        {
            itemPanel1.Controls.Clear();
            textboxFileName.Clear();
            textboxFileSize.Clear();
            textboxNumPages.Clear();
            openFileDialog1.InitialDirectory = "c:\\";                                                                // Sets the default location for file browser to start in
            openFileDialog1.Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*";                                   // Sets the filter of selectable files
            openFileDialog1.FilterIndex = 1;                                                                          // Sets the default file type to be selected
            openFileDialog1.RestoreDirectory = true;                                                                  // Sets wheter or not default directory is restored each time
            DialogResult result = openFileDialog1.ShowDialog();
            const int postScriptPoints = 72;
            int size = -1;                                                                                            // Assign size as an integer
            double sizeKB = -1.0;                                                                                     // Assign sizeKB as a double
            double sizeMB = -1.0;                                                                                     // Assign sizeMB as a double
            double sizeGB = -1.0;                                                                                     // Assign sizeGB as a double
            string file = openFileDialog1.FileName;

            try
            {
                string text = System.IO.File.ReadAllText(file);                                                                 // Assigns text to read selected file legnth
                size = text.Length;                                                                                   // Assigns size
                sizeKB = text.Length / 1024;                                                                          // Calculate KB
                sizeMB = sizeKB / 1024;                                                                               // Calculate MB
                sizeGB = sizeMB / 1024;                                                                               // Calculate GB
                sizeKB = Math.Round(sizeKB, 2);                                                                       // Round sizeKB to 2 decimal places
                sizeGB = Math.Round(sizeGB, 2);                                                                       // Round sizeGB to 2 decimal places
                sizeMB = Math.Round(sizeMB, 2);                                                                       // Round sizeMB to 2 decimal places

            }
            catch (System.IO.IOException)                                                                                        // Catch exceptions
            {
            }
            string sourceFilePath = openFileDialog1.FileName;
            string currentFilePath = openFileDialog1.FileName;
            using (File currentFile = new File(openFileDialog1.FileName))
            using (File sourceFile = new File(sourceFilePath))
            {
                PdfReader reader = new PdfReader(openFileDialog1.FileName);
                iTextSharp.text.Rectangle mediabox = reader.GetPageSize(1);
                Pages sourcePages = sourceFile.Document.Pages;
                int sourcePagesCount = sourcePages.Count;
                org.pdfclown.documents.Document documentName = currentFile.Document;
                Pages documentPages = documentName.Pages;
                int documentPageCount = documentPages.Count;
                HashSet<PdfReference> visitedReferences = new HashSet<PdfReference>();
                long incrementalDataSize = 0;
                foreach (Page page in documentPages)
                {
                    long pageFullDataSize = PageManager.GetSize(page);
                    long pageDifferentialDataSize = PageManager.GetSize(page, visitedReferences);
                    incrementalDataSize += pageDifferentialDataSize;
                    TextBox pageSizes = new TextBox();
                    pageSizes.Name = "pageSize_" + this.Controls.Count + 1;
                    pageSizes.Location = new System.Drawing.Point(10, 25 * itemPanel1.Controls.Count);
                    pageSizes.Text += mediabox.Height / postScriptPoints;
                    pageSizes.Text += " x ";
                    pageSizes.Text += mediabox.Width / postScriptPoints;
                    itemPanel1.Controls.Add(pageSizes);
                }
                textboxFileName.Text += file;
                textboxNumPages.Text += sourcePages.Count;
            }
            if (sizeMB >= 1)                                                                                            // If size is larger than or equal to 1 KB
            {
                textboxFileSize.Text += sizeMB;                                                                              // Write size as MB to textBoxX2
                textboxFileSize.Text += " MB";                                                                                // Write MB after size to textBoxX2
            }
            else if (sizeGB >= 1)                                                                                       // Else if size is  larger tgab or equal to 1 GB
            {
                textboxFileSize.Text += sizeGB;                                                                               // Write size as GB to textBoxX2  
                textboxFileSize.Text += " GB";                                                                                // Write GB after size to textBoxX2
            }
            else
            {
                textboxFileSize.Text += size / 1024;                                                                           // Else write size as KB to textBoxX2
                textboxFileSize.Text += " KB";                                                                                 // Write KB after size to textBoxX2   
            }
        }

    }
}

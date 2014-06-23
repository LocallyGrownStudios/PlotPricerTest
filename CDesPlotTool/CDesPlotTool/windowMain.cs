using System;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Web;
using System.Web.UI;
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


//  TO DO
// Add oversize file catch
// Dynamic update of price from radial buttons
// General clean up and seperation of code
// Add functionality for multiple fiel selection, place in own container for auto population
// Add functionality to populate individual containers for each file
// Add functionality to select different papers for different files
// Add functionality for laser printer prices
// Add functionality to save file as reduced size, rasterized and x1-a compatible
// ** possible page viewer
// ** Possible functionality to submit plots/prints
// ** Possible functionality to charge themselves for plots/prints

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

        public void buttonFileBrowse_Click(object sender, EventArgs e)
        {
            itemPanel1.Controls.Clear();                                                                              // Clears everything in itemPanel1
            textboxFileName.Clear();                                                                                  // Clears content of textboxFileName
            textboxFileSize.Clear();                                                                                  // Clears content of textboxFileSize
            textboxNumPages.Clear();                                                                                  // Clears content of textboxNumPages
            openFileDialog1.InitialDirectory = "c:\\";                                                                // Sets the default location for file browser to start in
            openFileDialog1.Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*";                                   // Sets the filter of selectable files
            openFileDialog1.FilterIndex = 1;                                                                          // Sets the default file type to be selected
            openFileDialog1.RestoreDirectory = true;                                                                  // Sets wheter or not default directory is restored each time
            const double postScriptPoints = 72.00;                                                                    // Assign postScriptPoints as a constant int
            int size = -1;                                                                                            // Assign size as an integer
            double sizeKB = -1.0;                                                                                     // Assign sizeKB as a double
            double sizeMB = -1.0;                                                                                     // Assign sizeMB as a double
            double sizeGB = -1.0;                                                                                     // Assign sizeGB as a double
            double totalCost = 0.00;
            DialogResult result = openFileDialog1.ShowDialog();                                                       // Opens file explore window
            string file = openFileDialog1.FileName;
            using (File currentFile = new File(openFileDialog1.FileName))                                             // Using selected file as current file      
            using (File sourceFile = new File(openFileDialog1.FileName))                                              // Using selected file as source file
            {
                HashSet<PdfReference> visitedReferences = new HashSet<PdfReference>();
                PdfReader reader = new PdfReader(openFileDialog1.FileName);
                iTextSharp.text.Rectangle mediabox = reader.GetPageSize(1);
                org.pdfclown.documents.Document documentName = currentFile.Document;
                Pages sourcePages = sourceFile.Document.Pages;
                Pages documentPages = documentName.Pages;
                int sourcePagesCount = sourcePages.Count;
                int documentPageCount = documentPages.Count;
                long incrementalDataSize = 0;
                foreach (org.pdfclown.documents.Page page in documentPages)
                {
                    long pageFullDataSize = PageManager.GetSize(page);
                    long pageDifferentialDataSize = PageManager.GetSize(page, visitedReferences);
                    incrementalDataSize += pageDifferentialDataSize;
                    TextBox pageSizes = new TextBox();
                    pageSizes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                    pageSizes.Enabled = false;
                    pageSizes.Name = "pageCost_" + this.Controls.Count + 1;
                    pageSizes.Location = new System.Drawing.Point(25, 10 + (25 * itemPanel1.Controls.Count));
                    TextBox pageCost = new TextBox();
                    pageCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                    pageCost.Enabled = false;
                    pageCost.Name = "pageSize_" + this.Controls.Count + 1;
                    pageCost.Location = new System.Drawing.Point(150, 10 + (25 * itemPanel1.Controls.Count));
                    if (mediabox.Height / postScriptPoints <= 42)
                    {
                        if (mediabox.Height / postScriptPoints < mediabox.Width / postScriptPoints)
                        {
                            pageSizes.Text += mediabox.Height / postScriptPoints;
                            pageSizes.Text += " x ";
                            pageSizes.Text += mediabox.Width / postScriptPoints;
                            if (paperSelectBond.Checked)
                            {
                                pageCost.Text += "$ ";
                                totalCost = mediabox.Height / postScriptPoints * 1/12;
                                totalCost = Math.Round(totalCost, 2);
                                pageCost.Text += string.Format("{0:f2}", totalCost);
                            }
                            else if (paperSelectMatte.Checked)
                            {
                                pageCost.Text += "$ ";
                                totalCost = mediabox.Height / postScriptPoints * 1 / 4;
                                totalCost = Math.Round(totalCost, 2);
                                pageCost.Text += string.Format("{0:f2}", totalCost);
                            }
                            else if (paperSelectSatin.Checked)
                            {
                                pageCost.Text += "$ ";
                                totalCost = mediabox.Height / postScriptPoints * 1 / 4;
                                totalCost = Math.Round(totalCost, 2);
                                pageCost.Text += string.Format("{0:f2}", totalCost);
                            }
                            else
                            {
                                pageCost.Text += "Please choose paper type";
                            }
                            itemPanel1.Controls.Add(pageSizes);
                            itemPanel1.Controls.Add(pageCost);
                        }
                    }
                    else
                    {
                        pageSizes.Text += mediabox.Width / postScriptPoints;
                        pageSizes.Text += " x ";
                        pageSizes.Text += mediabox.Height / postScriptPoints;
                        if (paperSelectBond.Checked)
                        {
                            pageCost.Text += "$ ";
                            totalCost = mediabox.Height / postScriptPoints * 1 / 12;
                            totalCost = Math.Round(totalCost, 2);
                            pageCost.Text += string.Format("{0:f2}", totalCost);
                        }
                        else if (paperSelectMatte.Checked)
                        {
                            pageCost.Text += "$ ";
                            totalCost = mediabox.Height / postScriptPoints * 1 / 4;
                            totalCost = Math.Round(totalCost, 2);
                            pageCost.Text += string.Format("{0:f2}", totalCost);
                        }
                        else if (paperSelectSatin.Checked)
                        {
                            pageCost.Text += "$ ";
                            totalCost = mediabox.Height / postScriptPoints * 1 / 4;
                            totalCost = Math.Round(totalCost, 2);
                            pageCost.Text += string.Format("{0:f2}", totalCost);
                        }
                        else
                        {
                            pageCost.Text += "Please choose paper type";
                        }
                        itemPanel1.Controls.Add(pageSizes);
                        itemPanel1.Controls.Add(pageCost);
                    }

                }

                try
                {

                    string text = System.IO.File.ReadAllText(file);                                                        // Assigns text to read selected file legnth
                    size = text.Length;                                                                                    // Assigns size
                    sizeKB = text.Length / 1024;                                                                           // Calculate KB
                    sizeMB = sizeKB / 1024;                                                                                // Calculate MB
                    sizeGB = sizeMB / 1024;                                                                                // Calculate GB
                    sizeKB = Math.Round(sizeKB, 2);                                                                        // Round sizeKB to 2 decimal places
                    sizeGB = Math.Round(sizeGB, 2);                                                                        // Round sizeGB to 2 decimal places
                    sizeMB = Math.Round(sizeMB, 2);                                                                        // Round sizeMB to 2 decimal places

                    if (sizeMB >= 1)                                                                                       // If size is larger than or equal to 1 KB
                    {
                        textboxFileSize.Text += sizeMB;                                                                    // Write size as MB to textboxFileSize
                        textboxFileSize.Text += " MB";                                                                     // Write MB after size to textboxFileSize
                    }
                    else if (sizeGB >= 1)                                                                                  // Else if size is  larger tgab or equal to 1 GB
                    {
                        textboxFileSize.Text += sizeGB;                                                                    // Write size as GB to textboxFileSize  
                        textboxFileSize.Text += " GB";                                                                     // Write GB after size to textboxFileSize
                    }
                    else
                    {
                        textboxFileSize.Text += size / 1024;                                                               // Else write size as KB to textboxFileSize
                        textboxFileSize.Text += " KB";                                                                     // Write KB after size to textboxFileSize
                    }
                    textboxFileName.Text += file;                                                                          // Write file path and name to textboxFileName
                    textboxNumPages.Text += sourcePages.Count;
                }
                catch (System.IO.IOException)
                {

                }

            }

        }

        public void paperSelectBond_CheckedChanged(object sender, EventArgs e)
        {
            // update price
        }

        public void paperSelectMatte_CheckedChanged(object sender, EventArgs e)
        {
            // update price
        }

        public void paperSelectSatin_CheckedChanged(object sender, EventArgs e)
        {
            // update price
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using org.pdfclown.files;
using org.pdfclown.objects;
using org.pdfclown.tools;
using org.pdfclown.documents;
using org.pdfclown.documents.contents;
using org.pdfclown.documents.contents.objects;
using org.pdfclown.documents.interaction;
using org.pdfclown.documents.interchange.metadata;
using org.pdfclown.documents.interaction.viewer;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void browseForFile_Click(object sender, RoutedEventArgs e)
        {
            OpenNewFile(true);
        }

        private void OpenNewFile(bool openNewFile)
        {
            try
            {
                fileNameDisplay.Clear();
                fileSizeDisplay.Clear();
                numPagesDisplay.Clear();
                dlg.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                dlg.Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*";
                dlg.FilterIndex = 1;
                dlg.RestoreDirectory = true;
                Nullable<bool> result = dlg.ShowDialog();
                if (result == true)
                {
                    GetFileName(true);
                    GetNumPages(true);
                    GetFileSize(true);
                    GetPageSizes(true);
                }
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("There was a problem writing the current files data. Please verify file still exists and try again.");
            }
        }

        private void GetFileName(bool getFileName)
        {
            try
            {
                string fileName = dlg.FileName;
                fileNameDisplay.Clear();
                fileNameDisplay.Text += fileName;
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("There was a problem reading the selectd file. Please check the file and try again.");
            }
        }

        private void GetFileSize(bool getFileSize)
        {
            try
            {
                string text = System.IO.File.ReadAllText(dlg.FileName);
                int size = text.Length;
                double sizeKB = text.Length / 1024;
                double sizeMB = sizeKB / 1024;
                double sizeGB = sizeMB / 1024;
                sizeKB = Math.Round(sizeKB, 2);
                sizeGB = Math.Round(sizeGB, 2);
                sizeMB = Math.Round(sizeMB, 2);

                if (sizeGB >= 1)
                {
                    fileSizeDisplay.Clear();
                    fileSizeDisplay.TextAlignment = TextAlignment.Right;
                    fileSizeDisplay.Text += sizeGB;
                    fileSizeDisplay.Text += " GB";
                }
                else if (sizeMB >= 1)
                {
                    fileSizeDisplay.Clear();
                    fileSizeDisplay.TextAlignment = TextAlignment.Right;
                    fileSizeDisplay.Text += sizeMB;
                    fileSizeDisplay.Text += " MB";

                }
                else
                {
                    fileSizeDisplay.Clear();
                    fileSizeDisplay.TextAlignment = TextAlignment.Right;
                    fileSizeDisplay.Text += sizeKB;
                    fileSizeDisplay.Text += " KB";
                }
            }
            catch(System.IO.IOException)
            {
                MessageBox.Show("There was an error reading the file size. Please check the file and try again.");
            }
        }

        private void GetNumPages(bool getNumPages)
        {
            try
            {
                int numPages = 0;
                string filePages = dlg.FileName;
                using (File currentFile = new File(filePages))
                {
                    HashSet<PdfReference> visitedReferences = new HashSet<PdfReference>();
                    org.pdfclown.documents.Document documentName = currentFile.Document;
                    Pages documentPages = documentName.Pages;
                    numPages = documentPages.Count;
                    numPagesDisplay.Clear();
                    numPagesDisplay.TextAlignment = TextAlignment.Right;
                    numPagesDisplay.Text += numPages;
                }
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("There was an error reading the number of pages. Please check the file and try again");
            }
        }

        private void GetPageSizes(bool getPageSizes)
        {
            try
            {
                int pageNum = 0;
                long incrementalDataSize = 0;
                const double postScriptPoints = 72.00;
                string filePageSize = dlg.FileName;
                using (File currentFile = new File(dlg.FileName))
                {
                    HashSet<PdfReference> visitedReferences = new HashSet<PdfReference>();
                    PdfReader reader = new PdfReader(filePageSize);
                    org.pdfclown.documents.Document documentName = currentFile.Document;
                    Pages documentPages = documentName.Pages;
                    int documentPageCount = documentPages.Count;
                    foreach (org.pdfclown.documents.Page page in documentPages)
                    {
                        pageNum++;
                        iTextSharp.text.Rectangle mediabox = reader.GetPageSize(pageNum);
                        long pageFullDataSize = PageManager.GetSize(page);
                        long pageDifferentialDataSize = PageManager.GetSize(page, visitedReferences);
                        incrementalDataSize += pageDifferentialDataSize;
                        try
                        {
                            if (mediabox.Height / postScriptPoints < mediabox.Height / postScriptPoints)
                            {
                                if (mediabox.Height / postScriptPoints <= 42)
                                {
                                    filePageSizes.Text += mediabox.Height / postScriptPoints;
                                    filePageSizes.Text += " x";
                                    filePageSizes.Text += mediabox.Width / postScriptPoints;
                                }
                            }
                            else
                            {
                                filePageSizes.Text += mediabox.Width / postScriptPoints;
                                filePageSizes.Text += " x ";
                                filePageSizes.Text += mediabox.Height / postScriptPoints;
                            }
                        }
                        catch
                        {
                            if (mediabox.Height / postScriptPoints > 42)
                            {
                                if (mediabox.Width / postScriptPoints > 42)
                                {
                                    MessageBox.Show("One or more pages is too large. Currently the maximum printable size is 42 inches.");
                                }
                            }
                            {

                            }
                        }
                    }
                }
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("There was a problem reading the page sizes. Please check the file and try again.");
            }

        }

        private void CalculateCost(bool calculateCost)
        {
            try
            {

            }
            catch
            {
            }
        }


    }
}

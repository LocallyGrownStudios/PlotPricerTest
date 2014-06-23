using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlotToolTest
{
    class ButtonHandler : MainWindow
    {
        public int fileSize;
        int fileHeight;
        public int fileName;
        string fileWidth;
        string numPages;
        string totalCost;
        string pageCost;

        public int FileSize 
        {
            get
            {
                return this.fileSize;
            }
            set 
            {
                fileSize = 12;
            }
        }

        public int FileName
        {
            get
            {
                return this.fileName;
            }

            set
            {
                fileName = 12;
            }
        }


    }
}

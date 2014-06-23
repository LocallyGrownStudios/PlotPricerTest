namespace CDesPlotTool
{
    partial class windowMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonFileBrowse = new DevComponents.DotNetBar.ButtonX();
            this.textboxFileName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textboxFileSize = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textboxNumPages = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.paperSelectSatin = new System.Windows.Forms.RadioButton();
            this.paperSelectMatte = new System.Windows.Forms.RadioButton();
            this.paperSelectBond = new System.Windows.Forms.RadioButton();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.SuspendLayout();
            // 
            // buttonFileBrowse
            // 
            this.buttonFileBrowse.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonFileBrowse.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonFileBrowse.Location = new System.Drawing.Point(424, 15);
            this.buttonFileBrowse.Name = "buttonFileBrowse";
            this.buttonFileBrowse.Size = new System.Drawing.Size(53, 20);
            this.buttonFileBrowse.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.buttonFileBrowse.TabIndex = 0;
            this.buttonFileBrowse.Text = "...";
            this.buttonFileBrowse.Click += new System.EventHandler(this.buttonFileBrowse_Click);
            // 
            // textboxFileName
            // 
            this.textboxFileName.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            // 
            // 
            // 
            this.textboxFileName.Border.Class = "TextBoxBorder";
            this.textboxFileName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textboxFileName.Enabled = false;
            this.textboxFileName.Location = new System.Drawing.Point(12, 15);
            this.textboxFileName.Name = "textboxFileName";
            this.textboxFileName.PreventEnterBeep = true;
            this.textboxFileName.Size = new System.Drawing.Size(300, 20);
            this.textboxFileName.TabIndex = 1;
            this.textboxFileName.TextChanged += new System.EventHandler(this.textboxFileName_TextChanged);
            // 
            // textboxFileSize
            // 
            this.textboxFileSize.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            // 
            // 
            // 
            this.textboxFileSize.Border.Class = "TextBoxBorder";
            this.textboxFileSize.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textboxFileSize.Cursor = System.Windows.Forms.Cursors.No;
            this.textboxFileSize.Enabled = false;
            this.textboxFileSize.Location = new System.Drawing.Point(318, 15);
            this.textboxFileSize.Name = "textboxFileSize";
            this.textboxFileSize.PreventEnterBeep = true;
            this.textboxFileSize.ReadOnly = true;
            this.textboxFileSize.Size = new System.Drawing.Size(56, 20);
            this.textboxFileSize.TabIndex = 2;
            this.textboxFileSize.TextChanged += new System.EventHandler(this.textboxFileSize_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textboxNumPages
            // 
            this.textboxNumPages.AccessibleRole = System.Windows.Forms.AccessibleRole.StaticText;
            // 
            // 
            // 
            this.textboxNumPages.Border.Class = "TextBoxBorder";
            this.textboxNumPages.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textboxNumPages.Enabled = false;
            this.textboxNumPages.Location = new System.Drawing.Point(380, 15);
            this.textboxNumPages.Name = "textboxNumPages";
            this.textboxNumPages.PreventEnterBeep = true;
            this.textboxNumPages.Size = new System.Drawing.Size(38, 20);
            this.textboxNumPages.TabIndex = 3;
            this.textboxNumPages.TextChanged += new System.EventHandler(this.textboxNumPages_TextChanged);
            // 
            // itemPanel1
            // 
            this.itemPanel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.Class = "ItemPanel";
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.DragDropSupport = true;
            this.itemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel1.Location = new System.Drawing.Point(12, 41);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.Size = new System.Drawing.Size(406, 658);
            this.itemPanel1.TabIndex = 4;
            this.itemPanel1.Text = "itemPanel1";
            // 
            // paperSelectSatin
            // 
            this.paperSelectSatin.AutoSize = true;
            this.paperSelectSatin.Location = new System.Drawing.Point(425, 102);
            this.paperSelectSatin.Name = "paperSelectSatin";
            this.paperSelectSatin.Size = new System.Drawing.Size(52, 17);
            this.paperSelectSatin.TabIndex = 2;
            this.paperSelectSatin.TabStop = true;
            this.paperSelectSatin.Text = "Satin ";
            this.paperSelectSatin.UseVisualStyleBackColor = true;
            this.paperSelectSatin.CheckedChanged += new System.EventHandler(this.paperSelectSatin_CheckedChanged);
            // 
            // paperSelectMatte
            // 
            this.paperSelectMatte.AutoSize = true;
            this.paperSelectMatte.Location = new System.Drawing.Point(425, 79);
            this.paperSelectMatte.Name = "paperSelectMatte";
            this.paperSelectMatte.Size = new System.Drawing.Size(52, 17);
            this.paperSelectMatte.TabIndex = 1;
            this.paperSelectMatte.TabStop = true;
            this.paperSelectMatte.Text = "Matte";
            this.paperSelectMatte.UseVisualStyleBackColor = true;
            this.paperSelectMatte.CheckedChanged += new System.EventHandler(this.paperSelectMatte_CheckedChanged);
            // 
            // paperSelectBond
            // 
            this.paperSelectBond.AutoSize = true;
            this.paperSelectBond.Location = new System.Drawing.Point(424, 56);
            this.paperSelectBond.Name = "paperSelectBond";
            this.paperSelectBond.Size = new System.Drawing.Size(50, 17);
            this.paperSelectBond.TabIndex = 0;
            this.paperSelectBond.TabStop = true;
            this.paperSelectBond.Text = "Bond";
            this.paperSelectBond.UseVisualStyleBackColor = true;
            this.paperSelectBond.CheckedChanged += new System.EventHandler(this.paperSelectBond_CheckedChanged);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Black;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
            // 
            // windowMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 711);
            this.Controls.Add(this.paperSelectSatin);
            this.Controls.Add(this.itemPanel1);
            this.Controls.Add(this.paperSelectMatte);
            this.Controls.Add(this.textboxNumPages);
            this.Controls.Add(this.paperSelectBond);
            this.Controls.Add(this.textboxFileSize);
            this.Controls.Add(this.textboxFileName);
            this.Controls.Add(this.buttonFileBrowse);
            this.Name = "windowMain";
            this.Text = "windowMain";
            this.Load += new System.EventHandler(this.windowMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonFileBrowse;
        private DevComponents.DotNetBar.Controls.TextBoxX textboxFileName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevComponents.DotNetBar.Controls.TextBoxX textboxNumPages;
        private DevComponents.DotNetBar.ItemPanel itemPanel1;
        public DevComponents.DotNetBar.Controls.TextBoxX textboxFileSize;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.RadioButton paperSelectSatin;
        private System.Windows.Forms.RadioButton paperSelectMatte;
        private System.Windows.Forms.RadioButton paperSelectBond;
    }
}
namespace PlotToolTest
{
    partial class MainWindow 
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
        public void InitializeComponent()
        {
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.textBoxX3 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxX2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textboxFileName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.itemPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemPanel1
            // 
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.Class = "ItemPanel";
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.Controls.Add(this.textBoxX3);
            this.itemPanel1.Controls.Add(this.textBoxX2);
            this.itemPanel1.Controls.Add(this.textboxFileName);
            this.itemPanel1.Controls.Add(this.buttonX1);
            this.itemPanel1.DragDropSupport = true;
            this.itemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemPanel1.Location = new System.Drawing.Point(12, 13);
            this.itemPanel1.MinimumSize = new System.Drawing.Size(477, 41);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.Size = new System.Drawing.Size(477, 41);
            this.itemPanel1.TabIndex = 1;
            this.itemPanel1.Text = "itemPanel1";
            // 
            // textBoxX3
            // 
            // 
            // 
            // 
            this.textBoxX3.Border.Class = "TextBoxBorder";
            this.textBoxX3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX3.Location = new System.Drawing.Point(342, 10);
            this.textBoxX3.Name = "textBoxX3";
            this.textBoxX3.PreventEnterBeep = true;
            this.textBoxX3.Size = new System.Drawing.Size(45, 20);
            this.textBoxX3.TabIndex = 3;
            // 
            // textBoxX2
            // 
            // 
            // 
            // 
            this.textBoxX2.Border.Class = "TextBoxBorder";
            this.textBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX2.Location = new System.Drawing.Point(264, 10);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.PreventEnterBeep = true;
            this.textBoxX2.Size = new System.Drawing.Size(71, 20);
            this.textBoxX2.TabIndex = 2;
            // 
            // textboxFileName
            // 
            // 
            // 
            // 
            this.textboxFileName.Border.Class = "TextBoxBorder";
            this.textboxFileName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textboxFileName.Location = new System.Drawing.Point(3, 10);
            this.textboxFileName.Name = "textboxFileName";
            this.textboxFileName.PreventEnterBeep = true;
            this.textboxFileName.Size = new System.Drawing.Size(255, 20);
            this.textboxFileName.TabIndex = 1;
            this.textboxFileName.TextChanged += new System.EventHandler(this.textboxFileName_TextChanged);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(393, 10);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 20);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.buttonX1.TabIndex = 0;
            this.buttonX1.Text = "buttonX1";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(501, 76);
            this.Controls.Add(this.itemPanel1);
            this.MinimumSize = new System.Drawing.Size(517, 104);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.itemPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.ItemPanel itemPanel1;
        public DevComponents.DotNetBar.ButtonX buttonX1;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        public DevComponents.DotNetBar.Controls.TextBoxX textBoxX3;
        public DevComponents.DotNetBar.Controls.TextBoxX textBoxX2;
        public DevComponents.DotNetBar.Controls.TextBoxX textboxFileName;

    }
}


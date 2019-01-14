namespace NSacconAssignment1
{
    partial class frmMazeDesigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMazeDesigner));
            this.menuTopMenu = new System.Windows.Forms.MenuStrip();
            this.toolFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolClose = new System.Windows.Forms.ToolStripMenuItem();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.lblRows = new System.Windows.Forms.Label();
            this.lblColumns = new System.Windows.Forms.Label();
            this.txtColumns = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.boxGenerate = new System.Windows.Forms.Panel();
            this.imgLstSidebar = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnWall = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveMazeDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuTopMenu.SuspendLayout();
            this.boxGenerate.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuTopMenu
            // 
            this.menuTopMenu.BackColor = System.Drawing.SystemColors.Control;
            this.menuTopMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolFile});
            this.menuTopMenu.Location = new System.Drawing.Point(0, 0);
            this.menuTopMenu.Name = "menuTopMenu";
            this.menuTopMenu.Size = new System.Drawing.Size(727, 24);
            this.menuTopMenu.TabIndex = 0;
            this.menuTopMenu.Text = "ToolBar Menu";
            // 
            // toolFile
            // 
            this.toolFile.BackColor = System.Drawing.SystemColors.Control;
            this.toolFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSave,
            this.toolClose});
            this.toolFile.Name = "toolFile";
            this.toolFile.Size = new System.Drawing.Size(37, 20);
            this.toolFile.Text = "File";
            // 
            // toolSave
            // 
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(103, 22);
            this.toolSave.Text = "Save";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolClose
            // 
            this.toolClose.Name = "toolClose";
            this.toolClose.Size = new System.Drawing.Size(103, 22);
            this.toolClose.Text = "Close";
            this.toolClose.Click += new System.EventHandler(this.toolClose_Click);
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(52, 5);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(47, 20);
            this.txtRows.TabIndex = 1;
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(11, 8);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(37, 13);
            this.lblRows.TabIndex = 2;
            this.lblRows.Text = "Rows:";
            // 
            // lblColumns
            // 
            this.lblColumns.AutoSize = true;
            this.lblColumns.Location = new System.Drawing.Point(148, 8);
            this.lblColumns.Name = "lblColumns";
            this.lblColumns.Size = new System.Drawing.Size(50, 13);
            this.lblColumns.TabIndex = 4;
            this.lblColumns.Text = "Columns:";
            // 
            // txtColumns
            // 
            this.txtColumns.Location = new System.Drawing.Point(204, 5);
            this.txtColumns.Name = "txtColumns";
            this.txtColumns.Size = new System.Drawing.Size(47, 20);
            this.txtColumns.TabIndex = 3;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(304, 3);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // boxGenerate
            // 
            this.boxGenerate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxGenerate.Controls.Add(this.btnGenerate);
            this.boxGenerate.Controls.Add(this.txtRows);
            this.boxGenerate.Controls.Add(this.lblColumns);
            this.boxGenerate.Controls.Add(this.lblRows);
            this.boxGenerate.Controls.Add(this.txtColumns);
            this.boxGenerate.Location = new System.Drawing.Point(0, 27);
            this.boxGenerate.Name = "boxGenerate";
            this.boxGenerate.Size = new System.Drawing.Size(726, 31);
            this.boxGenerate.TabIndex = 6;
            // 
            // imgLstSidebar
            // 
            this.imgLstSidebar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLstSidebar.ImageStream")));
            this.imgLstSidebar.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLstSidebar.Images.SetKeyName(0, "None");
            this.imgLstSidebar.Images.SetKeyName(1, "Wall");
            this.imgLstSidebar.Images.SetKeyName(2, "Blue Door");
            this.imgLstSidebar.Images.SetKeyName(3, "Purple Door");
            this.imgLstSidebar.Images.SetKeyName(4, "Red Door");
            this.imgLstSidebar.Images.SetKeyName(5, "Yellow Door");
            this.imgLstSidebar.Images.SetKeyName(6, "Blue Key");
            this.imgLstSidebar.Images.SetKeyName(7, "Purple Key");
            this.imgLstSidebar.Images.SetKeyName(8, "Red Key");
            this.imgLstSidebar.Images.SetKeyName(9, "Yellow Key");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Toolbox";
            // 
            // button1
            // 
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 0;
            this.button1.ImageList = this.imgLstSidebar;
            this.button1.Location = new System.Drawing.Point(28, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 49);
            this.button1.TabIndex = 8;
            this.button1.Text = "None";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.toolboxItem_Click);
            // 
            // btnWall
            // 
            this.btnWall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWall.ImageIndex = 1;
            this.btnWall.ImageList = this.imgLstSidebar;
            this.btnWall.Location = new System.Drawing.Point(28, 84);
            this.btnWall.Name = "btnWall";
            this.btnWall.Size = new System.Drawing.Size(107, 49);
            this.btnWall.TabIndex = 9;
            this.btnWall.Text = "Wall";
            this.btnWall.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWall.UseVisualStyleBackColor = true;
            this.btnWall.Click += new System.EventHandler(this.toolboxItem_Click);
            // 
            // button3
            // 
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.ImageIndex = 2;
            this.button3.ImageList = this.imgLstSidebar;
            this.button3.Location = new System.Drawing.Point(28, 139);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 49);
            this.button3.TabIndex = 10;
            this.button3.Text = "Blue Door";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.toolboxItem_Click);
            // 
            // button4
            // 
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.ImageIndex = 3;
            this.button4.ImageList = this.imgLstSidebar;
            this.button4.Location = new System.Drawing.Point(28, 194);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(107, 49);
            this.button4.TabIndex = 11;
            this.button4.Text = "Purple Door";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.toolboxItem_Click);
            // 
            // button5
            // 
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.ImageIndex = 4;
            this.button5.ImageList = this.imgLstSidebar;
            this.button5.Location = new System.Drawing.Point(28, 249);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(107, 49);
            this.button5.TabIndex = 12;
            this.button5.Text = "Red Door";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.toolboxItem_Click);
            // 
            // button6
            // 
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.ImageIndex = 5;
            this.button6.ImageList = this.imgLstSidebar;
            this.button6.Location = new System.Drawing.Point(28, 304);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(107, 49);
            this.button6.TabIndex = 13;
            this.button6.Text = "Yellow Door";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.toolboxItem_Click);
            // 
            // button7
            // 
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.ImageIndex = 6;
            this.button7.ImageList = this.imgLstSidebar;
            this.button7.Location = new System.Drawing.Point(28, 359);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(107, 49);
            this.button7.TabIndex = 14;
            this.button7.Text = "Blue Key";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.toolboxItem_Click);
            // 
            // button8
            // 
            this.button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.ImageIndex = 7;
            this.button8.ImageList = this.imgLstSidebar;
            this.button8.Location = new System.Drawing.Point(28, 414);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(107, 49);
            this.button8.TabIndex = 15;
            this.button8.Text = "Purple Key";
            this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.toolboxItem_Click);
            // 
            // button9
            // 
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.ImageIndex = 8;
            this.button9.ImageList = this.imgLstSidebar;
            this.button9.Location = new System.Drawing.Point(28, 469);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(107, 49);
            this.button9.TabIndex = 16;
            this.button9.Text = "Red Key";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.toolboxItem_Click);
            // 
            // button10
            // 
            this.button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.ImageIndex = 9;
            this.button10.ImageList = this.imgLstSidebar;
            this.button10.Location = new System.Drawing.Point(28, 524);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(107, 49);
            this.button10.TabIndex = 17;
            this.button10.Text = "Yellow Key";
            this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.toolboxItem_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.btnWall);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Location = new System.Drawing.Point(0, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(164, 579);
            this.panel1.TabIndex = 18;
            // 
            // saveMazeDialog
            // 
            this.saveMazeDialog.DefaultExt = "txt";
            this.saveMazeDialog.FileName = "MyMaze.txt";
            this.saveMazeDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.saveMazeDialog.Title = "Save Your Maze!";
            // 
            // frmMazeDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(727, 644);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.boxGenerate);
            this.Controls.Add(this.menuTopMenu);
            this.MainMenuStrip = this.menuTopMenu;
            this.Name = "frmMazeDesigner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maze Designer";
            this.menuTopMenu.ResumeLayout(false);
            this.menuTopMenu.PerformLayout();
            this.boxGenerate.ResumeLayout(false);
            this.boxGenerate.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuTopMenu;
        private System.Windows.Forms.ToolStripMenuItem toolFile;
        private System.Windows.Forms.ToolStripMenuItem toolSave;
        private System.Windows.Forms.ToolStripMenuItem toolClose;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Label lblColumns;
        private System.Windows.Forms.TextBox txtColumns;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Panel boxGenerate;
        private System.Windows.Forms.ImageList imgLstSidebar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnWall;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SaveFileDialog saveMazeDialog;
    }
}
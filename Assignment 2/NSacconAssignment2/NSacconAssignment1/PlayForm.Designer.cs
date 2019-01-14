namespace NSacconAssignment1
{
    partial class frmPlay
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
            this.menuStripTop = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panPlaySurface = new System.Windows.Forms.Panel();
            this.txtMoveCount = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.keyControls = new ArrowControls.ArrowPad();
            this.cboxAnimations = new System.Windows.Forms.CheckBox();
            this.menuStripTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripTop
            // 
            this.menuStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStripTop.Location = new System.Drawing.Point(0, 0);
            this.menuStripTop.Name = "menuStripTop";
            this.menuStripTop.Size = new System.Drawing.Size(807, 24);
            this.menuStripTop.TabIndex = 0;
            this.menuStripTop.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // panPlaySurface
            // 
            this.panPlaySurface.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panPlaySurface.Location = new System.Drawing.Point(12, 27);
            this.panPlaySurface.Name = "panPlaySurface";
            this.panPlaySurface.Size = new System.Drawing.Size(506, 432);
            this.panPlaySurface.TabIndex = 1;
            // 
            // txtMoveCount
            // 
            this.txtMoveCount.Location = new System.Drawing.Point(647, 106);
            this.txtMoveCount.Name = "txtMoveCount";
            this.txtMoveCount.ReadOnly = true;
            this.txtMoveCount.Size = new System.Drawing.Size(32, 20);
            this.txtMoveCount.TabIndex = 2;
            this.txtMoveCount.Text = "0";
            this.txtMoveCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            this.openFileDialog.Title = "Open A Saved Game";
            // 
            // keyControls
            // 
            this.keyControls.ArrowOptions = null;
            this.keyControls.Location = new System.Drawing.Point(553, 305);
            this.keyControls.Name = "keyControls";
            this.keyControls.Size = new System.Drawing.Size(225, 154);
            this.keyControls.TabIndex = 7;
            // 
            // cboxAnimations
            // 
            this.cboxAnimations.AutoSize = true;
            this.cboxAnimations.Location = new System.Drawing.Point(625, 145);
            this.cboxAnimations.Name = "cboxAnimations";
            this.cboxAnimations.Size = new System.Drawing.Size(77, 17);
            this.cboxAnimations.TabIndex = 8;
            this.cboxAnimations.Text = "Animations";
            this.cboxAnimations.UseVisualStyleBackColor = true;
            // 
            // frmPlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 504);
            this.Controls.Add(this.cboxAnimations);
            this.Controls.Add(this.keyControls);
            this.Controls.Add(this.txtMoveCount);
            this.Controls.Add(this.panPlaySurface);
            this.Controls.Add(this.menuStripTop);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.menuStripTop;
            this.Name = "frmPlay";
            this.Text = "Play!";
            this.Load += new System.EventHandler(this.frmPlay_Load);
            this.menuStripTop.ResumeLayout(false);
            this.menuStripTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripTop;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Panel panPlaySurface;
        private System.Windows.Forms.TextBox txtMoveCount;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private ArrowControls.ArrowPad keyControls;
        private System.Windows.Forms.CheckBox cboxAnimations;
    }
}
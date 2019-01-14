using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrowControls
{
    public class ArrowPad : UserControl
    {
        private Button btnUp;
        private Button btnDown;
        private Button btnRight;
        private Button btnLeft;

        private IArrowPresses arrowOptions;

        public IArrowPresses ArrowOptions { get => arrowOptions; set => arrowOptions = value; }

        private void InitializeComponent()
        {
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(80, 8);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(65, 65);
            this.btnUp.TabIndex = 0;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.direction_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(80, 79);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(65, 65);
            this.btnDown.TabIndex = 1;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.direction_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(151, 79);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(65, 65);
            this.btnRight.TabIndex = 2;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.direction_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(9, 79);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(65, 65);
            this.btnLeft.TabIndex = 3;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.direction_Click);
            // 
            // ArrowPad
            // 
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Name = "ArrowPad";
            this.Size = new System.Drawing.Size(225, 154);
            this.ResumeLayout(false);

        }

        public ArrowPad()
        {
            InitializeComponent();
        }

        private void direction_Click(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button;
            if (pressedButton.Text == "Up")
            {
                arrowOptions.UpArrow();
            } else if (pressedButton.Text == "Down")
            {
                arrowOptions.DownArrow();
            }
            else if (pressedButton.Text == "Left")
            {
                arrowOptions.LeftArrow();
            } else
            {
                arrowOptions.RightArrow();
            }
        }
    }
}

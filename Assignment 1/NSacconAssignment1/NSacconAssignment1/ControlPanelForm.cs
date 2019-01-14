using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/* Nathan Saccon Assignment 1 Main Form

 Revision History:
                  Nathan Saccon: September 10, 2018: Created main form that opens the design subform, and exits.

*/

namespace NSacconAssignment1
{
    public partial class frmControlPanel : Form
    {
        public frmControlPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Closes the "Main Form".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Opens a new "Maze Designer" subform.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDesign_Click(object sender, EventArgs e)
        {
            frmMazeDesigner maze = new frmMazeDesigner();

            maze.Show();
        }
    }
}

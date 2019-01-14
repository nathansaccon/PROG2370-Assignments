using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
/* Nathan Saccon Assignment1

 Purpose: To practice using arrays and learning to use pictureboxes for assignment one of PROG 2370

 Revision History:
                  Nathan Saccon: September 11, 2018: Created ability to spawn grid of picture boxes.
                  Nathan Saccon: September 11, 2018: Created toolbar.
                  Nathan Saccon: September 12, 2018: Clicking changes the pictures in the picture boxes, and none works.
                  Nathan Saccon: September 12, 2018: Saving feature added.
                  Nathan Saccon: September 18, 2018: Refine comments, and finalize assignment.
                  
*/

namespace NSacconAssignment1
{
    public partial class frmMazeDesigner : Form
    {
        #region Init and Close

        public frmMazeDesigner()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Closes the "Maze Designer" form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Global Variables

        private int boardRows = 0;
        private int boardColumns = 0;
        private PictureBox[,] gameBoard;
        private int selectedTool = 0;

        #endregion

        #region Game Board Methods

        /// <summary>
        /// Returns an empty PictureBox with some default settings included.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        private PictureBox DefaultEmptyPicturebox(int row, int column, Point point)
        {
            PictureBox defaultBox = new PictureBox
            {
                Name = Convert.ToString(row) + "::" + Convert.ToString(column) + "::0", // Name includes row, column, and the ImageList index.
                Size = new Size(36, 36),
                Location = point,
                BorderStyle = BorderStyle.FixedSingle,
            };
            defaultBox.Click += new EventHandler(pictureBox_Click);
            defaultBox.SizeMode = PictureBoxSizeMode.StretchImage;

            return defaultBox;
        }

        /// <summary>
        /// Returns a 2D PictureBox array with each element having default values set.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        private PictureBox[,] GenerateGameBoard(int rows, int columns)
        {
            // Starting location for the top left PictureBox.
            int startingX = 200;
            int startingY = 90;

            PictureBox[,] filledBoard = new PictureBox[rows,columns];

            for (int r = 0; r < filledBoard.GetLength(0); r++)
            {
                for (int c = 0; c < filledBoard.GetLength(1); c++)
                {
                    PictureBox emptyBox = DefaultEmptyPicturebox(r, c, new Point(startingX, startingY));

                    filledBoard[r, c] = emptyBox;
                    startingX += 38; // Move Right
                }
                startingX = 200; // Original X position
                startingY += 38; // Move Down
            }

            return filledBoard;

        }

        /// <summary>
        /// Displays a rectangle of PictureBoxes onto the Maze Designer Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string errors = "";
            
            try
            {

                if (Convert.ToInt32(txtRows.Text) <= 0 || Convert.ToInt32(txtColumns.Text) <= 0) // Non-Positive Integer Error
                {
                    errors += "Your row and column input must be positive integers.";
                } else
                {
                    boardRows = Convert.ToInt32(txtRows.Text);
                    boardColumns = Convert.ToInt32(txtColumns.Text);
                }

            }
            catch (Exception) // Non-Integer Error
            {
                errors += "Your row and column input must be integers.";
            }

            if (errors != "")
            {
                MessageBox.Show(errors, "Grid Generation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                EraseBoard();
                gameBoard = GenerateGameBoard(boardRows, boardColumns);

                foreach (PictureBox picture in gameBoard)
                {
                    Controls.Add(picture);
                }
            }
        }

        /// <summary>
        /// Disposes (deletes) all the PictureBoxes that are currently on the board.
        /// </summary>
        private void EraseBoard()
        {
            if (gameBoard != null)
            {
                for (int r = 0; r < gameBoard.GetLength(0); r++)
                {
                    for (int c = 0; c < gameBoard.GetLength(1); c++)
                    {
                        gameBoard[r, c].Dispose();
                    }
                }
            }
        }
        #endregion

        #region Click Event Methods

        /// <summary>
        /// Changes the image in the clicked PictureBox to the currently selected image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox selectedBox = sender as PictureBox;
            int row = Convert.ToInt32(selectedBox.Name.Split(new string[] { "::" }, StringSplitOptions.None)[0]); // Gets row from PictureBox name.
            int column = Convert.ToInt32(selectedBox.Name.Split(new string[] { "::" }, StringSplitOptions.None)[1]); // Gets column from PictureBox name.

            if (selectedTool == 0) // If user selected "none"
            {
                PictureBox emptyBox = DefaultEmptyPicturebox(row, column, selectedBox.Location);
                selectedBox.Dispose();
                gameBoard[row, column] = emptyBox;
                Controls.Add(emptyBox);

            } else
            {
                //selectedBox.Image = imgLstSidebar.Images[selectedTool]; // Gets picture directly from the ImageList, based on correlated index.
                selectedBox.Name = Convert.ToString(row) + "::" + Convert.ToString(column) + "::" + Convert.ToString(selectedTool);
                
                // All code below this line is obsolete if you uncomment out line 192.
                // But this code has to stay because the rubric says images must be assigned through resources.
                if (selectedTool == 1)
                {
                    selectedBox.Image = Properties.Resources.brickwall;
                } else if (selectedTool == 2)
                {
                    selectedBox.Image = Properties.Resources.BlueDoor;
                } else if (selectedTool == 3)
                {
                    selectedBox.Image = Properties.Resources.PurpleDoor;
                } else if (selectedTool == 4)
                {
                    selectedBox.Image = Properties.Resources.RedDoor;
                } else if (selectedTool == 5)
                {
                    selectedBox.Image = Properties.Resources.YellowDoor;
                } else if (selectedTool == 6)
                {
                    selectedBox.Image = Properties.Resources.BlueKey;
                } else if (selectedTool == 7)
                {
                    selectedBox.Image = Properties.Resources.PurpleKey;
                } else if (selectedTool == 8)
                {
                    selectedBox.Image = Properties.Resources.RedKey;
                } else if (selectedTool == 9)
                {
                    selectedBox.Image = Properties.Resources.YellowKey;
                }
            }
        }
        /// <summary>
        /// Sets the currently selected tool to the toolbox item clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolboxItem_Click(object sender, EventArgs e)
        {
            Button selectedBox = sender as Button;

            selectedTool = selectedBox.ImageIndex;
        }

        /// <summary>
        /// Saves the game board into a file using a Save Dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSave_Click(object sender, EventArgs e)
        {
            if(gameBoard == null)
            {
                MessageBox.Show("You cannot save an empty design.", "Empty Design Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                saveMazeDialog.ShowDialog(); // User chooses file name and location.
                string savedFileName = saveMazeDialog.FileName;

                StreamWriter writer = new StreamWriter(savedFileName);

                writer.WriteLine(Convert.ToString(boardRows) + "::" + Convert.ToString(boardColumns)); // Write the total number of rows and columns to the first line of the document.

                foreach (PictureBox box in gameBoard)
                {
                    writer.WriteLine(box.Name); // Name includes row, column, and type.
                }

                writer.Close();

                MessageBox.Show("Your maze has been saved!", "Saved!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

        }
        #endregion
        
    }
}

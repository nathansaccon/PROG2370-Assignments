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
                  Nathan Saccon: September 28, 2018: Created the tile class to not lose one mark.
                  
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
        private Tile[,] gameBoard;
        private int selectedTool = 0;

        const int STARTINGX = 200;
        const int STARTINGY = 90;
        const int MOVEBY = 38;

        private int BoardRows { get => boardRows; set => boardRows = value; }
        private int BoardColumns { get => boardColumns; set => boardColumns = value; }
        private int SelectedTool { get => selectedTool; set => selectedTool = value; }
        private Tile[,] GameBoard { get => gameBoard; set => gameBoard = value; }

        #endregion

        #region GameBoard Helpers

        /// <summary>
        /// Returns an empty Tile.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public Tile EmptyTile(int row, int column, Point point)
        {
            Tile defaultTile = new Tile(row, column, point);
            defaultTile.Click += pictureBox_Click;

            return defaultTile;
        }

        /// <summary>
        /// Returns a 2D Tile array with each element having a default tile, and displays them.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public Tile[,] CreateEmptyTileGameBoard(int rows, int columns)
        {
            Tile[,] filledBoard = new Tile[rows, columns];
            int currentX = STARTINGX;
            int currentY = STARTINGY;

            for (int r = 0; r < filledBoard.GetLength(0); r++)
            {
                for (int c = 0; c < filledBoard.GetLength(1); c++)
                {
                    Tile emptyTile = EmptyTile(r, c, new Point(currentX, currentY));
                    filledBoard[r, c] = emptyTile;
                    currentX += MOVEBY; // Move Right
                }
                currentX = STARTINGX;
                currentY += MOVEBY; // Move Down
            }
            return filledBoard;
        }
        
        /// <summary>
        /// Disposes (deletes) all the PictureBoxes that are currently on the board.
        /// </summary>
        private void EraseBoard()
        {
            if (GameBoard != null)
            {
                for (int r = 0; r < GameBoard.GetLength(0); r++)
                {
                    for (int c = 0; c < GameBoard.GetLength(1); c++)
                    {
                        GameBoard[r, c].Dispose();
                    }
                }
            }
        }

        #endregion

        #region Click Event Methods

        /// <summary>
        /// Displays Tiles onto the Maze Designer Form.
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
                }
                else
                {
                    BoardRows = Convert.ToInt32(txtRows.Text);
                    BoardColumns = Convert.ToInt32(txtColumns.Text);
                }
            }
            catch (Exception) // Non-Integer Error
            {
                errors += "Your row and column input must be integers.";
            }

            if (errors != "")
            {
                MessageBox.Show(errors, "Grid Generation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                EraseBoard();
                GameBoard = CreateEmptyTileGameBoard(BoardRows, BoardColumns);

                foreach(Tile tile in GameBoard)
                {
                    Controls.Add(tile);
                }
            }
        }

        /// <summary>
        /// Changes the image in the clicked PictureBox to the currently selected image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_Click(object sender, EventArgs e)
        {
            Tile selectedTile = (Tile)sender;

            if (SelectedTool == 0) // If user selected "none"
            {
                Tile emptyTile = EmptyTile(selectedTile.Row, selectedTile.Column, selectedTile.Location);
                selectedTile.Dispose(); // Dispose tile after getting the row, column, and location.
                emptyTile.Type = TileType.NONE;
                GameBoard[selectedTile.Row, selectedTile.Column] = emptyTile;
                Controls.Add(emptyTile);

            } else
            {
                selectedTile.Item = SelectedTool;

                if (SelectedTool == 1)
                {
                    selectedTile.Image = Properties.Resources.brickwall;
                    selectedTile.Type = TileType.WALL;
                } else if (SelectedTool == 2)
                {
                    selectedTile.Image = Properties.Resources.BlueDoor;
                    selectedTile.Type = TileType.BLUEDOOR;
                } else if (SelectedTool == 3)
                {
                    selectedTile.Image = Properties.Resources.PurpleDoor;
                    selectedTile.Type = TileType.PURPLEDOOR;
                } else if (SelectedTool == 4)
                {
                    selectedTile.Image = Properties.Resources.RedDoor;
                    selectedTile.Type = TileType.REDDOOR;
                } else if (SelectedTool == 5)
                {
                    selectedTile.Image = Properties.Resources.YellowDoor;
                    selectedTile.Type = TileType.YELLOWDOOR;
                } else if (SelectedTool == 6)
                {
                    selectedTile.Image = Properties.Resources.BlueKey;
                    selectedTile.Type = TileType.BLUEKEY;
                } else if (SelectedTool == 7)
                {
                    selectedTile.Image = Properties.Resources.PurpleKey;
                    selectedTile.Type = TileType.PURPLEKEY;
                } else if (SelectedTool == 8)
                {
                    selectedTile.Image = Properties.Resources.RedKey;
                    selectedTile.Type = TileType.REDKEY;
                } else if (SelectedTool == 9)
                {
                    selectedTile.Image = Properties.Resources.YellowKey;
                    selectedTile.Type = TileType.YELLOWKEY;
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
            Button clickedTool = sender as Button;

            SelectedTool = clickedTool.ImageIndex;
        }

        /// <summary>
        /// Saves the game board into a file using a Save Dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolSave_Click(object sender, EventArgs e)
        {
            if(GameBoard == null)
            {
                MessageBox.Show("You cannot save an empty design.", "Empty Design Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                saveMazeDialog.ShowDialog(); // User chooses file name and location.
                string savedFileName = saveMazeDialog.FileName;
                StreamWriter writer = new StreamWriter(savedFileName);
                writer.WriteLine(Convert.ToString(BoardRows) + "::" + Convert.ToString(BoardColumns)); // Write the total number of rows and columns to the first line of the document.

                foreach (Tile tile in GameBoard)
                {
                    writer.WriteLine(tile.ToString());
                }

                writer.Close();
                MessageBox.Show("Your maze has been saved!", "Saved!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        
    }
}

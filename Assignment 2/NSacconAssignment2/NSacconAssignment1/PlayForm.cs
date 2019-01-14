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
using System.Text.RegularExpressions;
using ArrowControls;

/* Nathan Saccon Assignment2

 Purpose: To learn interfaces for assignment two of PROG 2370

 Revision History:
                  Nathan Saccon: October 3, 2018: Ability to open form,  UI designed
                                 October 4, 2018: Ability to load from a saved file
                                 October 5, 2018: Custom controller added that controls keys
                                 October 9, 2018: Ability to win game, and move counter added
                  
*/

namespace NSacconAssignment1
{
    public partial class frmPlay : Form, IArrowPresses
    {

        #region Init and Close and Load

        public frmPlay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Closes the "Play" form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Loads the IArrowPresses to the arrow keys.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPlay_Load(object sender, EventArgs e)
        {
            ArrowControls.IArrowPresses formArrowControls = this;
            keyControls.ArrowOptions = formArrowControls;
        }

        #endregion

        #region Form Variables

        private Tile[,] gameBoard;
        private Tile selectedKey;

        const int STARTINGX = 10;
        const int STARTINGY = 10;
        const int MOVEBY = 35;

        private Tile[,] GameBoard { get => gameBoard; set => gameBoard = value; }
        private Tile SelectedKey { get => selectedKey; set => selectedKey = value; }

        #endregion

        #region File Loading Helpers

        /// <summary>
        /// Returns true if 'line' is a valid saved line and false otherwise.
        /// </summary>
        /// <param name="tileAsTxt"></param>
        /// <returns></returns>
        private bool VerifiedLine(string tileAsTxt)
        {
            bool verified = false;
            Regex pattern = new Regex(@"(^\d*::\d*$)|(^\d*::\d*::\d$)");

            if (pattern.IsMatch(tileAsTxt))
            {
                verified = true;
            }
            return verified;
        }

        /// <summary>
        /// Returns the row from line.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private int GetLineRow(string line)
        {
            return Convert.ToInt32(line.Split(new String[] { "::" }, StringSplitOptions.None)[0]);
        }

        /// <summary>
        /// Returns the column from line.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private int GetLineColumn(string line)
        {
            return Convert.ToInt32(line.Split(new String[] { "::" }, StringSplitOptions.None)[1]);
        }

        /// <summary>
        /// Returns the item from line.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private int GetLineItem(string line)
        {
            return Convert.ToInt32(line.Split(new String[] { "::" }, StringSplitOptions.None)[2]);
        }

        /// <summary>
        /// Checks if given file is a valid saved Maze
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool IsValidSavedGame(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            bool linesValid = true;
            int tileCount = 0;
            int rows = -1;
            int columns = -1;

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (!VerifiedLine(line))
                {
                    linesValid = false;
                    break;
                } else // Line is valid
                {
                    if (rows == -1) // First line sets total rows and colums
                    {
                        rows = GetLineRow(line);
                        columns = GetLineColumn(line);
                    }else
                    {
                        if (GetLineRow(line) > rows || GetLineColumn(line) > columns) // If Tile has a row greater than the total number of rows.
                        {
                            linesValid = false;
                            break;
                        }
                        tileCount += 1;
                    }
                }
            }
            return linesValid && (tileCount == (rows * columns));
        }

        /// <summary>
        /// Returns the coresponding image to the given item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private Image ItemToImage(TileType type)
        {
            Image itemAsImage = null;
            switch (type)
            {
                case TileType.WALL:
                    itemAsImage = Properties.Resources.brickwall;
                    break;
                case TileType.BLUEDOOR:
                    itemAsImage = Properties.Resources.BlueDoor;
                    break;
                case TileType.PURPLEDOOR:
                    itemAsImage = Properties.Resources.PurpleDoor;
                    break;
                case TileType.REDDOOR:
                    itemAsImage = Properties.Resources.RedDoor;
                    break;
                case TileType.YELLOWDOOR:
                    itemAsImage = Properties.Resources.YellowDoor;
                    break;
                case TileType.BLUEKEY:
                    itemAsImage = Properties.Resources.BlueKey;
                    break;
                case TileType.PURPLEKEY:
                    itemAsImage = Properties.Resources.PurpleKey;
                    break;
                case TileType.REDKEY:
                    itemAsImage = Properties.Resources.RedKey;
                    break;
                case TileType.YELLOWKEY:
                    itemAsImage = Properties.Resources.YellowKey;
                    break;
            }
            return itemAsImage;
        }

        /// <summary>
        /// Erases all the Tiles in the Gameboard
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

        #region Move Helpers

        /// <summary>
        /// Replaces the currently selected key with an empty tile.
        /// </summary>
        private void ReplaceSelectedWithEmpty()
        {
            int oldRow = SelectedKey.Row;
            int oldCol = SelectedKey.Column;
            Point oldLocation = SelectedKey.Location;
            SelectedKey.Dispose();
            
            Tile newTile = new Tile(oldRow, oldCol, oldLocation);
            panPlaySurface.Controls.Add(newTile);
            GameBoard[oldRow, oldCol] = newTile;
        }

        /// <summary>
        /// Replaces the given tile with the currently selected key.
        /// </summary>
        /// <param name="tile"></param>
        private void ReplaceTileWithSelected(Tile tile)
        {
            int newRow = tile.Row;
            int newCol = tile.Column;
            Point newLocation = tile.Location;
            tile.Dispose();

            Tile movedKey = new Tile(newRow, newCol, newLocation, SelectedKey.Item);
            movedKey.Image = ItemToImage(SelectedKey.Type);
            movedKey.Click += key_Click;
            panPlaySurface.Controls.Add(movedKey);
            GameBoard[newRow, newCol] = movedKey;

            ReplaceSelectedWithEmpty();

            SelectedKey = movedKey;
        }

        #endregion

        #region Move Methods (Interface Methods)

        /// <summary>
        /// Moves selected key up until it hits a non-empty tile, the edge of the board, or the corresponding door. 
        /// </summary>
        public void UpArrow()
        {
            if (SelectedKey != null && SelectedKey.Row != 0) // Key is not on edge of map
            {
                int rowOfAboveTile = SelectedKey.Row - 1;
                txtMoveCount.Text = (Convert.ToInt32(txtMoveCount.Text) + 1).ToString();

                while (rowOfAboveTile >= 0) // Hit Edge of board
                {
                    Tile aboveTile = GameBoard[rowOfAboveTile, SelectedKey.Column];

                    if (aboveTile.Type == TileType.NONE) // Hit empty tile.
                    {
                        ReplaceTileWithSelected(aboveTile);
                        rowOfAboveTile -= 1;
                    } else if (Tile.IsKeyToDoor(SelectedKey, aboveTile)) // Hit matching door.
                    {
                        ReplaceSelectedWithEmpty();
                        SelectedKey = null;
                        DisplayWin();
                        break;
                    }
                    else // Hit non-empty tile that is not the matching door.
                    {
                        break;
                    }
                }
            }
            
        }

        /// <summary>
        /// Moves selected key down until it hits a non-empty tile, the edge of the board, or the corresponding door.
        /// </summary>
        public void DownArrow()
        {
            if (SelectedKey != null && SelectedKey.Row != GameBoard.GetLength(0) - 1) // Key is not on edge of map
            {
                int rowOfBelowTile = SelectedKey.Row + 1;
                txtMoveCount.Text = (Convert.ToInt32(txtMoveCount.Text) + 1).ToString();

                while (rowOfBelowTile < GameBoard.GetLength(0)) // Hit Edge of board
                {
                    Tile belowTile = GameBoard[rowOfBelowTile, SelectedKey.Column];

                    if (belowTile.Type == TileType.NONE) // Hit empty tile.
                    {
                        ReplaceTileWithSelected(belowTile);
                        rowOfBelowTile += 1;
                    }
                    else if (Tile.IsKeyToDoor(SelectedKey, belowTile)) // Hit matching door.
                    {
                        ReplaceSelectedWithEmpty();
                        SelectedKey = null;
                        DisplayWin();
                        break;
                    }
                    else // Hit non-empty tile that is not the matching door.
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Moves selected key right until it hits a non-empty tile, the edge of the board, or the corresponding door.
        /// </summary>
        public void RightArrow()
        {
            if (SelectedKey != null && SelectedKey.Column != GameBoard.GetLength(1) - 1) // Key is not on edge of map
            {
                int columnRightOfTile = SelectedKey.Column + 1;
                txtMoveCount.Text = (Convert.ToInt32(txtMoveCount.Text) + 1).ToString();

                while (columnRightOfTile < GameBoard.GetLength(1)) // Hit Edge of board
                {
                    Tile rightTile = GameBoard[SelectedKey.Row, columnRightOfTile];

                    if (rightTile.Type == TileType.NONE) // Hit empty tile.
                    {
                        ReplaceTileWithSelected(rightTile);
                        columnRightOfTile += 1;
                    }
                    else if (Tile.IsKeyToDoor(SelectedKey, rightTile)) // Hit matching door.
                    {
                        ReplaceSelectedWithEmpty();
                        SelectedKey = null;
                        DisplayWin();
                        break;
                    }
                    else // Hit non-empty tile that is not the matching door.
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Moves selected key left until it hits a non-empty tile, the edge of the board, or the corresponding door.
        /// </summary>
        public void LeftArrow()
        {
            if (SelectedKey != null && SelectedKey.Column != 0) // Key is not on edge of map
            {
                int columnLeftOfTile = SelectedKey.Column - 1;
                txtMoveCount.Text = (Convert.ToInt32(txtMoveCount.Text) + 1).ToString();

                while (columnLeftOfTile >= 0) // Hit Edge of board
                {
                    Tile leftTile = GameBoard[SelectedKey.Row, columnLeftOfTile];

                    if (leftTile.Type == TileType.NONE) // Hit empty tile.
                    {
                        ReplaceTileWithSelected(leftTile);
                        columnLeftOfTile -= 1;
                    }
                    else if (Tile.IsKeyToDoor(SelectedKey, leftTile)) // Hit matching door.
                    {
                        ReplaceSelectedWithEmpty();
                        SelectedKey = null;
                        DisplayWin();
                        break;
                    }
                    else // Hit non-empty tile that is not the matching door.
                    {
                        break;
                    }
                }
            }
        }

        #endregion

        #region Click Methods

        /// <summary>
        /// Loads a file onto the panel in the play form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((openFileDialog.ShowDialog() == DialogResult.OK) && IsValidSavedGame(openFileDialog.FileName)) // Open Dialog does not produce error AND the saved game is valid.
            {
                EraseBoard();
                txtMoveCount.Text = "0";
                StreamReader reader = new StreamReader(openFileDialog.FileName);
                string lineOne = reader.ReadLine();
                GameBoard = new Tile[GetLineRow(lineOne), GetLineColumn(lineOne)];

                int currentx = STARTINGX;
                int currenty = STARTINGY;
                for (int r = 0; r < GameBoard.GetLength(0); r++)
                {
                    for (int c = 0; c < GameBoard.GetLength(1); c++)
                    {
                        string line = reader.ReadLine();
                        int tileRow = GetLineRow(line);
                        int tileColumn = GetLineColumn(line);
                        int tileItem = GetLineItem(line);

                        Tile tile = new Tile(tileRow, tileColumn, new Point(currentx, currenty), tileItem);
                        tile.Image = ItemToImage(tile.Type);

                        if (Tile.IsKey(tile))
                        {
                            tile.Click += key_Click;
                        }
                        
                        GameBoard[tileRow, tileColumn] = tile;
                        panPlaySurface.Controls.Add(tile);
                        currentx += MOVEBY;
                    }
                    currentx = STARTINGX;
                    currenty += MOVEBY;
                }
            } else
            {
                MessageBox.Show("Error Opening File","File Not Valid", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Makes the clicked key the selected key.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void key_Click(object sender, EventArgs e)
        {
            Tile clickedKey = sender as Tile;

            if (SelectedKey != null)
            {
                SelectedKey.BorderStyle = BorderStyle.FixedSingle;
            }
            clickedKey.BorderStyle = BorderStyle.None;
            SelectedKey = clickedKey;
        }

        #endregion

        #region Win Condition Methods

        /// <summary>
        /// Returns true if the game is currently won (The last key is now gone).
        /// </summary>
        /// <returns></returns>
        private bool IsWon()
        {
            for (int r = 0; r < GameBoard.GetLength(0); r++)
            {
                for (int c = 0; c < GameBoard.GetLength(1); c++)
                {
                    if (Tile.IsKey(GameBoard[r, c]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Checks if game is won and displays message if player won.
        /// </summary>
        private void DisplayWin()
        {
            if (IsWon())
            {
                MessageBox.Show("YOU WON!!\n\nYou won in "+ txtMoveCount.Text +" moves", "Winner", MessageBoxButtons.OK, MessageBoxIcon.None);
                EraseBoard();
            }
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/* Nathan Saccon Assignment3

 Purpose: To play tic tac toe

 Revision History:
                  Nathan Saccon: November 15, 2018: Created and finished assignment
                  
*/
namespace NSacconAssignment3
{
    public partial class TicTacToe : Form
    {
        public TicTacToe()
        {
            InitializeComponent();
            PopulateBoard();
        }

        const int STARTING_TOP = 50;
        const int STARTING_LEFT = 50;
        Type nextMove = Type.X;
        Tile[,] board = new Tile[3,3];

        /// <summary>
        /// Makes the tic tac toe board appear on the form
        /// </summary>
        private void PopulateBoard()
        {
            nextMove = Type.X;
            for (int r = 0; r < board.GetLength(0); r++)
            {
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    Tile createdTile = new Tile(r, c, Type.NONE);
                    createdTile.Click += tile_Click;
                    createdTile.Top = STARTING_TOP + (Tile.HEIGHT * c);
                    createdTile.Left = STARTING_LEFT + (Tile.WIDTH * r); ;
                    board[r, c] = createdTile;
                    Controls.Add(createdTile);
                }
            }
        }

        /// <summary>
        /// Change image in Tile upon click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tile_Click(object sender, EventArgs e)
        {
            Tile clickedTile = sender as Tile;
            
            if(clickedTile.Type == Type.NONE)
            {
                if(nextMove == Type.X)
                {
                    clickedTile.Image = Properties.Resources.X;
                    clickedTile.Type = Type.X;
                    nextMove = Type.O;
                    IsGameOver();
                }
                else
                {
                    clickedTile.Image = Properties.Resources.O;
                    clickedTile.Type = Type.O;
                    nextMove = Type.X;
                    IsGameOver();
                }
            }

        }

        /// <summary>
        /// Displays win message and resets the board
        /// </summary>
        private void IsGameOver()
        {
            bool gameOver = false;
            int empties = 0;
            // Win in Column
            for (int r = 0; r < board.GetLength(0); r++)
            {
                Type[] types = new Type[3];

                for (int c = 0; c < board.GetLength(1); c++)
                {
                    types[c] = board[r, c].Type;
                    if (board[r,c].Type == Type.NONE)
                    {
                        empties++;
                    }
                }

                if(types[0] != Type.NONE && types[0] == types[1] && types[1] == types[2])// Three of the same type in a column, non-empty
                {
                    DisplayWin(types[0]);
                    gameOver = true;
                }
            }
            // Win in Row
            for (int c = 0; c < board.GetLength(1); c++)
            {
                Type[] types = new Type[3];

                for (int r = 0; r < board.GetLength(0); r++)
                {
                    types[r] = board[r, c].Type;
                }

                if (types[0] != Type.NONE && types[0] == types[1] && types[1] == types[2])// Three of the same type in a row, non-empty
                {
                    DisplayWin(types[0]);
                    gameOver = true;
                }
            }
            // Diagonal Win
            if(board[1,1].Type != Type.NONE) // Middle tile is not empty
            {
                if((board[0,0].Type == board[1,1].Type && board[2,2].Type == board[1, 1].Type)|| // Top left to bottom right diagonal
                    (board[0, 2].Type == board[1, 1].Type && board[2, 0].Type == board[1, 1].Type)) // bottom left to top right diagonal
                {
                    DisplayWin(board[1, 1].Type);
                    gameOver = true;
                }
            }
            //Draw Case
            if (!gameOver && empties == 0)
            {
                DisplayWin(Type.NONE);
                gameOver = true;
            }
        }

        /// <summary>
        /// Erases the board
        /// </summary>
        private void EraseBoard()
        {
            foreach(Tile tile in board)
            {
                tile.Dispose();
            }
            PopulateBoard();
        }

        /// <summary>
        /// Displays the winning message.
        /// </summary>
        /// <param name="type"></param>
        private void DisplayWin(Type type)
        {
            if(type == Type.NONE)
            {
                MessageBox.Show("DRAW\nNo one wins.", "DRAW", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }else if(type == Type.X)
            {
                MessageBox.Show("X Wins.", "X Wins", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }else
            {
                MessageBox.Show("O Wins.", "O Wins", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            EraseBoard();
        }


    }
}

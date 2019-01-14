using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/* Nathan Saccon Assignment3

 Purpose: To play tic tac toe

 Revision History:
                  Nathan Saccon: November 15, 2018: Created and finished class
                  
*/
namespace NSacconAssignment3
{
    enum Type
    {
        NONE,
        X,
        O
    }

    class Tile : PictureBox
    {
        public const int HEIGHT = 100;
        public const int WIDTH = 100;

        private int row;
        private int column;
        private Type type;

        internal int Row { get => row;}
        internal int Column { get => column;}
        internal Type Type { get => type; set => type = value; }

        public Tile(int row, int column, Type type)
        {
            this.row = row;
            this.column = column;
            this.Type = type;
            BorderStyle = BorderStyle.FixedSingle;
            Height = HEIGHT;
            Width = WIDTH;
        }
    }
}

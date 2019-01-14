using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSacconAssignment1
{
    class Tile: PictureBox
    {
        private int row;
        private int column;
        private int item;


        public Tile(int row, int column, Point location)
        {
            Row = row;
            Column = column;
            Item = 0;
            Location = location;
            Size = new Size(36, 36);
            BorderStyle = BorderStyle.FixedSingle;
            SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public int Row { get => row; set => row = value; }
        public int Column { get => column; set => column = value; }
        public int Item { get => item; set => item = value; }

        public override string ToString()
        {
            return Convert.ToString(Row) + "::" + Convert.ToString(Column) + "::" + Convert.ToString(Item);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSacconAssignment1
{
    public enum TileType
    {
        NONE,
        WALL,
        BLUEDOOR,
        PURPLEDOOR,
        REDDOOR,
        YELLOWDOOR,
        BLUEKEY,
        PURPLEKEY,
        REDKEY,
        YELLOWKEY,
    }

    public class Tile: PictureBox
    {
        #region Class Variables

        private int row;
        private int column;
        private int item;
        private TileType type;

        const int TILE_SIZE = 36;

        public int Row { get => row; set => row = value; }
        public int Column { get => column; set => column = value; }
        public int Item { get => item; set => item = value; }
        public TileType Type { get => type; set => type = value; }

        #endregion

        #region Constructors

        public Tile(int row, int column, Point location)
        {
            Row = row;
            Column = column;
            Item = 0;
            Type = TileType.NONE;
            Location = location;
            Size = new Size(TILE_SIZE, TILE_SIZE);
            BorderStyle = BorderStyle.FixedSingle;
            SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public Tile(int row, int column, Point location, int item)
        {
            Row = row;
            Column = column;
            Item = item;
            Type = (TileType)item;
            Size = new Size(TILE_SIZE, TILE_SIZE);
            Location = location;
            BorderStyle = BorderStyle.FixedSingle;
            SizeMode = PictureBoxSizeMode.StretchImage;
        }

        #endregion

        #region Utility Methods

        /// <summary>
        /// Converts Tile to a string value.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Convert.ToString(Row) + "::" + Convert.ToString(Column) + "::" + Convert.ToString(Item);
        }

        /// <summary>
        /// Checks if the given tile is a key.
        /// </summary>
        /// <param name="tile"></param>
        /// <returns></returns>
        public static bool IsKey(Tile tile)
        {
            bool isKey = false;
            if (tile.Type == TileType.BLUEKEY
                || tile.Type == TileType.PURPLEKEY
                || tile.Type == TileType.REDKEY
                || tile.Type == TileType.YELLOWKEY)
            {
                isKey = true;
            }
            return isKey;
        }

        /// <summary>
        /// Checks if the key and door are the same colour.
        /// </summary>
        /// <param name="keyTile"></param>
        /// <param name="doorTile"></param>
        /// <returns></returns>
        public static bool IsKeyToDoor(Tile keyTile, Tile doorTile)
        {
            bool isKeyToDoor = false;
            if ((keyTile.Type == TileType.BLUEKEY && doorTile.Type == TileType.BLUEDOOR)
                || (keyTile.Type == TileType.PURPLEKEY && doorTile.Type == TileType.PURPLEDOOR)
                || (keyTile.Type == TileType.REDKEY && doorTile.Type == TileType.REDDOOR)
                || (keyTile.Type == TileType.YELLOWKEY && doorTile.Type == TileType.YELLOWDOOR))
            {
                isKeyToDoor = true;
            }
            return isKeyToDoor;
        }

        #endregion
    }
}

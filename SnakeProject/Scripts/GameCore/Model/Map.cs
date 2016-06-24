using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeProject.Scripts.GameCore.Model
{
    //Logical map definition
    public class Map
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int CellWidth { get; set; }
        public int HeightPixels { get; set; }
        public int WidthPixels { get; set; }

        public Map(int mapHeight, int mapWidth, int heightPixels, int widthPixels, int cellWidth)
        {
            Height = mapHeight;
            Width = mapWidth;
            HeightPixels = heightPixels;
            WidthPixels = widthPixels;
            CellWidth = cellWidth;
            Position p = new Position(0,0);
        }
    }
}
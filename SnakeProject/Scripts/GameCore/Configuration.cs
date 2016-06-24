using SnakeProject.Scripts.GameCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Controls;

namespace SnakeProject.Scripts.GameCore
{
    public class Configuration
    {
        //All parameters to define the size of the playing area (in this case Canvas)
        public int MapHeight { get; set; }
        public int MapWidth { get; set; }
        public int ScreenHeight { get; set; }
        public int ScreenWidth { get; set; }
        public int MapHeightPixels { get; set; }
        public int MapWidthPixels { get; set; }
        public int CellWidthPixels { get; set; }
        //Parameters to initialize the game
        public int InitialSizeSnake { get; set; }
        public int FoodLifeTime { get; set; }
        public Direction SnakeInitialDirection { get; set; }
        public TextBox Text { get; set; }
        public Button PauseButton { get; set; }

        private const int MARGIN_INTERN = 200;

        private static Configuration instance = new Configuration();

        public static Configuration Instance {
            get { return instance; }
        }
        
        private Configuration() { }

        public void Init(int mapHeight, int mapWidth, int screenHeight, int screenWidth, TextBox textbox, Button but)
        {
            MapHeight = mapHeight;
            MapWidth = mapWidth;
            ScreenHeight = screenHeight;
            ScreenWidth = screenWidth;
            //Choosing the min to make the palying area fit to the screen
            int ref_length;
            if (screenHeight >= screenWidth)
                ref_length = screenWidth - MARGIN_INTERN;
            else
                ref_length = screenHeight - MARGIN_INTERN;
            //Calculating cell with the longuest side of the map
            if(mapHeight >= mapWidth)
                CellWidthPixels = ref_length / mapHeight;
            else
                CellWidthPixels = ref_length / mapWidth;
            //Real size of the map in pixels
            MapHeightPixels = CellWidthPixels * mapHeight;
            MapWidthPixels = CellWidthPixels * mapWidth;

            InitialSizeSnake = 4;
            FoodLifeTime = 12;
            SnakeInitialDirection = Direction.Right;

            Text = textbox;
            PauseButton = but;
        }
    }
}
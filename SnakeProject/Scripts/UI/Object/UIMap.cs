using SnakeProject.Scripts.GameCore.Manager;
using SnakeProject.Scripts.GameCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SnakeProject.Scripts.UI.Object
{
    //graphic definition of the map
    //it has for walls
    //can be extended to have walls inside of the map itself
    public class UIMap
    {
        private List<Image> topWall;
        private List<Image> bottomWall;
        private List<Image> rightWall;
        private List<Image> leftWall;
        private Map map;
        
        public UIMap(Map map)
        {
            this.map = map;
            topWall = new List<Image>();
            bottomWall = new List<Image>();
            rightWall = new List<Image>();
            leftWall = new List<Image>();
        }

        public void Init()
        {
            int x, y;
            y = 0;
            for(int i = 0; i < map.Width; i++)
            {
                Image image = new Image();
                image.Source = ImageManager.GetImageSource(ImageId.WALL);
                image.Margin = new Thickness(y, -map.CellWidth, 0, 0);
                image.Width = map.CellWidth;
                image.Height = map.CellWidth;
                topWall.Add(image);
                y += map.CellWidth;
            }
            y = 0;
            for (int i = 0; i < map.Width; i++)
            {
                Image image = new Image();
                image.Source = ImageManager.GetImageSource(ImageId.WALL);
                image.Margin = new Thickness(y, map.HeightPixels, 0, 0);
                image.Width = map.CellWidth;
                image.Height = map.CellWidth;
                bottomWall.Add(image);
                y += map.CellWidth;
            }
            x = -map.CellWidth;
            for (int i = 0; i < map.Height + 2; i++)
            {
                Image image = new Image();
                image.Source = ImageManager.GetImageSource(ImageId.WALL);
                image.Margin = new Thickness(-map.CellWidth, x, 0, 0);
                image.Width = map.CellWidth;
                image.Height = map.CellWidth;
                leftWall.Add(image);
                x += map.CellWidth;
            }

            x = -map.CellWidth;
            for (int i = 0; i < map.Height + 2; i++)
            {
                Image image = new Image();
                image.Source = ImageManager.GetImageSource(ImageId.WALL);
                image.Margin = new Thickness(map.WidthPixels, x, 0, 0);
                image.Width = map.CellWidth;
                image.Height = map.CellWidth;
                rightWall.Add(image);
                x += map.CellWidth;
            }

        }

        public void Register(IDrawer drawer)
        {
            foreach (Image img in topWall)
            {
                drawer.Register(img);
            }

            foreach (Image img in bottomWall)
            {
                drawer.Register(img);
            }

            foreach (Image img in leftWall)
            {
                drawer.Register(img);
            }

            foreach (Image img in rightWall)
            {
                drawer.Register(img);
            }
        }

        public void Unregister(IDrawer drawer)
        {
            foreach (Image img in topWall)
            {
                drawer.Unregister(img);
            }

            foreach (Image img in bottomWall)
            {
                drawer.Unregister(img);
            }

            foreach (Image img in leftWall)
            {
                drawer.Unregister(img);
            }

            foreach (Image img in rightWall)
            {
                drawer.Unregister(img);
            }
        }
    }
}
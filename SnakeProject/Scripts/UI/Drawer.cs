using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace SnakeProject.Scripts.UI
{
    //Main object to draw all the main game objects
    public class Drawer : IDrawer
    {
        Panel Canvas { get; set; }

        public Drawer(Panel canvas, int height, int width)
        {
            Canvas = canvas;
            Canvas.HorizontalAlignment = HorizontalAlignment.Center;
            Canvas.VerticalAlignment = VerticalAlignment.Center;
            Canvas.Width = width;
            Canvas.Height = height;
            Canvas.Margin = new Thickness(0, 0, 0, 0);
        }

        public void Register(UIElement element)
        {
            Canvas.Children.Add(element);
        }

        public void Unregister(UIElement element)
        {
            Canvas.Children.Remove(element);
        }
    }
}
using SnakeProject.Scripts.GameCore;
using SnakeProject.Scripts.GameCore.Manager;
using SnakeProject.Scripts.GameCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SnakeProject.Scripts.UI.Object
{
    //Graphical definition of the snake
    class UISnake
    {
        LinkedList<Image> images;
        Snake snake;
        IDrawer drawer;
        int cell_width = Configuration.Instance.CellWidthPixels;

        public UISnake() {  }

        public void Init(IDrawer drawer,Snake snake)
        {
            images = new LinkedList<Image>();
            this.snake = snake;
            this.drawer = drawer;
            //registring the event from the snake
            snake.eventHandler += UpdateUISnakePosition;
            LinkedList<Box> body = snake.Body;
            Box head = body.Last.Value;
            foreach (Box box in body)
            {
                Image image = new Image();
                if (box == head)
                    image.Source = ImageManager.GetImageSource(ImageId.SNAKE_HEAD);
                else
                    image.Source = ImageManager.GetImageSource(ImageId.SNAKE_BODY);
                image.Margin = new Thickness(box.J * cell_width, box.I * cell_width, 0, 0);
                image.Width = cell_width;
                image.Height = cell_width;
                images.AddLast(image);
            }
        }

        void UpdateUISnakePosition(bool eats)
        {
            if (!ObjectManager.Instance.Hits)
            {
                LinkedList<Box> body = snake.Body;
                Box box = body.Last.Value;
                Box tail = body.First.Value;
                //System.Diagnostics.Debug.WriteLine("last box: " + box.J + " " + box.I);
                Image image = images.First.Value;
                Image newTail = null;
                images.RemoveFirst();
                image.Margin = new Thickness(box.J * cell_width, box.I * cell_width, 0, 0);
                image.Source = ImageManager.GetImageSource(ImageId.SNAKE_HEAD);
                Image last_head = images.Last.Value;
                last_head.Source = ImageManager.GetImageSource(ImageId.SNAKE_BODY);
                images.AddLast(image);
                if (eats)
                {
                    newTail = new Image();
                    newTail.Margin = new Thickness(tail.J * cell_width, tail.I * cell_width, 0, 0);
                    newTail.Source = ImageManager.GetImageSource(ImageId.SNAKE_BODY);
                    images.AddFirst(newTail);
                    drawer.Register(newTail);
                }
            }
        }

        public void Register(IDrawer drawer)
        {
            foreach (Image img in images)
            {
                drawer.Register(img);
            }
        }        

        public void Unregister(IDrawer drawer)
        {
            foreach (Image img in images)
            {
                drawer.Unregister(img);
            }
        }
    }
}

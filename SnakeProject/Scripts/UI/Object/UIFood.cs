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
    //graphical definition of the food
    class UIFood
    {
        private Image image;
        private Food food;
        private int cell_width = Configuration.Instance.CellWidthPixels;

        public UIFood()
        {
            image = new Image();
        }

        public void Init (Food food)
        {
            this.food = food;
            food.eventHandler += UpdateUIFoodPosition;
            Box box = food.Box;
            selectIconFood();
            image.Margin = new Thickness(box.J * cell_width, box.I * cell_width, 0, 0);
            image.Width = cell_width;
            image.Height = cell_width;
        }

        private void UpdateUIFoodPosition(bool flag)
        {
            Box box = food.Box;
            selectIconFood();
            image.Margin = new Thickness(box.J * cell_width, box.I * cell_width, 0, 0);
            image.Width = cell_width;
            image.Height = cell_width;
        }

        private void selectIconFood()
        {
            //Selecting the food's icon according to the kind
            switch (food.Kind)
            {
                case FoodKind.APPLE:
                    image.Source = ImageManager.GetImageSource(ImageId.FOOD_APPLE);
                    break;
                case FoodKind.BANANA:
                    image.Source = ImageManager.GetImageSource(ImageId.FOOD_BANANA);
                    break;
                case FoodKind.WATERMELON:
                    image.Source = ImageManager.GetImageSource(ImageId.FOOD_WATERMELON);
                    break;
                case FoodKind.BONUS:
                    image.Source = ImageManager.GetImageSource(ImageId.FOOD_BONUS);
                    break;
            }
        }

        public void Register(IDrawer drawer)
        {
            drawer.Register(image);
        }

        public void Unregister(IDrawer drawer)
        {
            drawer.Unregister(image);
        }
    }
}

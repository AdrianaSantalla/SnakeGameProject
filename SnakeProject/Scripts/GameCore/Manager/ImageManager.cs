using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace SnakeProject.Scripts.GameCore.Manager
{
    public enum ImageId
    {
        SNAKE_BODY,
        SNAKE_HEAD,
        FOOD_APPLE,
        FOOD_BANANA,
        FOOD_WATERMELON,
        FOOD_BONUS,
        WALL
    }
    //Game Image Manager, it has all the icon used on the game
    public static class ImageManager
    {
        public static ImageSource GetImageSource(ImageId imageId)
        {
            BitmapImage image = null;
            switch(imageId)
            {
                case ImageId.WALL:
                    image = new BitmapImage(new Uri("ms-appx:///Assets/GameResources/brick.png"));
                    image.DecodePixelHeight = Configuration.Instance.CellWidthPixels;
                    image.DecodePixelWidth = Configuration.Instance.CellWidthPixels;
                    break;
                case ImageId.SNAKE_BODY:
                    image = new BitmapImage(new Uri("ms-appx:///Assets/GameResources/snake_body.png"));
                    image.DecodePixelHeight = Configuration.Instance.CellWidthPixels;
                    image.DecodePixelWidth = Configuration.Instance.CellWidthPixels;
                    break;
                case ImageId.SNAKE_HEAD:
                    image = new BitmapImage(new Uri("ms-appx:///Assets/GameResources/snake_head.png"));
                    image.DecodePixelHeight = Configuration.Instance.CellWidthPixels;
                    image.DecodePixelWidth = Configuration.Instance.CellWidthPixels;
                    break;
                case ImageId.FOOD_APPLE:
                    image = new BitmapImage(new Uri("ms-appx:///Assets/GameResources/apple_food.png"));
                    image.DecodePixelHeight = Configuration.Instance.CellWidthPixels;
                    image.DecodePixelWidth = Configuration.Instance.CellWidthPixels;
                    break;
                case ImageId.FOOD_BANANA:
                    image = new BitmapImage(new Uri("ms-appx:///Assets/GameResources/banana_food.png"));
                    image.DecodePixelHeight = Configuration.Instance.CellWidthPixels;
                    image.DecodePixelWidth = Configuration.Instance.CellWidthPixels;
                    break;
                case ImageId.FOOD_WATERMELON:
                    image = new BitmapImage(new Uri("ms-appx:///Assets/GameResources/watermelon_food.png"));
                    image.DecodePixelHeight = Configuration.Instance.CellWidthPixels;
                    image.DecodePixelWidth = Configuration.Instance.CellWidthPixels;
                    break;
                case ImageId.FOOD_BONUS:
                    image = new BitmapImage(new Uri("ms-appx:///Assets/GameResources/bonus_food.png"));
                    image.DecodePixelHeight = Configuration.Instance.CellWidthPixels;
                    image.DecodePixelWidth = Configuration.Instance.CellWidthPixels;
                    break;
            }
            return image;            
        }
    }
}

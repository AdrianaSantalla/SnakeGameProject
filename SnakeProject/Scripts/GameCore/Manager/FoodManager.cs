using SnakeProject.Scripts.GameCore.Model;
using SnakeProject.Scripts.UI;
using SnakeProject.Scripts.UI.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeProject.Scripts.GameCore.Manager
{
    //Manager of the Food and the UIFood
    public class FoodManager
    {
        private static FoodManager instance = new FoodManager();
        private Food food;

        public Food Food {
            get { return food; }
            set { food = value; }
        }

        private IDrawer drawer;
        private UIFood uifood;

        private FoodManager() {}

        public static FoodManager Instance
        {
            get { return instance; }
        }

        public void Init(IDrawer drawer, Snake snake)
        {
            instance.drawer = drawer;
            food = new Food();
            food.Init(snake);
            uifood = new UIFood();
            uifood.Init(food);
        }

        public void Display()
        {
            uifood.Register(drawer);
        }

        public void Hide()
        {
            uifood.Unregister(drawer);
        }

        public void Update(float elapsedTime,Snake snake)
        {
            food.Update(elapsedTime,snake);
        }
    }
}
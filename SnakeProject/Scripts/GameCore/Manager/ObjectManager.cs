using SnakeProject.Scripts.GameCore.Model;
using SnakeProject.Scripts.UI;
using SnakeProject.Scripts.UI.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.System;
using static SnakeProject.Scripts.GameCore.Manager.InGameManager;

namespace SnakeProject.Scripts.GameCore.Manager
{
    //Manager of all the objects in the game
    //It manages the snake and UI snake and the food and map managers
    //The events are send to the objects and managers
    public class ObjectManager
    {
        private IDrawer drawer;
        private Snake snake;
        private UISnake uisnake;

        private FoodManager foodManager;
        private MapManager mapManager;
        private InGameManager inGameManager;

        private bool hits;
        public bool Hits
        {
            get { return hits; }
            set { hits = value; }

        }

        private static ObjectManager instance = new ObjectManager();

        public static ObjectManager Instance
        {
            get { return instance; }
        }

        private ObjectManager() { }

        public void Init(IDrawer drawer, InGameManager inGameManager)
        {
            this.drawer = drawer;
            this.inGameManager = inGameManager;

            foodManager = FoodManager.Instance;
            mapManager = MapManager.Instance;
            snake = new Snake();
            uisnake = new UISnake();

            mapManager.Init(drawer);
            snake.Init();
            uisnake.Init(drawer, snake);
            foodManager.Init(drawer, snake);
            hits = false;
        }

        public void Display()
        {
            mapManager.Display();
            uisnake.Register(drawer);
            foodManager.Display();
        }

        public void Hide()
        {
            mapManager.Hide();
            uisnake.Unregister(drawer);
            foodManager.Hide();
        }

        public void Update(float elapsedTime)
        {
            if (hits)
            {
                inGameManager.SetState(State.FINISHED);
            }
            else
            {
                snake.Update(elapsedTime, foodManager.Food);
                foodManager.Update(elapsedTime,snake);
            }
        }

        public void HandleKey(VirtualKey key)
        {
            snake.HandleKey(key);
        }
    }
}
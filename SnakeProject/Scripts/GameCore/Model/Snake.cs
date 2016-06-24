using SnakeProject.Scripts.GameCore.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.System;

namespace SnakeProject.Scripts.GameCore.Model
{
    //delegate to send the update event to the UISnake
    public delegate void EventUpdateHandler(bool eats);
    //Main definition of the snake (logical)
    public class Snake
    {
        public event EventUpdateHandler eventHandler;
        private LinkedList<Box> body;
        public LinkedList<Box> Body {
            get { return body; }
            set { body = value; }
        }
        private int Speed { get; set; }
        private int friction = 10; // value to control the velocity of the snake
        private int timesEaten = 0;
        private int frameId;
        private Direction direction = Configuration.Instance.SnakeInitialDirection;
        private int length_snake = Configuration.Instance.InitialSizeSnake;
        
        public Snake () {  }

        public void Init ()
        {
            Body = new LinkedList<Box>();
            for (int i = 0; i < length_snake; i++)
            {
                //the snake is located in the middle of the screen and goes from left to right
                Box box = new Box(Configuration.Instance.MapHeight / 2, i);
                Body.AddLast(box);
            }
        }

        public void Update(float elapsedSeconds, Food food)
        {
            frameId++;
            if (frameId > friction)
            {
                Move(direction, food);
                frameId = 0;
            }
            if (friction < 4)
                food.LifeTime = 6;
        }
        //method to "move" the logical snake
        //each move it's necessary to check if it eats or hits the walls or itself
        public void Move(Direction direction, Food food)
        {
            Box box = Body.First.Value;
            Box tail = null;
            Body.RemoveFirst();
            bool eats = Body.Last.Value.Equals(food.Box);
            if(eats)
            {
                tail = new Box(box.I, box.J);
                Body.AddFirst(tail);
                //System.Diagnostics.Debug.WriteLine("food kind score " + (int)food.Kind + " "+ food.Kind);
                InGameManager.Instance.score += (int)food.Kind;
                food.GetRandomFoodBox();
                timesEaten++;
                if(timesEaten == 3)
                { 
                    friction--;
                    timesEaten = 0;                    
                }                
            }
            switch (direction)
            {   //the collision with the map is defined by the size of the map
                //if the snake goes beyond those limits, means collision
                case Direction.Right:
                    box.J = Body.Last.Value.J + 1;
                    box.I = Body.Last.Value.I;
                    if (box.J == Configuration.Instance.MapWidth)
                        ObjectManager.Instance.Hits = true;
                    break;
                case Direction.Left:
                    box.J = Body.Last.Value.J - 1;
                    box.I = Body.Last.Value.I;
                    if (box.J == -1)
                        ObjectManager.Instance.Hits = true;
                    break;
                case Direction.Down:
                    box.I = Body.Last.Value.I + 1;
                    box.J = Body.Last.Value.J;
                    if (box.I == Configuration.Instance.MapHeight)
                        ObjectManager.Instance.Hits = true;
                    break;
                case Direction.Up:
                    box.I = Body.Last.Value.I - 1;
                    box.J = Body.Last.Value.J;
                    if (box.I == -1)
                        ObjectManager.Instance.Hits = true;
                    break;
            }
            if (Body.Contains(box))
            {
                System.Diagnostics.Debug.WriteLine("collision with itself");
                ObjectManager.Instance.Hits = true;
            }
            Body.AddLast(box);
            //sending the event to the UISnake
            eventHandler?.Invoke(eats);
        }
        //method to check the key events
        public void HandleKey(VirtualKey key)
        {
            switch (key)
            {
                case VirtualKey.Down:
                    if(direction == Direction.Right || direction == Direction.Left)
                        direction = Direction.Down;
                    break;
                case VirtualKey.Up:
                    if (direction == Direction.Right || direction == Direction.Left)
                        direction = Direction.Up;
                    break;
                case VirtualKey.Right:
                    if (direction == Direction.Down || direction == Direction.Up)
                        direction = Direction.Right;
                    break;
                case VirtualKey.Left:
                    if (direction == Direction.Down || direction == Direction.Up)
                        direction = Direction.Left;
                    break;
            }
            System.Diagnostics.Debug.WriteLine("key direction " + direction);
        }
    }

}
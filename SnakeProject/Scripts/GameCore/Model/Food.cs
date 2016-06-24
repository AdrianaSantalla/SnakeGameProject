using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeProject.Scripts.GameCore.Model
{
    //Logic food definition
    //A food has a kind and a limited life time in the map
    //There is a bonus food which last the half of this time
    public class Food
    {
        public event EventUpdateHandler eventHandler;
        private Box box;
        public Box Box
        {
            get { return box; }
            set { box = value; }
        }
        private FoodKind kind;
        public FoodKind Kind
        {
            get { return kind; }
            set { kind = value; }
        }
        private int lifeTime = Configuration.Instance.FoodLifeTime;
        public int LifeTime
        {
            get { return lifeTime; }
            set { lifeTime = value; }
        }
        private Snake snake;
        private float totalElapsedSeconds;
        private Random random;

        public Food () { }

        public void Init(Snake snake)
        {
            this.snake = snake;
            GetRandomFoodBox();
        }

        public void Update(float elapsedTime, Snake snake)
        {
            totalElapsedSeconds += elapsedTime;
            if (totalElapsedSeconds > LifeTime)
            {
                this.snake = snake;
                GetRandomFoodBox();
            }            
        }
        //generating random position of the food and checking if the position is not used by the snake
        public void GetRandomFoodBox()
        {
            totalElapsedSeconds = 0;
            random = new Random();
            int i = random.Next(Configuration.Instance.MapHeight);
            int j = random.Next(Configuration.Instance.MapHeight);
            Box = new Box(i, j);
            if (snake.Body.Contains(Box))
                GetRandomFoodBox();
            else
            {
                Array values = Enum.GetValues(typeof(FoodKind));
                random = new Random();
                Kind = (FoodKind)values.GetValue(random.Next(values.Length));
                int lifeTime = LifeTime;
                if (Kind == FoodKind.BONUS)
                    LifeTime = 5;
                else
                    LifeTime = Configuration.Instance.FoodLifeTime;
                //System.Diagnostics.Debug.WriteLine("food kind: " + Kind);
            }            
            eventHandler?.Invoke(true);
        }
    }
}
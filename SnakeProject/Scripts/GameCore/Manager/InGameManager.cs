using SnakeProject.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.System;
using Windows.UI.Xaml;

namespace SnakeProject.Scripts.GameCore.Manager
{   //Game Manager
    //It has an object Manager to which it sends the events
    //It control the state of the game and has the score of the game
    public class InGameManager
    {
        //Game states
        public enum State
        {
            READY,
            RUNNING,
            FINISHED
        }

        private float totalElapsedSeconds;
        private IDrawer drawer;
        private ObjectManager objectManager;
        private State state;
        public int score;

        private static InGameManager instance = new InGameManager();

        public static InGameManager Instance
        {
            get { return instance; }
        }

        private InGameManager() { }

        public void Init(IDrawer drawer)
        {
            this.drawer = drawer;
            objectManager = ObjectManager.Instance;
            objectManager.Init(drawer, this);
            score = 0;
        }

        public void Display()
        {
            objectManager.Display();
        }

        public void Reset()
        {
            objectManager.Hide();
            SetState(State.READY);
            Init(drawer);
            objectManager.Display();
        }

        public void Update(float elapsedTime)
        {
            totalElapsedSeconds += elapsedTime;
            switch (state)
            {
                case State.READY:
                    Configuration.Instance.Text.Text = "GET READY!";
                    if (totalElapsedSeconds > 3f)//3 seconds of preparation before starting
                    {
                        Configuration.Instance.PauseButton.IsEnabled = true;
                        SetState(State.RUNNING);
                    }
                    break;
                case State.RUNNING:// constant update of the game while running to update the objects
                    Configuration.Instance.Text.Text = "RUNNING \nScore: " + score;
                    objectManager.Update(elapsedTime);
                    break;
                case State.FINISHED:
                    //System.Diagnostics.Debug.WriteLine("FINISH");
                    Configuration.Instance.Text.Text = "GAME OVER \nScore: "+ score;
                    Configuration.Instance.PauseButton.IsEnabled = false;
                    break;
            }            
        }

        public void HandleKey(VirtualKey key)
        {
            objectManager.HandleKey(key);
        }

        public void SetState(State state)
        {
            this.state = state;
        }
    }
}
using SnakeProject.Scripts.UI;
using SnakeProject.Scripts.UI.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace SnakeProject.Scripts.GameCore.Manager
{
    // Class to mage the different screen of the game. Can be extended.
    // In this game just one screen needed
    public class ScreenManager
    {
        private IDrawer drawer;
        //caching of screens
        private BaseScreen[] screens;
        private BaseScreen currentScreen;
        private ScreenId currentScreenId;
        private DispatcherTimer timer;
        private DateTimeOffset lastTime;

        private static ScreenManager instance = new ScreenManager();

        public static ScreenManager Instance
        {
            get { return instance; }
        }

        public void Init(Panel drawObject)
        {
            //Adding the key even to the screen
            Window.Current.CoreWindow.KeyDown += this.handleKeyPress;
            //Creating the a custom object to draw
            drawer = new Drawer(drawObject, Configuration.Instance.MapHeightPixels, Configuration.Instance.MapWidthPixels);
            screens = new BaseScreen[(int)ScreenId.TOTAL];
            //Showing the Game Screen
            Show(ScreenId.GAME);
            Start();            
        }

        public void Start()
        {
            lastTime = DateTimeOffset.Now;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(170000);//Updates 60 frames per sec
            timer.Tick += Tick;
            timer.Start();
        }

        private void handleKeyPress(CoreWindow sender, KeyEventArgs args)
        {
            VirtualKey key; key = args.VirtualKey;
            HandleKey(key);
        }

        void Tick(object sender, object e)
        {
            DateTimeOffset now = DateTimeOffset.Now;
            TimeSpan span = now - lastTime;
            lastTime = now;
            //System.Diagnostics.Debug.WriteLine("update elapsed: " + (span.Milliseconds / 1000f));
            Update(span.Milliseconds / 1000f);
        }

        public void Stop ()
        {
            timer.Stop();
        }

        public void Show(ScreenId screenId)
        {
            if (screenId != currentScreenId)
            {
                Hide(currentScreenId);
                currentScreenId = screenId;
                currentScreen = GetScreen(screenId);
                currentScreen.Display();
            }
        }

        void Update(float elapsedSeconds)
        {
            currentScreen.Update(elapsedSeconds);
        }

        void HandleKey(VirtualKey key)
        {
            currentScreen.HandleKey(key);
        }

        void Hide(ScreenId screenId)
        {
            if (currentScreen != null)
            {
                currentScreen.Hide();
            }
        }
        //Getting and initializing the required screen (GameScreen)
        BaseScreen GetScreen(ScreenId screenId)
        {
            if (screens[(int)screenId] != null) {
                return screens[(int)screenId];
            }

            BaseScreen screen = null;
            switch (screenId)
            {
                case ScreenId.GAME:
                    screen = new GameScreen(drawer);
                    screens[(int)screenId] = screen;
                    break;
            }
            if (screen != null)
            {
                screen.Init();
            }
            return screen;
        }
    }
}
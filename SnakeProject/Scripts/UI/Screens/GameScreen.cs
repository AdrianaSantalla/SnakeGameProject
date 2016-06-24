using SnakeProject.Scripts.GameCore.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SnakeProject.Scripts.UI.Screens
{
    //Game Screen
    public class GameScreen : BaseScreen
    {
        //Has a InGameManager
        //It passes all the events to the InGameManager
        private InGameManager inGameManager;

        public GameScreen (IDrawer drawer)
        {
            this.drawer = drawer;
        }

        public override void Init()
        {
            inGameManager = InGameManager.Instance;
            inGameManager.Init(drawer);
        }

        public override void Display()
        {
            inGameManager.Display();
        }

        public override void Hide()
        {
            inGameManager.Reset();
        }

        public override void Update(float elapsedTime)
        {
            inGameManager.Update(elapsedTime);
        }

        public override void HandleKey(VirtualKey key)
        {
            inGameManager.HandleKey(key);
        }
    }
}
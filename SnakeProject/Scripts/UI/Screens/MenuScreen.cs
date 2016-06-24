using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.System;
using Windows.UI.Xaml.Controls;

namespace SnakeProject.Scripts.UI.Screens
{
    public class MenuScreen : BaseScreen
    {
        Button buttonPlay;
        Button buttonClose;
         
        public MenuScreen(IDrawer drawer)
        {
            this.drawer = drawer;
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }

        public override void HandleKey(VirtualKey key)
        {
            throw new NotImplementedException();
        }

        public override void Hide()
        {
            throw new NotImplementedException();
        }

        public override void Init()
        {
            throw new NotImplementedException();
        }

        public override void Update(float elapsedTime)
        {
            throw new NotImplementedException();
        }
    }
}
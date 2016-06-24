using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace SnakeProject.Scripts.UI.Screens
{   
    public enum ScreenId
    {
        NIL,
        SPLASH,
        MENU,
        GAME,
        TOTAL
    }

    //Definition of a BaseScreen with base methods associated to it
    abstract public class BaseScreen
    {
        protected IDrawer drawer;
        abstract public void Init();
        abstract public void Update(float elapsedTime);
        abstract public void HandleKey(VirtualKey key);
        abstract public void Display();
        abstract public void Hide();
    }
}

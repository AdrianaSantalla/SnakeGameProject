using SnakeProject.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace SnakeProject.Scripts.GameCore.Manager
{
    //public delegate void handleKeyPress(CoreWindow sender, KeyEventArgs args);
    //class to implement touches but not finished for this release
    class TouchManager
    {
        Panel drawer;
        //public event handleKeyPress eventHandler;

        private static TouchManager instance = new TouchManager();

        public static TouchManager Instance
        {
            get { return instance; }
        }

        public void Init(Panel drawer)
        {
            this.drawer = drawer;
            drawer.KeyDown += handleKeyPress;
        }
        
        private void handleKeyPress(object sender, KeyRoutedEventArgs args)
        {
            System.Diagnostics.Debug.WriteLine("key event: "+sender+" "+args);
        }
    }
}

using SnakeProject.Scripts.GameCore;
using SnakeProject.Scripts.GameCore.Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SnakeProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        bool gameRunning = true;
        public MainPage()
        {
            this.InitializeComponent();
            //Initialization of all the configuration for the game
            Configuration.Instance.Init(20, 20, (int)Window.Current.Bounds.Height, (int)Window.Current.Bounds.Width, textBox, button1);
            //Initializatioin of the screen manager of the game
            ScreenManager.Instance.Init(UICanvas);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            InGameManager.Instance.Reset();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (gameRunning)
            {
                ScreenManager.Instance.Stop();
                gameRunning = false;
                textBox.Text = "PAUSE";
            }
            else
            {
                ScreenManager.Instance.Start();
                gameRunning = true;
                textBox.Text = "RUNNING \nScore: " + InGameManager.Instance.score;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml;

namespace SnakeProject.Scripts.UI
{
    public interface IDrawer
    {
        void Register(UIElement element);
        void Unregister(UIElement element);
    }
}
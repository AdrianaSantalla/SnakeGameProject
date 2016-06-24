using SnakeProject;
using SnakeProject.Scripts.GameCore.Model;
using SnakeProject.Scripts.UI;
using SnakeProject.Scripts.UI.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeProject.Scripts.GameCore.Manager
{
    //Manager ot the Map and UIMap
    public class MapManager
    {
        private static MapManager instance = new MapManager(); 
        private Map map;
        private IDrawer drawer;
        private UIMap uimap;

        private MapManager() { }

        public static MapManager Instance
        {
            get { return instance; }
        }

        public void Init(IDrawer drawer)
        {
            instance.drawer = drawer; 
            map = new Map(Configuration.Instance.MapHeight,
                Configuration.Instance.MapWidth,
                Configuration.Instance.MapHeightPixels,
                Configuration.Instance.MapWidthPixels, 
                Configuration.Instance.CellWidthPixels);
            uimap = new UIMap(map);
            uimap.Init();
        }

        public void Display()
        {
            uimap.Register(drawer);
        }

        public void Hide()
        {
            uimap.Unregister(drawer);
        }
    }
}
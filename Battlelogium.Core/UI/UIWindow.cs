using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Battlelogium.Core.UI
{
    public class UIWindow : Window
    {
        public MouseButtonEventHandler rightDragBtnDown;
        public MouseEventHandler rightDragMove;


        public Battlelog battlelog;
        public UICore process;
        public Config config;
        public Grid mainGrid;

        public UIWindow()
        {

        }
    }
}

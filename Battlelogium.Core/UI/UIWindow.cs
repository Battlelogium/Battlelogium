using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Battlelogium.ThirdParty.Animator;
using System.Windows.Media;
using System.Windows.Shell;

namespace Battlelogium.Core.UI
{
    public partial class UIWindow : Window
    {
        public MouseButtonEventHandler rightDragBtnDown;
        public MouseEventHandler rightDragMove;


        public Battlelog battlelog;
        public Animator loadingIcon;
        public UICore process;
        public Config config;
        public Grid mainGrid;

        public UIWindow()
        {
            
        }
    }
}

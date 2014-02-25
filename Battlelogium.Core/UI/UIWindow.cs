using Battlelogium.ThirdParty.Animator;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Battlelogium.Core.Utilities;

namespace Battlelogium.Core.UI
{
    /// <summary>
    /// Provides methods that interact with the Window only, rather than the user interface as a whole.
    /// </summary>
    public partial class UIWindow : Window
    {
        private MouseButtonEventHandler rightDragBtnDown;
        private MouseEventHandler rightDragMove;

        public Battlelog battlelog;
        public Config config;

        public Animator loadingIcon;
        public UICore uiCore;
     
        public Grid mainGrid;
        public Label versionLabel;
        public UIWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Closing += (s, e) => this.SaveBounds();
        }
    }
}

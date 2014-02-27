using Battlelogium.ThirdParty.Animator;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Battlelogium.Core.Utilities;
using Battlelogium.Core.Configuration;
using Battlelogium.Core.Battlelog;
using System.Windows.Shell;

namespace Battlelogium.Core.UI
{
    /// <summary>
    /// Provides methods that interact with the Window only, rather than the user interface as a whole.
    /// </summary>
    public partial class UIWindow : Window
    {
        private MouseButtonEventHandler rightDragBtnDown;
        private MouseEventHandler rightDragMove;

        public UIControl MainControl { get; protected set; }
        public UICore UICore { get; private set; }

        public bool IsCoreInitialized { get; private set; }

        public UIWindow()
        {
            this.SourceInitialized += (s, e) => 
            {
                this.HideWindowButtons();
                WindowChrome.SetWindowChrome(this, new WindowChrome()
                {
                    CaptionHeight = 14D,
                    ResizeBorderThickness = new Thickness(3D)
                });
            };
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Closing += (s, e) => this.SaveBounds();
        }

        public void InitializeCore(BattlelogBase battlelog)
        {
            this.UICore = new UICore(this, battlelog, new Config());
            this.IsCoreInitialized = true;
            this.UICore.Initialize();
        }
    }
}

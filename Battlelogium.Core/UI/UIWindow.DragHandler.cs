using System.Windows;
using System.Windows.Input;

namespace Battlelogium.Core.UI
{
    public partial class UIWindow
    {
        public bool RightClickDragEnabled { get; private set; }
        public bool RightClickDragInitialized { get; private set; }
        public void InitRightClickDrag()
        {
            Point startPosition = new Point();
            this.rightDragBtnDown = (sender, e) =>
            {
                startPosition = e.GetPosition(this);
            };

            this.rightDragMove += (sender, e) =>
            {
                if (e.RightButton == MouseButtonState.Pressed)
                {
                    Point endPosition = e.GetPosition(this);
                    Vector vector = endPosition - startPosition;
                    this.Left += vector.X;
                    this.Top += vector.Y;
                }
            };
            this.RightClickDragInitialized = true;
        }

        public void EnableRightClickDrag()
        {
            if (this.rightDragBtnDown == null || this.rightDragMove == null) return;
            this.PreviewMouseRightButtonDown += this.rightDragBtnDown;
            this.PreviewMouseMove += this.rightDragMove;
            this.RightClickDragEnabled = true;
        }
        public void DisableRightClickDrag()
        {
            if (this.rightDragBtnDown == null || this.rightDragMove == null) return;
            this.PreviewMouseRightButtonDown -= this.rightDragBtnDown;
            this.PreviewMouseMove -= this.rightDragMove;
            this.RightClickDragEnabled = false;
        }

    }
}

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

namespace Battlelogium.Core.UI
{
    public partial class UIWindow
    {
        public void RightClickDrag()
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

            this.PreviewMouseRightButtonDown += this.rightDragBtnDown;
            this.PreviewMouseMove += this.rightDragMove;
        }

        public void DisableRightClickDrag()
        {
            this.PreviewMouseRightButtonDown -= this.rightDragBtnDown;
            this.PreviewMouseMove -= this.rightDragMove;
        }

    }
}

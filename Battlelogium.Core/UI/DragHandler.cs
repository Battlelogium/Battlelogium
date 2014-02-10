using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Battlelogium.Core.UI
{
    public static class DragHandler
    {
        public static void RightClickDrag(this UIWindow window)
        {
            Point startPosition = new Point();
            window.rightDragBtnDown = (sender, e) =>
            {
                startPosition = e.GetPosition(window);
            };

            window.rightDragMove += (sender, e) =>
            {
                if (e.RightButton == MouseButtonState.Pressed)
                {
                    Point endPosition = e.GetPosition(window);
                    Vector vector = endPosition - startPosition;
                    window.Left += vector.X;
                    window.Top += vector.Y;
                }
            };

            window.PreviewMouseRightButtonDown += window.rightDragBtnDown;
            window.PreviewMouseMove += window.rightDragMove;
        }

        public static void DisableRightClickDrag(this UIWindow window)
        {
            window.PreviewMouseRightButtonDown -= window.rightDragBtnDown;
            window.PreviewMouseMove -= window.rightDragMove;
        }
    }
}

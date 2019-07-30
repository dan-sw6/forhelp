using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalRailEditor.SectionEditor
{
    public partial class SectionEditorWindow
    {
        private ScaleTransform st = new ScaleTransform();
        private Thickness position;
        private Point PointMousePressed = new Point();
        private bool canvas_dragged = false;

        private void Border_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
            Point PointMouseWheel = e.GetPosition(controlBorder);
            position = controlBorder.Margin;
            if (e.Delta > 0) { position.Left -= PointMouseWheel.X * 0.1 * st.ScaleX; position.Top -= PointMouseWheel.Y * 0.1 * st.ScaleY; st.ScaleX *= 1.1; }
            if (e.Delta < 0) { st.ScaleX /= 1.1; position.Left += PointMouseWheel.X * 0.1 * st.ScaleX; position.Top += PointMouseWheel.Y * 0.1 * st.ScaleX; }
            controlBorder.Margin = position;
            st.ScaleY = st.ScaleX;
        }
        private void Border_MouseCenterButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.MiddleButton == MouseButtonState.Pressed)
            {
                canvas_dragged = controlBorder.CaptureMouse();
                PointMousePressed = e.GetPosition(controlBorder);
            }
        }
        /// <summary>
        /// Отпускание центральной кнопки для окончания движения канваса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Border_MouseCenterButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.MiddleButton == MouseButtonState.Released && canvas_dragged)
            {
                canvas_dragged = false;
                controlBorder.ReleaseMouseCapture();
            }
        }
        /// <summary>
        /// Движение канваса при удержании центральной кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            Point PointMouseMoved = e.GetPosition(controlBorder);
            if (!canvas_dragged) return;
            position = controlBorder.Margin;
            position.Left += (PointMouseMoved.X - PointMousePressed.X) * st.ScaleX;
            position.Top += (PointMouseMoved.Y - PointMousePressed.Y) * st.ScaleY;
            controlBorder.Margin = position;
        }
    }
}

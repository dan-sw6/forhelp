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

namespace FinalRailEditor.SectionEditor.SeControl
{
    public partial class SecEditorControl : UserControl
    {
        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            int row = (int)Canvas.ActualHeight / Step;
            int column = (int)Canvas.ActualWidth / Step;
            list = new List<Thickness>();
            for (int i = 0; i < column - 1; i++)
            {
                for (int j = 0; j < row - 1; j++)
                {
                    Thickness thickness = new Thickness();
                    thickness.Left = Step / 2 + i * Step;
                    thickness.Top = Step / 2 + j * Step;
                    thickness.Right = Step * (i + 1) + Step / 2;
                    thickness.Bottom = Step * (j + 1) + Step / 2;
                    list.Add(thickness);
                }
            }
            ellipse = new Ellipse();
            ellipse.Width = 10;
            ellipse.Height = 10;
            ellipse.Style = (Style)Application.Current.FindResource("ElliStyle");
            Canvas.Children.Add(ellipse);
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point pos = e.GetPosition(this);
            var str = list.Where(n => ((n.Left < pos.X) && (n.Right > pos.X) && (n.Top < pos.Y) && (n.Bottom > pos.Y)));
            Thickness ness = str.FirstOrDefault();
            if (str.Count() != 0)
            {
                Canvas.SetLeft(ellipse, ness.Left + Step / 4 - 0.25);
                Canvas.SetTop(ellipse, ness.Top + Step / 4 - 0.25);
            }
        }
    }

    public class Tools
    {
        public static Style CalculateStyle(Shape shape)
        {
            Style style = new Style();
            if ((shape is Ellipse)==true)
            {
                style.TargetType = typeof(Ellipse);
                style.Setters.Add(new Setter(Shape.FillProperty, Brushes.Black));
                style.Setters.Add(new Setter(Shape.OpacityProperty, 0.8));
               
            }
            return style;
        }
    }
}

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
        const int Step = 20;
        bool ContextMenuClosed = true;
        /// <summary>
        /// Коллекция с ячейками, где может быть привязвка
        /// </summary>
        List<Thickness> YesList = new List<Thickness>();
        List<Thickness> NoneList = new List<Thickness>();
        List<Thickness> NoneListCirc = new List<Thickness>();

        Path path ;
        EllipseGeometry ellipseGeometry;
        

        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            int row = (int)Canvas.ActualHeight / Step;
            int column = (int)Canvas.ActualWidth / Step;

            for (int i = 0; i < column - 1; i++)
            {
                for (int j = 0; j < row - 1; j++)
                {
                    Thickness thickness = new Thickness();
                    thickness.Left = Step / 2 + i * Step;
                    thickness.Top = Step / 2 + j * Step;
                    thickness.Right = Step * (i + 1) + Step / 2;
                    thickness.Bottom = Step * (j + 1) + Step / 2;
                    YesList.Add(thickness);
                }
            }
            path = new Path();
            ellipseGeometry = new EllipseGeometry { RadiusX = 5, RadiusY=5 };
            path.Data = ellipseGeometry;
            path.Style = (Style)Application.Current.FindResource("PathStyle");
            Canvas.Children.Add(path);
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (ContextMenuClosed)
            {
                Point pos = e.GetPosition(this);
                Thickness ness = GetThickness(pos, YesList);
                ellipseGeometry.Center = new Point(ness.Left + Step / 2 - 0.25, ness.Top + Step / 2 - 0.25);            
            }        
        }
        private void Canvas_LeftButtonCircuit(object sender, MouseButtonEventArgs e)
        {
            if (HitList.Count > 0)
            {
                var selected = HitList.Where(b => b is StationIconElement);
                if (selected.Count() > 0)
                {
                    if (e.ChangedButton == MouseButton.Left)
                    {
                        StationIconElement station = (StationIconElement)selected.First();
                        EllipseGeometry ellipse = (EllipseGeometry)station.Icon;
                        line.EndPoint = ellipse.Center;
                        Thickness start = GetThickness(line.StartPoint, NoneList);
                        Thickness end = GetThickness(line.EndPoint, NoneList);
                        if (start.Left < end.Left)
                        {
                            if (start.Top<end.Top)
                            {
                                var vpl = YesList.Where(a => (a.Left >= start.Left) && (a.Left <= end.Left)
                                                              && (a.Top >=start.Top)&&(a.Top<=end.Top));
                                NoneListCirc.AddRange(vpl);
                                YesList.RemoveAll(x => vpl.Contains(x));
                            }
                            else
                            {
                                var vpl = YesList.Where(a => (a.Left >= start.Left) && (a.Left <= end.Left)
                                                             && (a.Top <= start.Top) && (a.Top >= end.Top));
                                NoneListCirc.AddRange(vpl);
                                YesList.RemoveAll(x => vpl.Contains(x));
                            }
                        }
                        else
                        {
                            if (start.Top < end.Top)
                            {
                                var vpl = YesList.Where(a => (a.Left <= start.Left) && (a.Left >= end.Left)
                                                             && (a.Top >= start.Top) && (a.Top <= end.Top));
                                NoneListCirc.AddRange(vpl);
                                YesList.RemoveAll(x => vpl.Contains(x));
                            }
                            else
                            {
                                var vpl = YesList.Where(a => (a.Left <= start.Left) && (a.Left >= end.Left)
                                                            && (a.Top <= start.Top) && (a.Top >= end.Top));
                                NoneListCirc.AddRange(vpl);
                                YesList.RemoveAll(x => vpl.Contains(x));
                            }
                        }
                        Canvas.MouseMove += Canvas_MouseMove;
                        Canvas.MouseMove -= Canvas_MoveLine;
                        path.Opacity = 1.0;
                        Canvas.MouseLeftButtonDown -= Canvas_LeftButtonCircuit;
                    }
                }
            }
        }

        private void Canvas_MoveLine(object sender, MouseEventArgs e)
        {
            line.EndPoint = e.GetPosition(Canvas);
            HitList.Clear();
            VisualTreeHelper.HitTest(Canvas, null,
                 new HitTestResultCallback(MyHitTestResult),
                 new PointHitTestParameters(e.GetPosition(Canvas)));
        }

        private HitTestResultBehavior MyHitTestResult(HitTestResult result)
        { 
            HitList.Add(result.VisualHit);
            return HitTestResultBehavior.Continue;
        }
        private Thickness GetThickness (Point pos, List<Thickness> list)
        {
            var str = list.Where(n => ((n.Left <= pos.X) && (n.Right >= pos.X) && (n.Top <= pos.Y) && (n.Bottom >= pos.Y)));
            if (str.Count() == 0) path.Opacity = 0.0;
            else path.Opacity = 1.0;
                return str.FirstOrDefault();
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

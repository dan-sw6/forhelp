using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Xaml.Behaviors;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace FinalRailEditor.SectionEditor.SeControl
{
    public partial class SecEditorControl
    {
        LineGeometry line;
        private void Cmd_CreateStation(object sender, ExecutedRoutedEventArgs e)
        {
            StationIconElement iconElement = new StationIconElement();
            EllipseGeometry ellipse = new EllipseGeometry();
            ellipse.RadiusX = 7.5;
            ellipse.RadiusY = 7.5;
            Path arriver = (Path)e.OriginalSource;
            EllipseGeometry geometry = (EllipseGeometry)arriver.Data;
            Point pos = geometry.Center;
            var str = YesList.Where(n => ((n.Left < pos.X) && (n.Right > pos.X) && (n.Top < pos.Y) && (n.Bottom > pos.Y)));
            Thickness ness = str.FirstOrDefault();
            ellipse.Center = new Point(ness.Left+Step/2-0.25, ness.Top+Step/2-0.25);
            YesList.Remove(ness);
            NoneList.Add(ness);
            iconElement.Icon = ellipse;
            iconElement.Style = (Style)Application.Current.FindResource("IconStyle");
            DragInCanvasBehavior dragInCanvas = new DragInCanvasBehavior();
            Interaction.GetBehaviors(iconElement).Add(dragInCanvas);
            Canvas.Children.Add(iconElement);
            Canvas.SetZIndex(iconElement, 2);

        }
        private void Cmd_DeleteStation(object sender, ExecutedRoutedEventArgs e)
        {
            StationIconElement arriver = (StationIconElement)e.OriginalSource;
            EllipseGeometry geometry = (EllipseGeometry)arriver.Icon;
            Point pos = geometry.Center;
            Thickness ness = GetThickness(pos, NoneList);
            YesList.Add(ness);
            NoneList.Remove(ness);
            Canvas.Children.Remove(arriver);
            ContextMenuClosed = true;
        }
        private void Cmd_ConnectStation(object sender, ExecutedRoutedEventArgs e)
        {
            CircuitIconElement circuitIconElement = new CircuitIconElement();
            line = new LineGeometry();
            circuitIconElement.Icon = line;
            StationIconElement arriver = (StationIconElement)e.OriginalSource;
            EllipseGeometry geometry = (EllipseGeometry)arriver.Icon;
            Point pos = geometry.Center;
            Thickness ness = GetThickness(pos,NoneList);
            line.StartPoint = new Point(ness.Left + Step / 2 - 0.25, ness.Top + Step / 2 - 0.25);
            circuitIconElement.Style = (Style)Application.Current.FindResource("CircuitStyle");
             Canvas.Children.Add(circuitIconElement);
            Canvas.SetZIndex(circuitIconElement, 1);
            Canvas.MouseMove -= Canvas_MouseMove;
            Canvas.MouseMove += Canvas_MoveLine;
            Canvas.MouseLeftButtonDown += Canvas_LeftButtonCircuit;
            path.Opacity = 0.0;
        }
        private void Cmd_OpenStation(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void Cmd_OpenCircuit(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void Cmd_DeleteCircuit(object sender, ExecutedRoutedEventArgs e)
        {
            CircuitIconElement arriver = (CircuitIconElement)e.OriginalSource;
            LineGeometry geometry = (LineGeometry)arriver.Icon;
            Thickness start = GetThickness(geometry.StartPoint, NoneList);
            Thickness end = GetThickness(geometry.EndPoint, NoneList);
            if (start.Left < end.Left)
            {
                if (start.Top < end.Top)
                {
                    var vpl = NoneListCirc.Where(a => (a.Left >= start.Left) && (a.Left <= end.Left)
                                                  && (a.Top >= start.Top) && (a.Top <= end.Top));
                    YesList.AddRange(vpl);
                    NoneListCirc.RemoveAll(x => vpl.Contains(x));
                }
                else
                {
                    var vpl = NoneListCirc.Where(a => (a.Left >= start.Left) && (a.Left <= end.Left)
                                                 && (a.Top <= start.Top) && (a.Top >= end.Top));
                    YesList.AddRange(vpl);
                    NoneListCirc.RemoveAll(x => vpl.Contains(x));
                }
            }
            else
            {
                if (start.Top < end.Top)
                {
                    var vpl = NoneListCirc.Where(a => (a.Left <= start.Left) && (a.Left >= end.Left)
                                                 && (a.Top >= start.Top) && (a.Top <= end.Top));
                    YesList.AddRange(vpl);
                    NoneListCirc.RemoveAll(x => vpl.Contains(x));
                }
                else
                {
                    var vpl = NoneListCirc.Where(a => (a.Left <= start.Left) && (a.Left >= end.Left)
                                                && (a.Top <= start.Top) && (a.Top >= end.Top));
                    YesList.AddRange(vpl);
                    NoneListCirc.RemoveAll(x => vpl.Contains(x));
                }
            }
            Canvas.Children.Remove(arriver);
            ContextMenuClosed = true;
        }

    }


    public class Commands
    {
        public static RoutedCommand OpenStation { get; set; }
        public static RoutedCommand CreateStation { get; set; }
        public static RoutedCommand DeleteStation { get; set; }
        public static RoutedCommand ConnectStation { get; set; }
        public static RoutedCommand OpenCircuit { get; set; }
        public static RoutedCommand DeleteCircuit { get; set; }

        static Commands()
        {
            Commands.OpenStation = new RoutedCommand("OpenStation", typeof(Commands));
            Commands.CreateStation = new RoutedCommand("CreateStation", typeof(Commands));
            Commands.DeleteStation = new RoutedCommand("DeleteStation", typeof(Commands));
            Commands.ConnectStation = new RoutedCommand("ConnectStation", typeof(Commands));
            Commands.OpenCircuit = new RoutedCommand("OpenCircuit", typeof(Commands));
            Commands.DeleteCircuit = new RoutedCommand("DeleteCircuit", typeof(Commands));
        }
    }
}

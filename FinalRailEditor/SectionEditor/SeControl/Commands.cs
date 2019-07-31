using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FinalRailEditor.SectionEditor.SeControl
{
    public partial class SecEditorControl
    {
        private void Cmd_CreateStation(object sender, ExecutedRoutedEventArgs e)
        {
            StationIconElement iconElement = new StationIconElement();
            EllipseGeometry ellipse = new EllipseGeometry();
            ellipse.RadiusX = 10;
            ellipse.RadiusY = 10;
            Ellipse arriver = (Ellipse)e.OriginalSource;
            double x = Canvas.GetLeft(arriver);
            double y = Canvas.GetTop(arriver);
            ellipse.Center = new Point(x, y);
            iconElement.Icon = ellipse;
            iconElement.Style = (Style)Application.Current.FindResource("IconStyle");
            Canvas.Children.Add(iconElement);


        }
        private void Cmd_DeleteStation(object sender, ExecutedRoutedEventArgs e)
        {
            
        }
        private void Cmd_ConnectStation(object sender, ExecutedRoutedEventArgs e)
        {
        }
    }


    public class Commands
    {
        public static RoutedCommand OpenStation { get; set; }
        public static RoutedCommand CreateStation { get; set; }
        public static RoutedCommand DeleteStation { get; set; }
        public static RoutedCommand ConnectStation { get; set; }
        public static RoutedCommand OpenSchemeSection { get; set; }
        public static RoutedCommand DeleteSchemeSection { get; set; }

        static Commands()
        {
            Commands.OpenStation = new RoutedCommand("OpenStation", typeof(Commands));
            Commands.CreateStation = new RoutedCommand("CreateStation", typeof(Commands));
            Commands.DeleteStation = new RoutedCommand("DeleteStation", typeof(Commands));
            Commands.ConnectStation = new RoutedCommand("ConnectStation", typeof(Commands));
            Commands.OpenSchemeSection = new RoutedCommand("OpenSchemeSection", typeof(Commands));
            Commands.DeleteSchemeSection = new RoutedCommand("DeleteSchemeSection", typeof(Commands));
        }
    }
}

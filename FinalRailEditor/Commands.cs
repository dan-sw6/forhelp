using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows.Shapes;
using System.Windows.Data;
using System;
using System.Windows;
using System.Windows.Controls;
using FinalRailEditor.SectionEditor;

namespace FinalRailEditor
{
    public partial class MainWindow
    {
        private void Cmd_OpenGraphicEditor(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void Cmd_OpenSectionEditor(object sender, ExecutedRoutedEventArgs e)
        {
            SectionEditorWindow sectionEditor = new SectionEditorWindow();
            sectionEditor.Owner = this;
            sectionEditor.Show();
        }
    }

   public class Commands
    {
        public static RoutedCommand OpenGraphicEditor { get; set; }
        public static RoutedCommand OpenSectionEditor { get; set; }

        static Commands()
        {
            //Commands.Open = new RoutedCommand("Open", typeof(Commands));
            //Commands.Create = new RoutedCommand("Create", typeof(Commands));
            Commands.OpenGraphicEditor = new RoutedCommand("OpenGraphicEditor", typeof(Commands));
            Commands.OpenSectionEditor = new RoutedCommand("OpenSectionEditor", typeof(Commands));
        }
    }
}

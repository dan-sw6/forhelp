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
using System.Windows.Shapes;

namespace FinalRailEditor.SectionEditor
{
    /// <summary>
    /// Логика взаимодействия для SectionEditorWindow.xaml
    /// </summary>
    public partial class SectionEditorWindow : Window
    {
        public SectionEditorWindow()
        {
            InitializeComponent();
            controlBorder.LayoutTransform = st;
            controlBorder.MouseDown += new MouseButtonEventHandler(this.Border_MouseCenterButtonDown);
            controlBorder.MouseUp += new MouseButtonEventHandler(this.Border_MouseCenterButtonUp);
            controlBorder.PreviewMouseWheel += new MouseWheelEventHandler(this.Border_PreviewMouseWheel);
            controlBorder.MouseMove += new MouseEventHandler(this.Border_MouseMove);
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
    }
}

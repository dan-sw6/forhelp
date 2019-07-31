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
    /// <summary>
    /// Логика взаимодействия для SecEditorControl.xaml
    /// </summary>
    public partial class SecEditorControl : UserControl
    {
        
        public SecEditorControl()
        {
            InitializeComponent();
            Canvas.MouseMove += Canvas_MouseMove;
            Canvas.SizeChanged += Canvas_SizeChanged;   
        }
 
    }
}

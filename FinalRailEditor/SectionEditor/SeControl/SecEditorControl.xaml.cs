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
using System.Collections.ObjectModel;

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
            this.ContextMenuOpening += SecEditorControl_ContextMenuOpening;
            this.ContextMenuClosing += SecEditorControl_ContextMenuClosing;
        }
        public static readonly DependencyProperty HitListProperty;

        static SecEditorControl()
        {
            HitListProperty = DependencyProperty.Register("HitList", typeof(ObservableCollection<DependencyObject>), typeof(SecEditorControl),
                new PropertyMetadata(null));
        }

        public ObservableCollection<DependencyObject> HitList
        {
            get
            {
                return (ObservableCollection<DependencyObject>)GetValue(HitListProperty);
            }
            set
            {
                SetValue(HitListProperty, value);
            }
        }


        private void SecEditorControl_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            ContextMenuClosed = true;
        }

        private void SecEditorControl_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            ContextMenuClosed = false;
        }
    }
}

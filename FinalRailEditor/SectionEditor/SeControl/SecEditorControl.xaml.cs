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
        const int Step = 20;
        List<Thickness> list;
        Ellipse ellipse;
        public SecEditorControl()
        {
            InitializeComponent();
            Canvas.MouseMove += Canvas_MouseMove;
            Canvas.SizeChanged += Canvas_SizeChanged;   
        }

        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            int row = (int)Canvas.ActualHeight / Step;
            int column = (int)Canvas.ActualWidth / Step;
            list = new List<Thickness>();
            for (int i = 0; i < column-1; i++)
            {
                for (int j = 0; j < row-1; j++)
                {
                    Thickness thickness = new Thickness();
                    thickness.Left = Step / 2 + i*Step;
                    thickness.Top = Step / 2 + j*Step;
                    thickness.Right = Step * (i+1) + Step / 2;
                    thickness.Bottom = Step * (j + 1) + Step / 2;
                    list.Add(thickness);
                }
            }
            ellipse = new Ellipse();
            ellipse.Width = 10;
            ellipse.Height = 10;
            ellipse.Style = Tools.CalculateStyle(ellipse);
            ContextMenu menu = new ContextMenu();
            MenuItem menuItem = new MenuItem();
            menuItem.Header = "Новый раздельный пункт";
            CommandBinding binding = new CommandBinding();
            binding.Command = Commands.CreateStation;
            binding.Executed += Cmd_CreateStation;
            menuItem.CommandBindings.Add(binding);
            menu.Items.Add(menuItem);
            ellipse.ContextMenu = menu;
            Canvas.Children.Add(ellipse);
            Canvas.UpdateLayout();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point pos = e.GetPosition(this);
            var str = list.Where(n => ((n.Left < pos.X) && (n.Right > pos.X) && (n.Top < pos.Y) && (n.Bottom > pos.Y)));
            Thickness ness = str.FirstOrDefault();
            if (str.Count() != 0)
            {
                Canvas.SetLeft(ellipse, ness.Left + Step / 4-0.25);
                Canvas.SetTop(ellipse, ness.Top + Step / 4-0.25);
            }
        }
    }
}

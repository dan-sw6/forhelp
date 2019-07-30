﻿using System;
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
        private void ContolSizeChanged(object sender, SizeChangedEventArgs e)
        {
            int row = (int)Canvas.ActualHeight / Step;
            int column = (int)Canvas.ActualWidth / Step;
            for (int i = 1; i < row; i++)
            {
                for (int j = 1; j < column; j++)
                {
                    Ellipse ellipse = new Ellipse();
                    ellipse.Width = 10;
                    ellipse.Height = 10;
                    Canvas.SetLeft(ellipse, j * Step - 5.25);
                    Canvas.SetTop(ellipse, i * Step - 5.25);
                    Canvas.Children.Add(ellipse);
                }
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
                style.Setters.Add(new Setter(Shape.OpacityProperty, 0.0));
                MultiTrigger mt = new MultiTrigger();
                mt.Conditions.Add(new Condition(Shape.IsMouseOverProperty, true));
                mt.Setters.Add(new Setter(Shape.FillProperty, Brushes.Black));
                mt.Setters.Add(new Setter(Shape.OpacityProperty, 0.8));
                style.Triggers.Add(mt);
                MultiTrigger mt1 = new MultiTrigger();
                mt1.Conditions.Add(new Condition(Shape.ContextMenuProperty, true));
                mt1.Setters.Add(new Setter(Shape.FillProperty, Brushes.Black));
                mt1.Setters.Add(new Setter(Shape.OpacityProperty, 0.8));
                style.Triggers.Add(mt1);


            }
            return style;
        }
    }
}

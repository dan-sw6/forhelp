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
   public class CircuitIconElement:Shape
    {
        public static readonly DependencyProperty IconProperty;
        public static readonly DependencyProperty FeatureProperty;

        static CircuitIconElement()
        {
            IconProperty = DependencyProperty.Register("Icon", typeof(Geometry), typeof(CircuitIconElement),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender), null);
            FeatureProperty = DependencyProperty.Register("Feature", typeof(MainCircuit), typeof(CircuitIconElement),
              new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault), null);

        }

        public MainCircuit Feature
        {
            get
            {
                return (MainCircuit)GetValue(FeatureProperty);
            }
            set
            {
                SetValue(FeatureProperty, value);
            }
        }

        public Geometry Icon
        {
            get
            {
                return (Geometry)GetValue(IconProperty);
            }
            set
            {
                SetValue(IconProperty, value);
            }
        }

        protected override Geometry DefiningGeometry
        {
            get
            {
                Geometry geometry = Icon;
                if (geometry == null)
                {
                    geometry = Geometry.Empty;
                }
                return geometry;
            }
        }

    }
}

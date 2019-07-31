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
    public class StationIconElement : Shape
    {
        public static readonly DependencyProperty IconProperty;
        public static readonly DependencyProperty FeatureProperty;

        static StationIconElement()
        {
            IconProperty = DependencyProperty.Register("Icon", typeof(Geometry), typeof(StationIconElement),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender), null);
            FeatureProperty = DependencyProperty.Register("Feature", typeof(MainStation), typeof(StationIconElement),
              new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault), null);

        }

        public MainStation Feature
        {
            get
            {
                return (MainStation)GetValue(FeatureProperty);
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

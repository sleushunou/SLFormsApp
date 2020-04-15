using SLFormsApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using Softeq.XToolkit.Common.Extensions;

namespace SLFormsApp.UWP.Views
{
    class UWPFlagView : Canvas
    {
        public UWPFlagView()
        {
            Background = new SolidColorBrush(Color.FromArgb(255, 17, 52, 147));
            this.SizeChanged += UWPFlagView_SizeChanged;
        }

        private void UWPFlagView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var starSize = ActualHeight / 10;
            var radius = ActualHeight / 3;
            var count = 12;
            var anglesCount = 5;

            foreach (var star in FlagHelper.GetStars(count, (float)radius, anglesCount, (float)starSize, new Xamarin.Forms.Point(ActualWidth / 2, ActualHeight / 2)))
            {
                var points = new PointCollection();
                star.Select(x => new Windows.Foundation.Point(x.X, x.Y)).Apply(x => points.Add(x));

                var polygon = new Polygon();
                polygon.FillRule = FillRule.Nonzero;
                polygon.Fill = new SolidColorBrush(Color.FromArgb(255, 247, 205, 70));
                polygon.Points = points;

                Children.Add(polygon);
            }
        }
    }
}

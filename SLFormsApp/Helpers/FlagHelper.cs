using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace SLFormsApp.Helpers
{
    public class FlagHelper
    {
        public static IEnumerable<IEnumerable<Point>> GetStars(int starsCount, float radius, int anglesCount, float starSize, Point centerPoint)
        {
            return Enumerable.Range(0, 12)
                .Select(index =>
                {
                    var center = GetStarCenterPoint(index, starsCount, radius, centerPoint);

                    return GetStarPoints(anglesCount, new Rectangle(
                        center.X - starSize / 2,
                        center.Y - starSize / 2,
                        starSize,
                        starSize));
                })
                .ToArray();
        }

        public static IEnumerable<Point> GetStarPoints(int num_points, Rectangle bounds)
        {
            var pts = new Point[num_points];

            double rx = bounds.Width / 2;
            double ry = bounds.Height / 2;
            double cx = bounds.X + rx;
            double cy = bounds.Y + ry;

            // Start at the top.
            double theta = -Math.PI / 2;
            double dtheta = 4 * Math.PI / num_points;
            for (int i = 0; i < num_points; i++)
            {
                pts[i] = new Point(
                    (float)(cx + rx * Math.Cos(theta)),
                    (float)(cy + ry * Math.Sin(theta)));
                theta += dtheta;
            }

            return pts;
        }

        public static Point GetStarCenterPoint(int index, int totalCount, float radius, Point centerPoint)
        {
            var x = centerPoint.X + radius * Math.Cos(2 * Math.PI / totalCount * index);
            var y = centerPoint.Y + radius * Math.Sin(2 * Math.PI / totalCount * index);
            return new Point(x, y);
        }
    }
}

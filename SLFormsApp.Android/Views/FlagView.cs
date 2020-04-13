using System.Linq;
using Android.Content;
using Android.Graphics;
using Android.Views;
using SLFormsApp.Helpers;

namespace SLFormsApp.Droid.Views
{
    public class FlagView : ViewGroup
    {
        private readonly Paint paint;

        public FlagView(Context context) : base(context)
        {
            paint = new Paint();
            paint.SetStyle(Paint.Style.Fill);
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
        }

        protected override void DispatchDraw(Canvas canvas)
        {
            base.DispatchDraw(canvas);

            paint.Color = new Color(17, 52, 147);

            canvas.DrawRect(0, 0, Width, Height, paint);

            var starSize = Height / 10;
            var radius = Height / 3;
            var count = 12;
            var anglesCount = 5;

            paint.Color = Color.Yellow;

            foreach (var star in FlagHelper.GetStars(count, (float)radius, anglesCount, (float)starSize, new Xamarin.Forms.Point(Width / 2, Height / 2)))
            {
                var path = new Path();
                var points = star.Select(point => (X: point.X, Y: point.Y)).ToList();

                for (int i = 0; i < star.Count(); i++)
                {
                    if (i == 0)
                    {
                        path.MoveTo((float)points[i].X, (float)points[i].Y);
                    }
                    else
                    {
                        path.LineTo((float)points[i].X, (float)points[i].Y);
                    }
                }

                path.Close();

                canvas.DrawPath(path, paint);
            }
        }
    }
}

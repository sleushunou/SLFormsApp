using System;
using System.Linq;
using CoreGraphics;
using SLFormsApp.Helpers;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace SLFormsApp.iOS.Views
{
    public class UIFlagView : UIView
    {
        public UIFlagView()
        {
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            BackgroundColor = UIColor.FromRGB(17, 52, 147);
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            var starSize = Bounds.Height / 10;
            var radius = Bounds.Height / 3;
            var count = 12;
            var anglesCount = 5;

            using (CGContext context = UIGraphics.GetCurrentContext())
            {
                UIColor.FromRGB(247, 205, 70).SetFill();

                foreach (var star in FlagHelper.GetStars(count, (float)radius, anglesCount, (float)starSize, Center.ToPoint()))
                {
                    var path = new CGPath();
                    path.AddLines(star.Select(x => x.ToPointF()).ToArray());
                    path.CloseSubpath();
                    context.AddPath(path);
                }
                context.FillPath();
            }
        }
    }
}

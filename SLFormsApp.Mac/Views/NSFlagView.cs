using System;
using System.Linq;
using AppKit;
using CoreGraphics;
using SLFormsApp.Helpers;
using Xamarin.Forms.Platform.MacOS;

namespace SLFormsApp.Mac.Views
{
    public class NSFlagView : NSView
    {
        public NSFlagView()
        {
        }

        public override void Layout()
        {
            base.Layout();
            Layer.BackgroundColor = NSColor.FromRgb(17, 52, 147).CGColor;
        }

        public override void DrawRect(CGRect dirtyRect)
        {
            base.DrawRect(dirtyRect);

            var starSize = Bounds.Height / 10;
            var radius = Bounds.Height / 3;
            var count = 12;
            var anglesCount = 5;

            using (CGContext context = NSGraphicsContext.CurrentContext.CGContext)
            {
                NSColor.FromRgb(247, 205, 70).SetFill();

                foreach (var star in FlagHelper.GetStars(count, (float)radius, anglesCount, (float)starSize, new Xamarin.Forms.Point(Bounds.Width / 2, Bounds.Height / 2)))
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

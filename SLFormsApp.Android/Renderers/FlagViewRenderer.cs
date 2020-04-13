using System;
using Android.Content;
using SLFormsApp.Droid.Renderers;
using SLFormsApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using DroidFlagView = SLFormsApp.Droid.Views.FlagView;

[assembly: ExportRenderer(typeof(FlagView), typeof(FlagViewRenderer))]
namespace SLFormsApp.Droid.Renderers
{
    public class FlagViewRenderer : ViewRenderer<FlagView, DroidFlagView>
    {
        DroidFlagView uiCameraPreview;

        public FlagViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<FlagView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe
            }
            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    uiCameraPreview = new DroidFlagView(Context);
                    SetNativeControl(uiCameraPreview);
                }
                // Subscribe
            }
        }
    }
}

using System;
using SLFormsApp.iOS.Renderers;
using SLFormsApp.iOS.Views;
using SLFormsApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(FlagView), typeof(FlagViewRenderer))]
namespace SLFormsApp.iOS.Renderers
{
    public class FlagViewRenderer : ViewRenderer<FlagView, UIFlagView>
    {
        UIFlagView uiCameraPreview;

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
                    uiCameraPreview = new UIFlagView();
                    SetNativeControl(uiCameraPreview);
                }
                // Subscribe
            }
        }
    }
}

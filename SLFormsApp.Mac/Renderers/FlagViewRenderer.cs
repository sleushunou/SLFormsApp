
using SLFormsApp.Mac.Renderers;
using SLFormsApp.Mac.Views;
using SLFormsApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

[assembly: ExportRenderer(typeof(FlagView), typeof(FlagViewRenderer))]
namespace SLFormsApp.Mac.Renderers
{
    public class FlagViewRenderer : ViewRenderer<FlagView, NSFlagView>
    {
        NSFlagView uiCameraPreview;

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
                    uiCameraPreview = new NSFlagView();
                    SetNativeControl(uiCameraPreview);
                }
                // Subscribe
            }
        }
    }
}

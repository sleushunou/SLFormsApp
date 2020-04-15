using SLFormsApp.UWP.Renderers;
using SLFormsApp.UWP.Views;
using SLFormsApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(FlagView), typeof(FlagViewRenderer))]
namespace SLFormsApp.UWP.Renderers
{
    class FlagViewRenderer : ViewRenderer<FlagView, UWPFlagView>
    {
        UWPFlagView uiCameraPreview;

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
                    uiCameraPreview = new UWPFlagView();
                    SetNativeControl(uiCameraPreview);
                }
                // Subscribe
            }
        }
    }
}

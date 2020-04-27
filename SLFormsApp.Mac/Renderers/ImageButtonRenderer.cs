using System.ComponentModel;
using System.Threading.Tasks;
using AppKit;
using SLFormsApp.Mac.Renderers;
using Softeq.XToolkit.Common.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

[assembly: ExportRenderer(typeof(ImageButton), typeof(ImageButtonRenderer))]
namespace SLFormsApp.Mac.Renderers
{
    public class ImageButtonRenderer : ViewRenderer<ImageButton, NSImageView>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<ImageButton> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				if (Control == null)
				{
					var imageView = new NSImageView();

					imageView.AddGestureRecognizer(new NSClickGestureRecognizer((recognizer) =>
					{
						switch (recognizer.State)
						{
							case NSGestureRecognizerState.Recognized:
								((IButtonController)this.Element).SendClicked();
								break;
						}
					}));

					SetNativeControl(imageView);

					UpdateImage(e.NewElement.Source).SafeTaskWrapper();
				}
			}
		}

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == ImageButton.SourceProperty.PropertyName)
			{
				var imageSource = Element.GetValue(ImageButton.SourceProperty) as ImageSource;
                UpdateImage(imageSource).SafeTaskWrapper();
            }
		}

        private async Task UpdateImage(ImageSource source)
		{
			var imageLoaderSourceHandler = GetHandler(source);

			var image = await imageLoaderSourceHandler.LoadImageAsync(source);

			Control.Image = image;
		}

		private static IImageSourceHandler GetHandler(ImageSource source)
		{
			IImageSourceHandler returnValue = null;
			if (source is UriImageSource)
			{
				returnValue = new ImageLoaderSourceHandler();
			}
			else if (source is FileImageSource)
			{
				returnValue = new FileImageSourceHandler();
			}
			else if (source is StreamImageSource)
			{
				returnValue = new StreamImagesourceHandler();
			}
			return returnValue;
		}
	}
}

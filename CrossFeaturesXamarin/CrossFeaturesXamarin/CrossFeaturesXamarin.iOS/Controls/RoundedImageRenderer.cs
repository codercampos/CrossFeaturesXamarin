using System;
using CrossFeaturesXamarin.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(RoundedImage), typeof(CrossFeaturesXamarin.iOS.Controls.RoundedImageRenderer))]
namespace CrossFeaturesXamarin.iOS.Controls
{
    public class RoundedImageRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null)
                return;
            var control = (RoundedImage)e.NewElement;
            CreateCircle(control.BorderColor, control.BorderWidth);
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == VisualElement.HeightProperty.PropertyName ||
                e.PropertyName == VisualElement.WidthProperty.PropertyName)
            {
                var control = (RoundedImage)sender;
                CreateCircle(control.BorderColor, control.BorderWidth);
            }
        }

        private void CreateCircle(Xamarin.Forms.Color borderColor = new Color(), double borderWidth = 3.0)
        {
            try
            {
                double min = Math.Min(Element.Width, Element.Height);
                Control.Layer.CornerRadius = (float)(min / 2.0);
                Control.Layer.MasksToBounds = false;
                Control.Layer.BorderColor = borderColor.ToCGColor();
                Control.Layer.BorderWidth = (float)borderWidth;
                Control.ClipsToBounds = true;
            }
            catch (Exception)
            {
                //Debug.WriteLine ("Unable to create circle image: " + ex);
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using CrossFeaturesXamarin.Controls;
[assembly:ExportRenderer(typeof(CrossFeaturesXamarin.Controls.RoundedImage), typeof(CrossFeaturesXamarin.Droid.Controls.RoundedImageRenderer))]
namespace CrossFeaturesXamarin.Droid.Controls
{
    public class RoundedImageRenderer : ImageRenderer
    {
        protected override bool DrawChild(Android.Graphics.Canvas canvas, Android.Views.View child, long drawingTime)
        {
            try
            {
                var element = (RoundedImage)Element;
                var radius = Math.Min(Width, Height) / 2;
                var strokeWidth = 10;
                radius -= strokeWidth / 2;
                //Create path to clip
                var path = new Path();
                path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);
                canvas.Save();
                canvas.ClipPath(path);
                var result = base.DrawChild(canvas, child, drawingTime);
                canvas.Restore();
                // Create path for circle border
                path = new Path();
                path.AddCircle(Width / 2, Height / 2, radius, Path.Direction.Ccw);
                var paint = new Paint();
                paint.AntiAlias = true;
                paint.StrokeWidth = (float)element.BorderWidth;
                paint.SetStyle(Paint.Style.Stroke);
                paint.Color = element.BorderColor.ToAndroid();
                canvas.DrawPath(path, paint);
                //Properly dispose
                paint.Dispose();
                path.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                //Why this happend
                Console.WriteLine(ex.Message);
            }
            return base.DrawChild(canvas, child, drawingTime);
        }
    }
}
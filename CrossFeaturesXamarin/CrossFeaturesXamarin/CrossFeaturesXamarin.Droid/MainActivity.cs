using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;

namespace CrossFeaturesXamarin.Droid
{
    [Activity(Label = "CrossFeaturesXamarin", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;
            FormsAppCompatActivity.TabLayoutResource = Resource.Layout.tabs;
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Parse.ParseClient.Initialize("7F5X71CUQ3xbSpYgbs2Xk0dwVi6MBZrQLSKEZj9H", "qLWKCFAoHDusefHOhFRuQVS09h4HubIL4oTHtdgE");
            LoadApplication(new App());

            if ((int)Android.OS.Build.VERSION.SdkInt >= 21)
                Window.SetStatusBarColor(new Color(215, 15, 29));
        }
    }
}


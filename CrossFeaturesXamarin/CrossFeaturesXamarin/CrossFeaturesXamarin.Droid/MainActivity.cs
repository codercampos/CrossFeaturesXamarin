using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace CrossFeaturesXamarin.Droid
{
    [Activity(Label = "CrossFeaturesXamarin", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Parse.ParseClient.Initialize("7F5X71CUQ3xbSpYgbs2Xk0dwVi6MBZrQLSKEZj9H", "qLWKCFAoHDusefHOhFRuQVS09h4HubIL4oTHtdgE");
            LoadApplication(new App());
        }
    }
}


using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using Xamarin.Forms;
using Java.Lang;
using Android.Hardware;
using MovilScanPrices.Utils;

namespace MovilScanPrices.Droid
{
    [Activity(Label = "MovilScanPrices", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]

    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static Activity Instance { get; private set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            this.Window.AddFlags(WindowManagerFlags.Fullscreen);
            this.Window.AddFlags(WindowManagerFlags.NotTouchable);
            this.Window.AddFlags(WindowManagerFlags.KeepScreenOn);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //====================================
            int uiOptions = (int)Window.DecorView.SystemUiVisibility;
            uiOptions |= (int)SystemUiFlags.LowProfile;
            uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.LayoutHideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;
            //====================================
            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
            LoadApplication(new App());
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(false);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}
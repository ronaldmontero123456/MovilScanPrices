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
using Square.Picasso;
using Android.Graphics;
using System.Runtime.Remoting.Contexts;

namespace MovilScanPrices.Droid
{
    [Activity(Label = "MovilScanPrices", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]

    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static Activity Instance { get; private set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
             this.Window.AddFlags(WindowManagerFlags.Fullscreen);
        //    this.Window.AddFlags(WindowManagerFlags.NotTouchable);
            this.Window.AddFlags(WindowManagerFlags.KeepScreenOn);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            ////====================================
            int uiOptions = (int)Window.DecorView.SystemUiVisibility;
            uiOptions |= (int)SystemUiFlags.LowProfile;
            uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.LayoutHideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;
            //====================================
            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(false);

            //SetContentView(Resource.Layout.Main);

            //ImageView ivItem = FindViewById<ImageView>(Resource.Id.ivItem);

            //Picasso.With(this)
            //    .Load("file://laptop-fdvfbv0k/Users/LEGION/Desktop/aransa/1.jpg")
            //    .Fit()
            //    .CenterInside()
            //    .MemoryPolicy(MemoryPolicy.NoCache, MemoryPolicy.NoStore)
            //    .NetworkPolicy(NetworkPolicy.NoCache, NetworkPolicy.NoStore)
            //    .Into(ivItem);


            //Picasso.Get()
            //.Load("file://laptop-fdvfbv0k/Users/LEGION/Desktop/aransa/1.jpg") // Add this
            //.Fit().CenterCrop()
            //.Into(ivItem);
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}
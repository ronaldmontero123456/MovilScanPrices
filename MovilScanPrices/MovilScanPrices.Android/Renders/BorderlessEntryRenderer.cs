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
using MovilScanPrices.Controls;
using MovilScanPrices.Droid.renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderEntry), typeof(BorderlessEntryRenderer))]
namespace MovilScanPrices.Droid.renders
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        public BorderlessEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);
            if(e.OldElement == null)
            {
                //Control.Background = null;
                Control.SetBackgroundColor(Color.Transparent.ToAndroid());
            }
        }
    }
}
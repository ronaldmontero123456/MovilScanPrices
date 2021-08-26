using Java.Util;
using MovilScanPrices.Model;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovilScanPrices.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TarjetaPage : ContentPage
    {
        public static Timer timer { get; set; }
        public TarjetaPage(Tarjeta tarjeta = null)
        {
            InitializeComponent();

            lblnombre.Text = tarjeta.DesCription;
            lblpuntos.Text = Math.Round(tarjeta.TotalPuntos, 2).ToString();


            if (timer == null)
            {
                timer = new Timer();
                timer.Schedule(new MyTimer(timer), 0, 1000);
            }
            else
            {
                MyTimer.i = 0;
            }
        }
    }
}
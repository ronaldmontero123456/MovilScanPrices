using Java.Util;
using MovilScanPrices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovilScanPrices
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public static Timer timer { get; set; }

        public Page1(Products product)
        {
            var precios = product.Precio.ToString("N2").Split('.');

            InitializeComponent();

            lblnombre.Text = product.Description;
            lblprecio.Text = precios[0];
            lblcent.Text = precios[1].Substring(0,2);

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
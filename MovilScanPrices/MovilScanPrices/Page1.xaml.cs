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
            InitializeComponent();
            //imagenProducto.Source = product.proImg;
            lblnombre.Text = product.proDescripcion;
            //lblprecio.Text = product.ProPrecio.ToString("N2");

            if(timer == null)
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
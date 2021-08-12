using MovilScanPrices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovilScanPrices.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TarjetaPage : ContentPage
    {
        public TarjetaPage(Tarjeta tarjeta = null)
        {
            InitializeComponent();

            lblnombre.Text = tarjeta.ContatcNo;
            lblpuntos.Text = tarjeta.TotalPuntos.ToString();
        }
    }
}
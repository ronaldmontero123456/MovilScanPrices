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
    public partial class InitPage : ContentPage
    {
        public InitPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(EntIp.Text))
            {
                await DisplayAlert("Aviso","Debe Introducir La IP","Aceptar");
                return;
            }
            else if(string.IsNullOrEmpty(EntPath.Text))
            {
                await DisplayAlert("Aviso", "Debe Introducir El PATH", "Aceptar");
                return;
            }

            var app = Application.Current;

            app.Properties["IP"] = EntIp.Text;
            app.Properties["PATH"] = EntPath.Text;
            await app.SavePropertiesAsync();

            await Navigation.PushAsync(new MainPage());
        }
    }
}
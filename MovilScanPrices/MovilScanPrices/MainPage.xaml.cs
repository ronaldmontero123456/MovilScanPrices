using MovilScanPrices.Model;
using MovilScanPrices.ViewModel;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MovilScanPrices
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public new event PropertyChangedEventHandler PropertyChanged;

        private string scanproduct;
        public string ScanProduct { get => scanproduct; set { scanproduct = value; RaiseOnPropertyChanged(); } }
        public MainPage()
        {
            MessagingCenter.Subscribe<Object, string>(this, "ParsedSmsReceived",
             async (sender, arg) =>
             {
               await GetProducts(arg); 
             });
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                // Do something
                framename.IsVisible = !framename.IsVisible;
                return true; // True = Repeat again, False = Stop the timer
            });
        }
        public async Task GetProducts(string arg)
        {
            try
            {
                var client = new HttpClient();
                string uri = $"http://movilbusiness.com.do/scanpriceapi/api/scanprice/getproductsbybarcode?barcode={arg}";
                client.BaseAddress = new Uri(uri);
                var response = await client.GetAsync(client.BaseAddress);

                if (!response.IsSuccessStatusCode)
                {
                     await DisplayAlert("Aviso", "no es posible encontrar su producto", "aceptar");
                     return;
                }
                var jsonresult = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Products>(jsonresult);
                await Navigation.PushAsync(new Page1(result), true);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void RaiseOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

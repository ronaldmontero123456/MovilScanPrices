using FFImageLoading;
using FFImageLoading.Forms;
using Java.IO;
using MovilScanPrices.Model;
using MovilScanPrices.Model.Struct;
using MovilScanPrices.ViewModel;
using MovilScanPrices.Views;
using Newtonsoft.Json;
using SharpCifs.Smb;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using console = System.Console;

namespace MovilScanPrices
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public new event PropertyChangedEventHandler PropertyChanged;

        private int Number = 1;
        private int Number1 = 1;

        private bool IsLocal = false;

        private string scanproduct;

        public string ScanProduct { get => scanproduct; set { scanproduct = value; RaiseOnPropertyChanged(); } }

        private bool isvsible;

        public bool IsVisible { get => isvsible; set { isvsible = value; RaiseOnPropertyChanged(); } }
        public MainPage()
        {

            InitializeComponent();      

            imagenProducto.Error += ImagenProducto_Error;

            MessagingCenter.Subscribe<Object, ScanResultArgs>(this, "ParsedSmsReceived",
             async (sender, arg) =>
             {
                 if(arg .Result.Length > 12 
                 || arg.Type == 10)
                 {
                     await GetProducts(arg.Result);
                 }else
                 {
                     await GetTarjeta(arg.Result);
                 }

             });

            BindingContext = this;

            //bool verific = true;
            //while (verific)
            //{
            //    imagenProducto.Source = $"http://192.168.1.233/lhml{NumberTogive}.JPeG";
            //    NumberTogive++;
            //    action = () =>
            //    {
            //        verific = false;
            //        NumberTogive--;
            //    };
            //}


            //imagenProducto.Source = tempFile;

            //imagenProducto.Source = "http://192.168.1.233/lhml1092.JPeG";
            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                if (!framename.IsVisible)
                {

                    //frproductono.IsVisible = false;

                    if (IsLocal)
                    {
                        imagenProducto.Source = $"http://192.168.1.233/{Application.Current.Properties["PATH"]}{Number1}.JPeG";
                        IsLocal = false;
                        Number1++;
                    }
                    else
                    {
                        imagenProducto.Source = $"http://192.168.1.233/AllStore/imagen{Number}.JPeG";
                        IsLocal = true;
                        Number++;
                    }                                        
                }
                // Do something
                framename.IsVisible = !framename.IsVisible;
             
                //magenProducto.Source = 
                return true; // True = Repeat again, False = Stop the timer
            });
        }
        public async Task GetProducts(string arg)
        {
            try
            {
                HttpClient client;

                var httpClientHandler = new HttpClientHandler();

                httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => { return true; };

                client = new HttpClient(httpClientHandler);

                string uri = $"http://{Application.Current.Properties["IP"]}/api/scanPrice/getproductsbybarcode?barcode={arg}";
                client.BaseAddress = new Uri(uri);
                var response = await client.GetAsync(client.BaseAddress);

                string jsonresult;
                Products result;

                if (response.IsSuccessStatusCode)
                {
                    jsonresult = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<Products>(jsonresult);
                }else
                {
                    httpClientHandler = new HttpClientHandler();

                    httpClientHandler.ServerCertificateCustomValidationCallback =
                    (message, cert, chain, errors) => { return true; };

                    client = new HttpClient(httpClientHandler);

                    uri = $"http://192.168.1.234:8043/api/scanPrice/getproductsbybarcode?barcode={arg}";

                    client.BaseAddress = new Uri(uri);

                    response = await client.GetAsync(client.BaseAddress);

                    if (!response.IsSuccessStatusCode)
                    {
                        frproductono.IsVisible = true;
                        Task.Delay(500).Wait();
                        frproductono.IsVisible = false;
                        return;
                    }

                    jsonresult = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<Products>(jsonresult);
                }

                await Navigation.PushAsync(new Page1(result), true);
            }
            catch (Exception ex)
            {
                HttpClient client;

                var httpClientHandler = new HttpClientHandler();

                httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => { return true; };

                client = new HttpClient(httpClientHandler);

                string uri = $"http://192.168.1.234:8043/api/scanPrice/getproductsbybarcode?barcode={arg}";

                client.BaseAddress = new Uri(uri);
                var response = await client.GetAsync(client.BaseAddress);

                string jsonresult;
                Products result;

                if (response.IsSuccessStatusCode)
                {
                    jsonresult = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<Products>(jsonresult);
                    await Navigation.PushAsync(new Page1(result), true);
                }                
                //throw new Exception(ex.Message);
            }
        }

        public async Task GetTarjeta(string arg)
        {
            try
            {
                var httpClientHandler = new HttpClientHandler();

                httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => { return true; };

                HttpClient client = new HttpClient(httpClientHandler);
                string uri = $"http://192.168.1.234:8043/api/scanprice/GetTarjetaByBarCode?tarjcode={arg}";
                client.BaseAddress = new Uri(uri);
                var response = await client.GetAsync(client.BaseAddress);

                if (!response.IsSuccessStatusCode)
                {
                    frproductono.IsVisible = true;
                    Task.Delay(500).Wait();
                    frproductono.IsVisible = false;
                    return;
                }

                var jsonresult = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Tarjeta>(jsonresult);

                await Navigation.PushAsync(new TarjetaPage(result), true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void RaiseOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected override void OnAppearing()
        {
            //await nos();
            base.OnAppearing();
        }

        public async Task nos()
        {
            var key = ImageService.Instance.Config.MD5Helper.MD5("http://192.168.1.233/lhml1092.JeG");
            var imagePath = ImageService.Instance.LoadFile(key).Preload;//Config.DiskCache.ExistsAsync(key);
            //var tempFile = Path.Combine(Path.GetTempPath(), "1.jpg");

            //var path = new Uri("file://laptop-fdvfbv0k/Users/LEGION/Desktop/aransa/1.jpg").LocalPath;


            imagenProducto.Source = "http://192.168.1.233/lhml1092.JPeG";
            if (imagenProducto.InvalidateLayoutAfterLoaded == false)
            {

            }

            //////SharpCifs.Config.SetProperty("jcifs.smb.client.lport", "192.168.0.12");
            //var lan = new SmbFile("smb://laptop-fdvfbv0k/Users/LEGION/Desktop/aransa", "");

            //BufferedReader reader = new BufferedReader(new InputStreamReader(new SmbFileInputStream("smb:http://192.168.1.233/lhml109.JPG")));
            //String line = reader.ReadLine();
            //while (line != null)
            //{
            //    line = reader.ReadLine();
            //}
            ////imagenProducto.Source = "//laptop-fdvfbv0k/Users/LEGION/Desktop/aransa/1.jpg";

            ////var auth1 = new NtlmPasswordAuthentication(null, "", "");
            //var folder = new SmbFile("smb:http://192.168.1.233/");

            //foreach (SmbFile item in folder.ListFiles())
            //{
            //    console.WriteLine(item.GetName());
            //}
            ////Reading File:file://laptop-fdvfbv0k/Users/LEGION/Desktop/aransa/1.jpg
            //var file = new SmbFile("smb://laptop-fdvfbv0k/Users/LEGION/Desktop/aransa", "");
            //using (var readStream = file.GetInputStream())
            //{
            ////    var memStream = new MemoryStream();
            ////    ((Stream)readStream).CopyTo(memStream);

            // //HttpClient webClient = new HttpClient();
            //// string imageUrl = string.Format("http://192.168.1.233/lhml1092.JPeG");
            // var imageBytes = await new HttpClient().GetAsync("http://192.168.1.233/");

            //if (File.Exists(tempFile))
            //{
            //    File.Delete(tempFile);
            //}
            //File.Copy(imagePath, tempFile);

            //await Share.RequestAsync(new ShareFileRequest
            //{
            //    Title = "1",
            //    File = new ShareFile(tempFile)
            //});
        }

        private void ImagenProducto_Error(object sender, FFImageLoading.Forms.CachedImageEvents.ErrorEventArgs e)
        {

            if (IsLocal)
            {
                Number = 1;
            }else
            {
                Number1 = 1;
            }            
            
            //action.Invoke();
        }

        private void ErrorPlaceholder_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovilScanPrices
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            NavigationPage navpage = new NavigationPage(new MainPage());

            MainPage = navpage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

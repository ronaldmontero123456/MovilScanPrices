using MovilScanPrices.Views;
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
            NavigationPage navpage;
            //Current.Properties.Remove("IP");
            //Current.Properties.Remove("PATH");
            //Current.Properties.Remove("PATHURL");
            if (!Current.Properties.ContainsKey("IP"))
            {
                navpage = new NavigationPage(new InitPage());
            }else
            {
                navpage = new NavigationPage(new MainPage());
            }


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

using Java.Util;
using MovilScanPrices.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovilScanPrices
{
    public class MyTimer : TimerTask
    {
        public static Timer mytime;
        public static int i;

        public MyTimer(Timer timer)
        {
            mytime = timer;
        }

        public override void Run()
        {
            if(i < 7)
            {
                i++;
            }
            else
            {
                
                Device.BeginInvokeOnMainThread(
                    async
                    () => 
                    {
                        //App.Current.MainPage.Navigation.RemovePage(App.Current.MainPage.Navigation.NavigationStack[0]);
                        await App.Current.MainPage.Navigation.PopToRootAsync(true); 
                    });
                i = 0;

                if(Page1.timer != null)
                {
                    Page1.timer = null;
                }
                if(TarjetaPage.timer != null)
                {
                    TarjetaPage.timer = null;
                }
                                
                mytime.Cancel();
            }
        }
    }
}

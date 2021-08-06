using Java.Util;
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
            if(i < 5)
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
                Page1.timer = null;
                mytime.Cancel();
            }
        }
    }
}

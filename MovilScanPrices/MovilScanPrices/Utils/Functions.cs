using MovilScanPrices.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MovilScanPrices.Utils
{
    public static class Functions
    {
        public static string AppVersion
        {
            get
            {
                try
                {
                    var info = DependencyService.Get<IAppInfo>();

                    if (info != null)
                    {
                        return info.AppVersion();
                    }

                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }

                return "";
            }
        }
    }
}

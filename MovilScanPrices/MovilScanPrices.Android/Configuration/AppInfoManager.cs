
using Android.Content.PM;
using MovilScanPrices.Abstraction;
using MovilScanPrices.Droid.Configuration;
using System;
using System.Runtime.CompilerServices;

namespace MovilScanPrices.Droid.Configuration
{
    public class AppInfoManager : IAppInfo
    {
        public string AppVersion()
        {
            try
            {
                PackageInfo pInfo = MainActivity.Instance.PackageManager.GetPackageInfo(MainActivity.Instance.PackageName, 0);
                string version = pInfo.VersionName;

                return version;
            }
            catch (PackageManager.NameNotFoundException e)
            {
                Console.Write(e.Message);
            }

            return "";
        }
    }
}
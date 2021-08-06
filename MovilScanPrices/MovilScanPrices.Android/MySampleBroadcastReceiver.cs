using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MovilScanPrices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MovilScanPrices.Droid
{
    [BroadcastReceiver]
    [IntentFilter(new[] { "nlscan.action.SCANNER_RESULT" })]
    public class MySampleBroadcastReceiver : BroadcastReceiver
    {
        public async override void OnReceive(Context context, Intent intent)
        {
            string scanResult_1 = intent.GetStringExtra("SCAN_BARCODE1");
            string scanResult_2 = intent.GetStringExtra("SCAN_BARCODE2");
            int barcodeType = intent.GetIntExtra("SCAN_BARCODE_TYPE", -1);

            string scanStatus = intent.GetStringExtra("SCAN_STATE");

            if (scanResult_1 != null || scanResult_2 != null)
            {
                MessagingCenter.Send<Object, string>(this, "ParsedSmsReceived", scanResult_1);
            }
        }
    }
}
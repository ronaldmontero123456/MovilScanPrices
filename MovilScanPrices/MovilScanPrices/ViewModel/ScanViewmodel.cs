using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace MovilScanPrices.ViewModel
{
    public class ScanViewmodel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string scanproduct;
        public string ScanProduct { get => scanproduct; set { scanproduct = value; RaiseOnPropertyChanged(); } }

        public ScanViewmodel()
        {
        }

        public void ScanTest(string productscan)
        {
            ScanProduct = productscan;
        }
        public void RaiseOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

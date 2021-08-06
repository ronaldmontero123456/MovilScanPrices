using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovilScanPrices
{
    public interface ITimer
    {
        Task GetProducts(string arg);
    }
}

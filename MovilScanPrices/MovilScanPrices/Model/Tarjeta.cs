using System;
using System.Collections.Generic;
using System.Text;

namespace MovilScanPrices.Model
{
    public class Tarjeta
    {
        public string ContatcNo { get; set; }
        public string Cuenta { get; set; }
        public string Cedula { get; set; }
        public string DesCription { get; set; }
        public decimal TotalPuntos { get; set; }
    }
}

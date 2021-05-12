using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jewelrystoreAPI
{
    public class JwelleryCost
    {
        public double GoldPrice { get; set; }
        public double GoldWeight { get; set; }
        public double Discount { get; set; }

        public bool IsFilePrint { get; set; }
        public double TotalPrice { get; set; }
        public User User { get; set; }
    }
}

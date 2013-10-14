using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TroyLeeMVCEF.Models
{
    public class BookingViewModel:BookingOptionModel 
    {
        
        public string timeid { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string birthday { get; set; }
        public string question { get; set; }

    }
}
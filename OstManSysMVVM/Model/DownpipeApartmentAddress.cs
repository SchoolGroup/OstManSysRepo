using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstManSysMVVM.Model
{
    class DownpipeApartmentAddress
    {
        public int ApartmentID { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public int Floor { get; set; }
        public string Side { get; set; }
        public int DownpipeID { get; set; }
        public string Condition { get; set; }
        public DateTime LastChecked { get; set; }
        public string Picture { get; set; }

        public DownpipeApartmentAddress()
        {
            
        }

        public override string ToString()
        {
            return
                $"{DownpipeID}-{Condition}-{LastChecked}-{ApartmentID}-{StreetName}-{StreetNumber}-{Floor}-{Side}-{Picture}";
        }
    }
}


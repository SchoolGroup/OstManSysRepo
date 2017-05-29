using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstManSysMVVM.Model
{
    class Address
    {
        public int AddressID { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public int Floor { get; set; }
        public string Side { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }

        public Address()
        {
            
        }
    }
}

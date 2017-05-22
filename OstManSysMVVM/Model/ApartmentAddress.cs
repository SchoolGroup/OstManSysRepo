using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstManSysMVVM.Model
{
    class ApartmentAddress
    {
        public int ApartmentID { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public int Floor { get; set; }
        public string Side { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
        public int Size { get; set; }
        public int NumberOfRooms { get; set; }
        public double MonthlyRent { get; set; }
        public bool IsRented { get; set; }
        public DateTime LastCheck { get; set; }

        public ApartmentAddress()
        {
            
        }

        public override string ToString()
        {
            return $"{ApartmentID}-{StreetName}-{StreetNumber}-{Floor}-{Side}-{Zipcode}-{City}-{Size}-{NumberOfRooms}-{MonthlyRent}-{IsRented}-{LastCheck}";
        }
    }
}
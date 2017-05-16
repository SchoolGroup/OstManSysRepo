using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstManSysMVVM.Model
{
    public class Apartment
    {
        public int ApartmentID { get; set; }
        public int DownpipeID { get; set; }
        public int WindowID { get; set; }
        public int AddressID { get; set; }
        public int Size { get; set; }
        public int NumberOfRooms { get; set; }
        public decimal MonthlyRent { get; set; }
        public string Condition { get; set; }
        public bool IsRented { get; set; }
        public DateTime LastCheck { get; set; }

        public Apartment()
        {
            
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3} - {4} - {5}", ApartmentID, AddressID, Size, NumberOfRooms, MonthlyRent,
                Condition);
        }
    }
}

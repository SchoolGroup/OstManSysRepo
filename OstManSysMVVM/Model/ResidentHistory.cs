using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstManSysMVVM.Model
{
    class ResidentHistory
    {
        public int ResidentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Type { get; set; }
        public DateTime MoveInDate { get; set; }
        public DateTime? MoveOutDate { get; set; }
        public int ApartmentID { get; set; }

        public ResidentHistory()
        {
            
        }

        public override string ToString()
        {
            return $"{ResidentID}-{FirstName}-{LastName}-{EmailAddress}-{Type}-{MoveInDate}-{MoveOutDate}-{ApartmentID}";
        }
    }
}

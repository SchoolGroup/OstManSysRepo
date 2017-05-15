using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstManSysMVVM.Model
{
    class Resident
    {
        public int ResidentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Type { get; set; }
        public enum Type1 {Resident,BoardMemeber }
        public Resident()
        {
            
        }

        public override string ToString()
        {
            return $"The Resident {FirstName} {LastName}({ResidentID}) has a phone number {PhoneNumber} and email address {EmailAddress}";
        }
    }
}

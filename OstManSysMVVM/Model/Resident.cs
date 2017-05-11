using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstManSysMVVM.Model
{
    public class Resident
    {
        public int ResidentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Type { get; set; }
        public enum Type1 {Resident,BoardMemeber }
        public Resident()
        {
            
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} {2}({3})", ResidentID, FirstName, LastName, Type);
        }
    }
}

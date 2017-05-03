using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstManSysMVVM.Model
{
    class Account
    {
        public int AccountID { get; set; }
        public int ResidentID { get; set; }
        public string Password { get; set; }

        public Account()
        {
            
        }
    }
}

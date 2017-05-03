using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstManSysMVVM.Model
{
    class Contract
    {
        public int ContractID { get; set; }
        public int ResidentID { get; set; }
        public int ApartmentID { get; set; }
        public DateTime MoveInDate { get; set; }
        public DateTime MoveOutDate { get; set; }

        public Contract()
        {
            
        }
    }
}

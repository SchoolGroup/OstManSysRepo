using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstManSysMVVM.Model
{
    public class Problem
    {
        public int ProblemID { get; set; }
        public int ApartmentID { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string  Note { get; set; }

        public Problem()
        {
            
        }
        
        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3}", ProblemID, ApartmentID, Header, Description);
        }
    }
}

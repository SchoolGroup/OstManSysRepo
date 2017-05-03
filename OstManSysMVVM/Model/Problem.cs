using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstManSysMVVM.Model
{
    class Problem
    {
        public int ProblemID { get; set; }
        public int ApartmentID { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }

        public Problem()
        {
            
        }
    }
}

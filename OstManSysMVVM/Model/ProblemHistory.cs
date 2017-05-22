using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstManSysMVVM.View
{
    public class ProblemHistory
    {
        public int ProblemID { get; set; }
        public int ApartmentID { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }

        public ProblemHistory()
        {
            
        }

        public override string ToString()
        {
            return $"{ProblemID}-{ApartmentID}-{Header}-{Description}-{Note}";
        }
    }
}

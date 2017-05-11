using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstManSysMVVM.Model
{
    public class Downpipe
    {
        public string Condition { get; set; }
        public DateTime LastChecked { get; set; }
        public string Picture { get; set; }

        public Downpipe() { }

        public override string ToString()
        {
            return string.Format("Condition: {0};    Last checked: {1}", Condition, LastChecked);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp36
{
    public class Period
    {
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
        
        public Period(string From, string To)
        {
            this.From = TimeSpan.Parse(From);
            this.To = TimeSpan.Parse(To);
        }
    }
}

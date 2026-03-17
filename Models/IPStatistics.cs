using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class IPStatistics
    {
        public string IP { get; set; }
        public int RequestCount { get; set; }
        public double Percentage { get; set; }
        public DateTime FirstSeen { get; set; }
        public DateTime LastSeen { get; set; }
        public bool IsSuspicious => RequestCount > 1000; // Простое правило
    }
}

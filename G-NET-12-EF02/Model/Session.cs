using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_12_EF02.Model
{
    internal class Session
    { 
        public int SessionID { get; set; }

        public string Title { get; set; }

        public DateTime StartTime { get; set; }

        public int Duration { get; set; }
    }
}

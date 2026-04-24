using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET_12_EF02.Model
{
    internal class Event
    {
 
        public int EventID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public DateTime StartDate { get; set; } 
        public DateTime? EndDate { get; set; }
        public int MaxAttendees { get; set; }   

    }
}

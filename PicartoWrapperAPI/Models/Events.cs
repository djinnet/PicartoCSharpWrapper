using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicartoWrapperAPI.Models
{
    public class Events
    {
        public string id { get; set; }
        public Channel channel { get; set; }
        public string category { get; set; }
        public double ticket_price { get; set; }
        public int ticket_limit { get; set; }
        public int tickets_sold { get; set; }
        public bool started { get; set; }
        public bool adult { get; set; }
    }
}

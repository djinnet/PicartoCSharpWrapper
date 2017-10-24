using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicartoWrapperAPI.Models
{
    public class Multistream
    {
        public int user_id { get; set; }
        public string name { get; set; }
        public bool online { get; set; }
        public bool adult { get; set; }
    }
}

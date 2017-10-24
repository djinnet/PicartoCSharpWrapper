using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicartoWrapperAPI.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public int total_channels { get; set; }
        public int online_channels { get; set; }
        public int viewers { get; set; }
    }
}

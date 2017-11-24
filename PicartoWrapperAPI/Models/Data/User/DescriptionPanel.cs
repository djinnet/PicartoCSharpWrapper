using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicartoWrapperAPI.Models
{
    public class DescriptionPanel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public string Image_link { get; set; }
        public string Button_text { get; set; }
        public string Button_link { get; set; }
        public int Position { get; set; }
    }
}

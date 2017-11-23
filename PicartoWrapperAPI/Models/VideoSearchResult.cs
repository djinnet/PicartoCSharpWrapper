using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicartoWrapperAPI.Models
{
    public class VideoSearchResult
    {
        public List<BasicChannelInfo> Channel { get; set; }
        public List<ChannelVideo> Video { get; set; }
    }
}

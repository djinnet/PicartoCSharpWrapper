using System.Collections.Generic;

namespace PicartoWrapperAPI.Models
{
    public class VideoSearchResult
    {
        public List<BasicChannelInfo> Channel { get; set; }
        public List<ChannelVideo> Video { get; set; }
    }
}

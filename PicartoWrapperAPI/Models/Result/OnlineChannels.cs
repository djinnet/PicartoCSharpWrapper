using Newtonsoft.Json;
using System.Collections.Generic;

namespace PicartoWrapperAPI.Models
{
    public class OnlineChannels
    {
        [JsonProperty("OnlineDetails")]
        public List<OnlineDetails> OnlineDetails { get; set; }
    }
}

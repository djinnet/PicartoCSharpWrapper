using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PicartoWrapperAPI.Models
{
    [JsonObject("OnlineDetails")]
    public class OnlineDetails : PicartoResponse
    {

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("multistream")]
        public bool Multistream { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("gaming")]
        public bool Gaming { get; set; }
        
        [JsonProperty("viewers")]
        public long Viewers { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("languages")]
        public List<Language> Languages { get; set; }

    }
}

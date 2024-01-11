using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PicartoWrapperAPI.Enums;
using System;
using System.Collections.Generic;

namespace PicartoWrapperAPI.Models
{

    public class Channel
    {
        public int User_id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public bool Online { get; set; }
        public int Viewers { get; set; }
        public int Viewers_total { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public int Followers { get; set; }
        public int Subscribers { get; set; }
        public bool Adult { get; set; }
        public string Category { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Account_type Account_type { get; set; }


        public bool Commissions { get; set; }
        
        public string Title { get; set; }
        public List<DescriptionPanel> Description_panels { get; set; }

        [JsonProperty("private")]
        public bool Private { get; set; }
        public bool Gaming { get; set; }
        public bool Guest_chat { get; set; }
        public DateTime Last_live { get; set; }
        public List<string> Tags { get; set; }
        public List<Multistream> Multistream { get; set; }
        public List<Language> Languages { get; set; }
    }
}

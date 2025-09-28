using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PicartoWrapperAPI.Enums;
using PicartoWrapperAPI.Models.Data.Channel;
using PicartoWrapperAPI.Models.Data.Languages;
using System;
using System.Collections.Generic;

namespace PicartoWrapperAPI.Models
{
    [JsonObject("OnlineDetails")]
    public class OnlineDetails : PicartoResponse
    {

        [JsonProperty("user_id")]
        public long User_id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("online")]
        public bool Online { get; set; }

        [JsonProperty("viewers")]
        public long Viewers { get; set; }

        [JsonProperty("viewers_total")]
        public int Viewers_total { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnails Thumbnails { get; set; }

        [JsonProperty("followers")]
        public int Followers { get; set; }

        [JsonProperty("subscribes")]
        public int Subscribers { get; set; }

        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("account_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Account_type Account_type { get; set; }

        [JsonProperty("comissions")]
        public bool Commissions { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description_panels")]
        public List<DescriptionPanel> Description_panels { get; set; }

        [JsonProperty("private")]
        public bool Private { get; set; }


        [JsonProperty("gaming")]
        public bool Gaming { get; set; }



        [JsonProperty("guest_chat")]
        public bool Guest_chat { get; set; }

        [JsonProperty("last_live")]
        public DateTime Last_live { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("multistream")]
        public List<ChannelMultistream> Multistream { get; set; }

        [JsonProperty("languages")]
        public List<Language> Languages { get; set; }

    }
}

using Newtonsoft.Json;
namespace PicartoWrapperAPI
{
    public class Thumbnail
    {
        /// <summary>
        /// Web size
        /// </summary>
        [JsonProperty("web", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Web { get; set; }

        /// <summary>
        /// Web HD size
        /// </summary>
        [JsonProperty("web_large", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Web_large { get; set; }

        /// <summary>
        /// Mobile size
        /// </summary>
        [JsonProperty("mobile", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Mobile { get; set; }

        /// <summary>
        /// Tablet size
        /// </summary>
        [JsonProperty("tablet", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Tablet { get; set; }
    }
}

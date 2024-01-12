namespace PicartoWrapperAPI.Models;
public class SearchVideo
{
    [Newtonsoft.Json.JsonProperty("channel", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public SearchChannel Channel { get; set; }

    [Newtonsoft.Json.JsonProperty("video", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public ChannelVideo Video { get; set; }
}

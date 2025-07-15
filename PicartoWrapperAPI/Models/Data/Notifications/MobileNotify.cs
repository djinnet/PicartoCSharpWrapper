namespace PicartoWrapperAPI.Models.Data.Notifications;
public class MobileNotify
{
    /// <summary>
    /// master
    /// </summary>
    [Newtonsoft.Json.JsonProperty("master", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public bool Master { get; set; }

    /// <summary>
    /// live
    /// </summary>
    [Newtonsoft.Json.JsonProperty("live", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public bool Live { get; set; }

    /// <summary>
    /// follow
    /// </summary>
    [Newtonsoft.Json.JsonProperty("follow", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public bool Follow { get; set; }

    /// <summary>
    /// subscribe
    /// </summary>
    [Newtonsoft.Json.JsonProperty("subscribe", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public bool Subscribe { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [Newtonsoft.Json.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}

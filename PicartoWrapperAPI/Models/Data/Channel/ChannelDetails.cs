using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PicartoWrapperAPI.Enums;
using PicartoWrapperAPI.Models.Data.Channel;
using PicartoWrapperAPI.Models.Data.Chat;
using PicartoWrapperAPI.Models.Data.Languages;
using System;
using System.Collections.Generic;

namespace PicartoWrapperAPI.Models;

/// <summary>
/// Detail about a channel
/// </summary>
public class ChannelDetails
{
    /// <summary>
    /// The channel's user ID
    /// </summary>
    public long User_id { get; set; }

    /// <summary>
    /// The name of the channel
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The URI of the user's avatar
    /// </summary>
    public string Avatar { get; set; }

    /// <summary>
    /// The the channel is online
    /// </summary>
    public bool Online { get; set; }

    /// <summary>
    /// The number of current viewers watching this stream (0 if offline)
    /// </summary>
    public long Viewers { get; set; }

    /// <summary>
    /// The total number of viewers this channel has had since the beginnig of time
    /// </summary>
    public long Viewers_total { get; set; }

    /// <summary>
    /// The thumbnail for the channel
    /// </summary>
    public Thumbnails Thumbnail { get; set; }

    /// <summary>
    /// The total number of people following this streamer
    /// </summary>
    public long Followers { get; set; }

    /// <summary>
    /// The total number of people subscribed to this streamer
    /// </summary>
    public long Subscribers { get; set; }

    /// <summary>
    /// If this channel is an adult channel
    /// </summary>
    public bool Adult { get; set; }

    /// <summary>
    /// The name of the category this stream is in
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// The account type of the channel
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public Account_type Account_type { get; set; }

    /// <summary>
    /// If this channel is accepting commissions
    /// </summary>
    public bool Commissions { get; set; }

    /// <summary>
    /// If recordings are enabled and videos are accessible
    /// </summary>
    public bool Recordings { get; set; }

    /// <summary>
    /// The channel's title
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// The channel's panels
    /// </summary>
    public List<DescriptionPanel> Description_panels { get; set; }

    /// <summary>
    /// If this channel is in private mode
    /// </summary>
    public bool Private { get; set; }

    /// <summary>
    /// The message to display if in private mode
    /// </summary>
    public string Private_message { get; set; }

    /// <summary>
    /// If this channel is in game mode
    /// </summary>
    public bool Gaming { get; set; }

    /// <summary>
    /// this channel's chat settings
    /// </summary>
    public ChatSetting Chat_settings { get; set; }


    public DateTime Last_live { get; set; }
    public string Tags { get; set; }
    public List<ChannelMultistream> Multistream { get; set; }
    public List<Language> Languages { get; set; }

    /// <summary>
    /// Whether following or not - only included if provided with a valid bearer token
    /// </summary>
    public bool Following { get; set; }
}

namespace PicartoWrapperAPI.Models.Data.Notifications;
public class GetUserNotification
{
    /// <summary>
    /// type
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// uuid
    /// </summary>
    public string Uuid { get; set; }

    /// <summary>
    /// body
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// channel
    /// </summary>
    public string Channel { get; set; }

    /// <summary>
    /// uri
    /// </summary>
    public string Uri { get; set; }

    /// <summary>
    /// hasIcon
    /// </summary>
    public string HasIcon { get; set; }

    /// <summary>
    /// timestamp
    /// </summary>
    public int Timestamp { get; set; }

    /// <summary>
    /// unread
    /// </summary>
    public bool Unread { get; set; }
}

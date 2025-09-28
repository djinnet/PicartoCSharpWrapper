namespace PicartoWrapperAPI.Models;
public class SearchChannel
{
    /// <summary>
    /// The user id
    /// </summary>
    public long User_id { get; set; }

    /// <summary>
    /// The channel name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The avatar of channel
    /// </summary>
    public string Avatar { get; set; }

    /// <summary>
    /// The status of online
    /// </summary>
    public bool Online { get; set; }
}

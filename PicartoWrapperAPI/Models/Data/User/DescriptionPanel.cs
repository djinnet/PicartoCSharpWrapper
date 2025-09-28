namespace PicartoWrapperAPI.Models;

/// <summary>
/// This channel's description panels
/// </summary>
public partial class DescriptionPanel
{
    /// <summary>
    /// The description panel's body
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// The description panel's body
    /// </summary>
    public string Body { get; set; }

    /// <summary>
    /// The description panel's attached image URL, if it exists
    /// </summary>
    public string Image { get; set; }

    /// <summary>
    /// The attached image's link, if th image is set
    /// </summary>
    public string Image_link { get; set; }

    /// <summary>
    /// The button's url, if enabled (can be an email)
    /// </summary>
    public string Button_text { get; set; }

    /// <summary>
    /// The button's url, if enabled (can be an email)
    /// </summary>
    public string Button_link { get; set; }

    /// <summary>
    /// The attached image's link, if the image is set
    /// </summary>
    public string Position { get; set; }

}

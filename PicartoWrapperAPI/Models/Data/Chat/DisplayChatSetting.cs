namespace PicartoWrapperAPI.Models.Data.Chat;

/// <summary>
/// DisplayChatSetting
/// </summary>
public class DisplayChatSetting
{
    /// <summary>
    /// display_style user id
    /// </summary>
    public int Display_style { get; set; }

    /// <summary>
    /// whispers
    /// </summary>
    public bool Whispers { get; set; }

    /// <summary>
    /// emotes
    /// </summary>
    public bool Emotes { get; set; }

    /// <summary>
    /// sounds
    /// </summary>
    public bool Sounds { get; set; }

    /// <summary>
    /// timestamps
    /// </summary>
    public bool Timestamps { get; set; }
}

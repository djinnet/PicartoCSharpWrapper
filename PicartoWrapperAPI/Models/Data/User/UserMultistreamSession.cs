namespace PicartoWrapperAPI.Models.Data.User;

public partial class UserMultistreamSession
{
    public bool Online { get; set; }

    public UserGeneric Host { get; set; }

    public UserGeneric Guests { get; set; }
}

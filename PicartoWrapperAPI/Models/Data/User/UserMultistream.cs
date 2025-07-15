namespace PicartoWrapperAPI.Models.Data.User;
public class UserMultistream
{
   public UserGenerics Incoming { get; set; }

   
    public UserGenerics Outgoing { get; set; }

    public UserMultistreamSession Session { get; set; }
}

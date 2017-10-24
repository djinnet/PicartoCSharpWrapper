
namespace PicartoWrapperAPI.Enums
{
    public enum ChannelState
    {
        Channel_exist, //if there returns a jsonObject
        Invalid_path, //if you used letter instead of numbers
        Invalid_channel_id, //if it's a invalid channel_id
        Channel_does_not_exist //if user do not exists
    }
}

namespace PicartoWrapperAPI.Models
{
    public class UserFollowing
    {
        public int user_id { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public bool online { get; set; }
        public bool subscriber { get; set; }
        public bool subscribe_can_expire { get; set; }
        public string subscriber_expires { get; set; }
    }
}

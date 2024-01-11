using System.Collections.Generic;

namespace PicartoWrapperAPI.Models
{
    public class UserData
    {
        public OnlineDetails Channel_details { get; set; }
        public string Email { get; set; }
        public string Creation_date { get; set; }
        public string Private_key { get; set; }
        public int FollowersCount { get { return Followers.Count; } }
        public List<BasicChannelInfo> Followers { get; set; }
        public List<BasicChannelInfo> Following { get; set; }
        public List<BasicChannelInfo> Subscriptions { get; set; }
    }
}
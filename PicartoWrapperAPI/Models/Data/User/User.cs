using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicartoWrapperAPI.Models
{
    public class User
    {
        public Channel channel_details { get; set; }
        public string email { get; set; }
        public string creation_date { get; set; }
        public string private_key { get; set; }
        public List<Following> following { get; set; }
        public List<Subscription> subscriptions { get; set; }
    }
}

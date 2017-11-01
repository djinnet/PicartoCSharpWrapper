using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PicartoWrapperAPI.Enums;

namespace PicartoWrapperAPI.Models
{

    public class Channel
    {
        public int user_id { get; set; }
        public string name { get; set; }
        public bool online { get; set; }
        public int viewers { get; set; }
        public int viewers_total { get; set; }
        public int followers { get; set; }
        public int subscribers { get; set; }
        public bool adult { get; set; }
        public string category { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Account_type account_type { get; set; }


        public bool commissions { get; set; }
        
        public string title { get; set; }
        public List<DescriptionPanel> description_panels { get; set; }
        public bool @private { get; set; }
        public bool gaming { get; set; }
        public bool guest_chat { get; set; }
        public DateTime last_live { get; set; }
        public List<string> tags { get; set; }
        public List<string> languages { get; set; }
        public List<Multistream> multistream { get; set; }
    }
}

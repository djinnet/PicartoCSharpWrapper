using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicartoWrapperAPI.Enums;

namespace PicartoWrapperAPI.Models
{
    public class ChannelVideo
    {
        public string Title { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public string File { get; set; }
        public long Filesize { get; set; }
        public int Duration { get; set; }
        public int Views { get; set; }
        public DateTime Timestamp { get; set; }
        public bool Adult { get; set; }
    }
}

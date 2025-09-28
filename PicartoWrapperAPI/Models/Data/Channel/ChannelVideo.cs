
namespace PicartoWrapperAPI.Models
{
    /// <summary>
    /// Details of a video
    /// </summary>
    public class ChannelVideo
    {
        /// <summary>
        /// The video title
        /// </summary>
        public string Title { get; set; }


        //public Thumbnail Thumbnail { get; set; }

        /// <summary>
        /// The location of the file
        /// </summary>
        public string File { get; set; }

        /// <summary>
        /// Size (in bytes) of the video file
        /// </summary>
        public long Filesize { get; set; }

        /// <summary>
        /// Duration (in seconds) of the video
        /// </summary>
        public long Duration { get; set; }

        /// <summary>
        /// The total number of views this video has
        /// </summary>
        public long Views { get; set; }

        public string Timestamp { get; set; }

        /// <summary>
        /// If this video is adult
        /// </summary>
        public bool Adult { get; set; }
    }
}

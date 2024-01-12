namespace PicartoWrapperAPI.Models
{
    public class Category
    {
        /// <summary>
        /// The category ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The category name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The total number of channels that are this category
        /// </summary>
        public long Total_channels { get; set; }

        /// <summary>
        /// The number of channels that are live using this category
        /// </summary>
        public long Online_channels { get; set; }

        /// <summary>
        /// The total number of viewers
        /// </summary>
        public long Viewers { get; set; }

        /// <summary>
        /// If the category is an adult category
        /// </summary>
        public bool Adult { get; set; }
    }
}

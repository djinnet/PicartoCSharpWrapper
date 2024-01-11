namespace PicartoWrapperAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Total_channels { get; set; }
        public int Online_channels { get; set; }
        public int Viewers { get; set; }
        public bool Adult { get; set; }
    }
}

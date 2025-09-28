namespace PicartoWrapperAPI.Models
{
    public class Event
    {
        public string Id { get; set; }
        public BasicChannelInfo Channel_details { get; set; }
        public string Category { get; set; }
        public double Ticket_price { get; set; }
        public int Ticket_limit { get; set; }
        public int Tickets_sold { get; set; }
        public bool Started { get; set; }
        public bool Adult { get; set; }
    }
}

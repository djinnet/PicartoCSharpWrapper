namespace PicartoWrapperAPI.Models;
public class StreamBody
{
  public StreamChannel Channel { get; set; }
  public bool Show_ads { get; set; }
  public string Url { get; set; }
}

public class StreamChannel
{
    public string Avatar { get; set; }
    public string Stream_name { get; set; }
    public string Name { get; set; }
    public bool Online { get; set; }
    public long User_id { get; set; }
    public bool Adult { get; set; }
    public string Offline_image { get; set; }
}

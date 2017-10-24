using RestSharp;

namespace PicartoWrapperAPI
{
    public interface IPicartoClient
    {
        RestRequest GetRequest(string url, Method method);
    }
}

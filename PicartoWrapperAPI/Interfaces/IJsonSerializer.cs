using RestSharp.Deserializers;
using RestSharp.Serializers;
namespace PicartoWrapperAPI.Interfaces
{
    public interface IJsonSerializer : ISerializer, IDeserializer
    {
    }
}

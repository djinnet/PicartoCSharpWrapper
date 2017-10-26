using RestSharp;
using PicartoWrapperAPI.Enums;
using PicartoWrapperAPI.Helpers;
using PicartoWrapperAPI.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PicartoWrapperAPI.Clients
{
    public class PicartoReadOnlyClient : IPicartoClient
    {
        public readonly RestClient restClient;
        public string Clientname;
        public int ClientID;

        public PicartoReadOnlyClient(string clientname, string url = PicartoHelper.picartoApiUrl)
        {
            Clientname = clientname;
            restClient = new RestClient(url);
            restClient.AddHandler("application/json", PicartoJsonDeserializer.Default);
            restClient.AddHandler("text/json", PicartoJsonDeserializer.Default);
            restClient.AddHandler("text/x-json", PicartoJsonDeserializer.Default);
            restClient.AddHandler("text/javascript", PicartoJsonDeserializer.Default);
            restClient.AddHandler("*+json", PicartoJsonDeserializer.Default);
            restClient.AddHandler("text/html", PicartoJsonDeserializer.Default);
            restClient.AddDefaultHeader("Client-name", clientname);

        }

        public Channel GetNameChannel(string name)
        {
            var request = GetRequest("channel/name/{name}", Method.GET);
            request.AddUrlSegment("name", name);
            var response = restClient.Execute<Channel>(request);
            return response.Data;
        }

        public Channel GetIDChannel()
        {
            int id = ClientID;
            var request = GetRequest("channel/id/{id}", Method.GET);
            request.AddUrlSegment("id", id.ToString());
            var response = restClient.Execute<Channel>(request);
            return response.Data;
        }

        public Channel GetIDChannel(int ID)
        {
            var request = GetRequest("channel/id/{ID}", Method.GET);
            request.AddUrlSegment("ID", ID.ToString());
            var response = restClient.Execute<Channel>(request);
            return response.Data;
        }

        public Channel GetNameChannel()
        {
            string name = Clientname;
            var request = GetRequest("channel/name/{name}", Method.GET);
            request.AddUrlSegment("name", name);
            var response = restClient.Execute<Channel>(request);
            return response.Data;
        }

        public string GetAccountType()
        {
            string name = Clientname;
            var request = GetRequest("channel/name/{name}", Method.GET);
            request.AddUrlSegment("name", name);
            var response = restClient.Execute<Channel>(request);
            return response.Data.account_type;
        }

        public bool Live()
        {
            string name = Clientname;
            var request = GetRequest("channel/name/{name}", Method.GET);
            request.AddUrlSegment("name", name);
            var response = restClient.Execute<Channel>(request);
            return response.Data.online;
        }

        public string GetChannelTitle()
        {
            string name = Clientname;
            var request = GetRequest("channel/name/{name}", Method.GET);
            request.AddUrlSegment("name", name);
            var response = restClient.Execute<Channel>(request);
            return response.Data.title;
        }

        public string GetUserImage(string name)
        {
            name = name.ToLower();
            return $"https://picarto.tv/user_data/usrimg/{name}/dsdefault.jpg";
        }

        public List<OnlineDetails> GetOnlineChannels()
        {
            var request = GetRequest("online", Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = restClient.Execute<List<OnlineDetails>>(request);
            return response.Data;
        }

        public List<Category> GetOnlineCategories()
        {
            var request = GetRequest("categories", Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = restClient.Execute<List<Category>>(request);
            return response.Data;
        }

        public List<Events> GetOnlineEvents()
        {
            var request = GetRequest("events", Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = restClient.Execute<List<Events>>(request);
            return response.Data;
        }


        public RestRequest GetRequest(string url, Method method)
        {
            return new RestRequest(url, method);
        }

        public static List<T> Deserialize<T>(IRestResponse response)
        {
            var content = JsonConvert.DeserializeObject<List<T>>(response.Content);
            return content;
        }
    }
}

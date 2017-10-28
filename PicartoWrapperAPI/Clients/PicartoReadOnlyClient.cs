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

        /// <summary>
        /// Picarto read only name based.
        /// </summary>
        /// <param name="clientname"></param>
        /// <param name="url"></param>
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

        /// <summary>
        /// Picarto read only ID based.
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="url"></param>
        public PicartoReadOnlyClient(int ID, string url = PicartoHelper.picartoApiUrl)
        {
            ClientID = ID;
            restClient = new RestClient(url);
            restClient.AddHandler("application/json", PicartoJsonDeserializer.Default);
            restClient.AddHandler("text/json", PicartoJsonDeserializer.Default);
            restClient.AddHandler("text/x-json", PicartoJsonDeserializer.Default);
            restClient.AddHandler("text/javascript", PicartoJsonDeserializer.Default);
            restClient.AddHandler("*+json", PicartoJsonDeserializer.Default);
            restClient.AddHandler("text/html", PicartoJsonDeserializer.Default);
            restClient.AddDefaultHeader("Client-ID", ID.ToString());

        }

        
        

        /// <summary>
        /// Get Channel based on ID from input
        /// </summary>
        /// <param name="ID">input</param>
        /// <returns>channel</returns>
        public Channel GetIDChannel(int? ID)
        {
            if (ID == null)
            {
                ID = ClientID;
            }

            var request = GetRequest("channel/id/{ID}", Method.GET);
            request.AddUrlSegment("ID", ID.ToString());
            var response = restClient.Execute<Channel>(request);
            return response.Data;
        }

        /// <summary>
        /// Get Channel based on name from input
        /// </summary>
        /// <returns>Channel</returns>
        public Channel GetNameChannel(string name = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                name = Clientname;
            }

            var request = GetRequest("channel/name/{name}", Method.GET);
            request.AddUrlSegment("name", name);
            var response = restClient.Execute<Channel>(request);
            return response.Data;
        }

        /// <summary>
        /// Get Account type from channel based on picarto read only name.
        /// </summary>
        /// <returns>Account_type</returns>
        public string GetAccountType()
        {
            string name = Clientname;
            var request = GetRequest("channel/name/{name}", Method.GET);
            request.AddUrlSegment("name", name);
            var response = restClient.Execute<Channel>(request);
            return response.Data.account_type;
        }


        /// <summary>
        /// Is channel Online
        /// </summary>
        /// <returns></returns>
        public bool Live(string name = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                name = Clientname;
            }
            
            var request = GetRequest("channel/name/{name}", Method.GET);
            request.AddUrlSegment("name", name);
            var response = restClient.Execute<Channel>(request);
            return response.Data.online;
        }

        /// <summary>
        /// Get Channel title 
        /// </summary>
        /// <returns>Title of the channel</returns>
        public string GetChannelTitle(string name = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                name = Clientname;
            }

            var request = GetRequest("channel/name/{name}", Method.GET);
            request.AddUrlSegment("name", name);
            var response = restClient.Execute<Channel>(request);
            return response.Data.title;
        }

        /// <summary>
        /// Get User's image as an url
        /// Useful for discord bot programming
        /// </summary>
        /// <param name="name">username</param>
        /// <returns>url of the user's image</returns>
        public string GetUserImage(string name)
        {
            name = name.ToLower();
            var url = $"https://picarto.tv/user_data/usrimg/{name}/dsdefault.jpg";
            return url;
        }



        //remember to update in the future.
        public List<string> GetChannelLanguages()
        {
            string name = Clientname;
            var request = GetRequest("channel/name/{name}", Method.GET);
            request.AddUrlSegment("name", name);
            var response = restClient.Execute<Channel>(request);
            return response.Data.languages;
        }

        /// <summary>
        /// Get an list over those who are online right now on Picarto
        /// </summary>
        /// <returns>list of online channels</returns>
        public List<OnlineDetails> GetOnlineChannels()
        {
            var request = GetRequest("online", Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = restClient.Execute<List<OnlineDetails>>(request);
            return response.Data;
        }

        /// <summary>
        /// Return a url that send a request to popout a chat based on input.
        /// </summary>
        /// <param name="name">input</param>
        /// <returns>url to the chat</returns>
        public string GetPopOutChat(string name)
        {
            //TO-DO: Add url in here.
            return name;
        }

        /// <summary>
        /// Get Online catagories
        /// </summary>
        /// <returns>list over online catagories</returns>
        public List<Category> GetOnlineCategories()
        {
            var request = GetRequest("categories", Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = restClient.Execute<List<Category>>(request);
            return response.Data;
        }

        /// <summary>
        /// get Online events
        /// </summary>
        /// <returns>list over online events</returns>
        public List<Events> GetOnlineEvents()
        {
            var request = GetRequest("events", Method.GET);
            request.RequestFormat = DataFormat.Json;
            var response = restClient.Execute<List<Events>>(request);
            return response.Data;
        }

        /// <summary>
        /// Fetch an request 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <returns>Restrequest variable</returns>
        public RestRequest GetRequest(string url, Method method)
        {
            return new RestRequest(url, method);
        }
    }
}

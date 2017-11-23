using RestSharp;
using PicartoWrapperAPI.Enums;
using PicartoWrapperAPI.Helpers;
using PicartoWrapperAPI.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

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
        public PicartoReadOnlyClient(string clientname = null, string url = PicartoHelper.picartoApiUrl)
        {
            if (!String.IsNullOrEmpty(clientname))
            {
                Clientname = clientname;
            }

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
        public Channel GetIDChannel(Nullable<int> ID = null)
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
                if (string.IsNullOrEmpty(Clientname))
                {
                    throw new Exception("Clientname don't exist or it's empty!");
                }
                //if name is empty, check if there are Clientname
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
        public Account_type GetAccountType(string name = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                if (string.IsNullOrEmpty(Clientname))
                {
                    throw new Exception("Clientname don't exist or it's empty!");
                }
                //if name is empty, check if there are Clientname
                name = Clientname;
            }
            var request = GetRequest("channel/name/{name}", Method.GET);
            request.AddUrlSegment("name", name);
            var response = restClient.Execute<Channel>(request);
            return response.Data.Account_type;
        }


        /// <summary>
        /// Is channel Online
        /// </summary>
        /// <returns></returns>
        public bool Live(string name = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                if (string.IsNullOrEmpty(Clientname))
                {
                    throw new Exception("Clientname don't exist or it's empty!");
                }
                name = Clientname;
            }
            
            var request = GetRequest("channel/name/{name}", Method.GET);
            request.AddUrlSegment("name", name);
            var response = restClient.Execute<Channel>(request);
            return response.Data.Online;
        }

        /// <summary>
        /// Get Channel title 
        /// </summary>
        /// <returns>Title of the channel</returns>
        public string GetChannelTitle(string name = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                if (string.IsNullOrEmpty(Clientname))
                {
                    throw new Exception("Clientname don't exist or it's empty!");
                }
                name = Clientname;
            }

            var request = GetRequest("channel/name/{name}", Method.GET);
            request.AddUrlSegment("name", name);
            var response = restClient.Execute<Channel>(request);
            return response.Data.Title;
        }

        /// <summary>
        /// Get Channel video
        /// </summary>
        /// <returns>videos of the channel</returns>
        public ChannelVideo GetChannelNameVideos(string name = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                if (string.IsNullOrEmpty(Clientname))
                {
                    throw new Exception("Clientname don't exist or it's empty!");
                }
                name = Clientname;
            }

            var request = GetRequest("channel/name/{name}/videos", Method.GET);
            request.AddUrlSegment("name", name);
            var response = restClient.Execute<ChannelVideo>(request);
            return response.Data;
        }

        /// <summary>
        /// Get Channel video
        /// </summary>
        /// <returns>videos of the channel</returns>
        public ChannelVideo GetChannelIDVideos(int? ID)
        {
            if (ID.HasValue)
            {
                ID = ClientID;
            }

            var request = GetRequest("channel/id/{id}/videos", Method.GET);
            request.AddUrlSegment("id", ID.Value.ToString());
            var response = restClient.Execute<ChannelVideo>(request);
            return response.Data;
        }

        //todo: update to API 1.2.3
        /// <summary>
        /// Get User's image as an url
        /// Useful for discord bot programming
        /// </summary>
        /// <param name="name">username</param>
        /// <returns>url of the user's image</returns>
        public string GetUserImage(string name = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                if (string.IsNullOrEmpty(Clientname))
                {
                    throw new Exception("Clientname don't exist or it's empty!");
                }
                //if name is empty, check if there are Clientname
                name = Clientname;
                name = name.ToLower();
            }
            
            var url = $"https://picarto.tv/user_data/usrimg/{name}/dsdefault.jpg";
            return url;
        }


        //todo: CHECK FOR THE UPDATE - remember to update in the future.
        public List<Language> GetChannelLanguages(string name = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                if (string.IsNullOrEmpty(Clientname))
                {
                    throw new Exception("Clientname don't exist or it's empty!");
                }
                //if name is empty, check if there are Clientname
                name = Clientname;
                }
            var request = GetRequest("channel/name/{name}", Method.GET);
            request.AddUrlSegment("name", name);
            var response = restClient.Execute<Channel>(request);
            return response.Data.Languages;
        }

        /// <summary>
        /// Get an list over those who are online right now on Picarto
        /// </summary>
        /// <param name="adult">adult is false in default</param>
        /// <param name="gaming">gaming is false in default</param>
        /// <param name="category">category is empty in default</param>
        /// <returns>a list over online channels</returns>
        public List<OnlineDetails> GetOnlineChannels(bool adult = false, bool gaming = false, string category = null)
        {
            var request = GetRequest("online?adult={adult}&gaming={gaming}&categories={strings}", Method.GET);
            request.AddUrlSegment("adult", adult.ToString());
            request.AddUrlSegment("gaming", gaming.ToString());
            if (string.IsNullOrEmpty(category))
            {
                category = "";
                request.AddUrlSegment("strings", category);
            }
            else
            {
                request.AddUrlSegment("strings", category);
            }
            
            request.RequestFormat = DataFormat.Json;
            var response = restClient.Execute<List<OnlineDetails>>(request);
            return response.Data;
        }

        //todo: Popout chat
        /// <summary>
        /// Return a url that send a request to popout a chat based on input.
        /// </summary>
        /// <param name="name">input</param>
        /// <returns>url to the chat</returns>
        public string GetPopOutChat(string name = null)
        {
            //todo: Add url in here.
            if (string.IsNullOrWhiteSpace(name))
            {
                if (string.IsNullOrEmpty(Clientname))
                {
                    throw new Exception("Clientname don't exist or it's empty!");
                }
                //if name is empty, check if there are Clientname
                name = Clientname;
                
            }
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

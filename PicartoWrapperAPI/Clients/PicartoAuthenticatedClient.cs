using System;
using RestSharp;
using PicartoWrapperAPI.Enums;
using PicartoWrapperAPI.Helpers;
using PicartoWrapperAPI.Models;

namespace PicartoWrapperAPI.Clients
{
    //todo: Remember to test if this client works.
    public class PicartoAuthenticatedClient : PicartoReadOnlyClient, IPicartoClient
    {
        private readonly string username;
        public PicartoAuthenticatedClient(string clientId, string oauth) : base(clientId)
        {
            restClient.AddDefaultHeader("Authorization", String.Format("OAuth {0}", oauth));

            var user = this.GetMyUser();
            if (user == null || String.IsNullOrWhiteSpace(user.Channel_details.Name)){
                throw new PicartoExeption("Couldn't get the user name!");
            }
            this.username = user.Channel_details.Name;
        }


        public UserData GetMyUser()
        {
            var request = GetRequest("user", Method.GET);
            var response = restClient.Execute<UserData>(request);
            return response.Data;
        }

        public BasicChannelInfo GetFollowing()
        {
            var request = GetRequest("user/following", Method.GET);
            var response = restClient.Execute<BasicChannelInfo>(request);
            return response.Data;
        }

        public string GetStreamkey()
        {
            var request = GetRequest("user/streamkey", Method.GET);
            var response = restClient.Execute<Streamkey>(request);
            return response.Data.StreamkeyToken;
        }

        public string GetBotJWTtoken()
        {
            var request = GetRequest("user/following", Method.GET);
            var response = restClient.Execute<Bot>(request);
            return response.Data.Jwtkey;
        }

        public string PostTitle(string newtitle = null)
        {
            if (String.IsNullOrEmpty(newtitle))
            {
                throw new Exception(newtitle + " cannot be null or empty!");
            }

            var request = GetRequest("user/title", Method.GET);
            var response = restClient.Execute<Channel>(request);
            return response.Data.Title;
        }

        public string PostCategory (Nullable<long> category_id)
        {
            if (category_id == null)
            {
                throw new Exception(category_id + " cannot be null or empty!");
            }

            var request = GetRequest("user/category", Method.GET);
            var response = restClient.Execute<Channel>(request);
            return response.Data.Category;
        }

        public bool PostAdult (Nullable<bool> adultBool)
        {
            if (adultBool == null)
            {
                throw new Exception(adultBool + " cannot be null or empty!");
            }

            var request = GetRequest("user/adult", Method.GET);
            var response = restClient.Execute<Channel>(request);
            return response.Data.Adult;
        }

    }
}

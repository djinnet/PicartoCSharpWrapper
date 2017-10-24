using System;
using RestSharp;
using PicartoWrapperAPI.Enums;
using PicartoWrapperAPI.Helpers;
using PicartoWrapperAPI.Models;

namespace PicartoWrapperAPI.Clients
{
    public class PicartoAuthenticatedClient : PicartoReadOnlyClient, IPicartoClient
    {
        private readonly string username;
        public PicartoAuthenticatedClient(string clientId, string oauth) : base(clientId)
        {
            restClient.AddDefaultHeader("Authorization", String.Format("OAuth {0}", oauth));

            var user = this.GetMyUser();
            if (user == null || String.IsNullOrWhiteSpace(user.channel_details.name)){
                throw new PicartoExeption("Couldn't get the user name!");
            }
            this.username = user.channel_details.name;
        }



        public User GetMyUser()
        {
            var request = GetRequest("user", Method.GET);
            var response = restClient.Execute<User>(request);
            return response.Data;
        }
    }
}

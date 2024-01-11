using System;
using PicartoWrapperAPI.Models;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PicartoWrapperAPI.Clients
{
    //todo: rework this so this can be used in the test project
    public class PicartoAuthenticatedClient : PicartoReadOnlyClient, IPicartoClient
    {
        public PicartoAuthenticatedClient(string clientId, string token) : base(clientId)
        {
            Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Authorization", String.Format("Bearer {0}", token));
            
        }

        public async Task<UserData> GetMyUserAsync()
        {
            return await Client.GetFromJsonAsync<UserData>($"user");
        }

        public async Task<List<Channel>> GetFollowingAsync()
        {
            return await Client.GetFromJsonAsync<List<Channel>>($"user/following");
        }

        public async Task<string> GetStreamkeyAsync()
        {
            return (await Client.GetFromJsonAsync<Streamkey>($"user/streamkey")).StreamkeyToken;
        }
    }
}
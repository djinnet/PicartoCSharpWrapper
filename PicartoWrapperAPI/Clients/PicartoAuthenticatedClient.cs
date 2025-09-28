using PicartoWrapperAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PicartoWrapperAPI.Clients
{
    //todo: rework this so this can be used in the test project
    public class PicartoAuthenticatedClient : PicartoReadOnlyClient
    {
        public PicartoAuthenticatedClient(string clientId, string token) : base(token)
        {
        }

        public async Task<UserData> GetMyUserAsync()
        {
            return await GetAsync<UserData>($"user");
        }

        public async Task<List<ChannelDetails>> GetFollowingAsync()
        {
            return await GetAsync<List<ChannelDetails>>($"user/following");
        }

        public async Task<string> GetStreamkeyAsync()
        {
            return (await GetAsync<Streamkey>($"user/streamkey")).StreamkeyToken;
        }
    }
}
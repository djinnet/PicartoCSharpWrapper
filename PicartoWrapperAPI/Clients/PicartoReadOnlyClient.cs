using PicartoWrapperAPI.Enums;
using PicartoWrapperAPI.Helpers;
using PicartoWrapperAPI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PicartoWrapperAPI.Clients
{
    public class PicartoReadOnlyClient : IPicartoClient
    {

        public readonly HttpClient Client = new();
        public string Clientname;
        public int ClientID;

        /// <summary>
        /// Picarto read only name based.
        /// </summary>
        /// <param name="clientname"></param>
        /// <param name="url"></param>
        public PicartoReadOnlyClient(string clientname = null, string url = PicartoHelper.picartoApiUrl)
        {
            if (string.IsNullOrEmpty(clientname))
            {
                throw new Exception("Clientname don't exist or it's empty!");
            }
            else
            {
                Clientname = clientname;
            }
            Client = new()
            {
                BaseAddress = new Uri(url)
            };
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/json"));
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/x-json"));
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/javascript"));
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*+json"));
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            Client.DefaultRequestHeaders.Add("Client-name", clientname);
        }

        /// <summary>
        /// Picarto read only ID based.
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="url"></param>
        public PicartoReadOnlyClient(Nullable<int> ID = null, string url = PicartoHelper.picartoApiUrl)
        {
            if (ID == null)
            {
                throw new Exception("ClientID don't exist or it's empty!");
            }
            else
            {
                ClientID = ID.Value;
            }
            Client = new()
            {
                BaseAddress = new Uri(url)
            };
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/json"));
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/x-json"));
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/javascript"));
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*+json"));
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
            Client.DefaultRequestHeaders.Add("Client-ID", ID.ToString());

        }

        
        

        /// <summary>
        /// Get Channel based on ID from input
        /// </summary>
        /// <param name="ID">input</param>
        /// <returns>channel</returns>
        public async Task<Channel> GetIDChannelAsync(int? ID = null)
        {
            ID ??= ClientID;
            return await Client.GetFromJsonAsync<Channel>($"channel/id/{ID}");
        }


        /// <summary>
        /// Get Channel based on name from input
        /// </summary>
        /// <returns>Channel</returns>
        public async Task<Channel> GetNameChannelAsync(string name = null)
        {
            name = CheckEmptyName(name);
            return await Client.GetFromJsonAsync<Channel>($"channel/name/{name}");
        }



        /// <summary>
        /// Get Account type from channel based on picarto read only name.
        /// </summary>
        /// <returns>Account_type</returns>
        public async Task<Account_type> GetAccountTypeAsync(string name = null)
        {
            name = CheckEmptyName(name);
            var response = await GetNameChannelAsync(name);
            return response.Account_type;
        }


        /// <summary>
        /// Is channel Online
        /// </summary>
        /// <returns></returns>
        public async Task<bool> LiveAsync(string name = null)
        {
            name = CheckEmptyName(name);
            var response = await GetNameChannelAsync(name);
            return response.Online;
        }

        private string CheckEmptyName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                if (string.IsNullOrEmpty(Clientname))
                {
                    throw new Exception("Clientname don't exist or it's empty!");
                }
                name = Clientname;
            }

            return name;
        }

        /// <summary>
        /// Get Channel title 
        /// </summary>
        /// <returns>Title of the channel</returns>
        public async Task<string> GetChannelTitleAsync(string name = null)
        {
            name = CheckEmptyName(name);
            var response = await GetNameChannelAsync(name);
            return response.Title;
        }

        /// <summary>
        /// Get Channel video
        /// </summary>
        /// <returns>videos of the channel</returns>
        public async Task<ChannelVideo> GetChannelNameVideosAsync(string name = null)
        {
            name = CheckEmptyName(name);
            return await Client.GetFromJsonAsync<ChannelVideo>($"channel/name/{name}/videos");
        }

        /// <summary>
        /// Get Channel video
        /// </summary>
        /// <returns>videos of the channel</returns>
        public async Task<ChannelVideo> GetChannelIDVideosAsync(Nullable<int> ID = null)
        {
            ID ??= ClientID;
            return await Client.GetFromJsonAsync<ChannelVideo>($"channel/id/{ID}/videos");
        }

        
        /// <summary>
        /// Get User's avatar as an string
        /// Useful for discord bot programming
        /// </summary>
        /// <param name="name">channel name</param>
        /// <returns>the user's avatar</returns>
        public async Task<string> GetUserAvatarAsync(string name = null)
        {
            name = CheckEmptyName(name);

            //var url = $"https://picarto.tv/user_data/usrimg/{name}/dsdefault.jpg";
            var response = await GetNameChannelAsync(name);
            return response.Avatar;
        }


        /// <summary>
        /// Get the channel's languages
        /// </summary>
        /// <param name="name">the name of the channel</param>
        /// <returns>a list of languages from the channel</returns>
        public async Task<List<Language>> GetChannelLanguagesAsync(string name = null)
        {
            name = CheckEmptyName(name);
            var response = await GetNameChannelAsync(name);
            return response.Languages;
        }

        /// <summary>
        /// Get an list over those who are online right now on Picarto
        /// </summary>
        /// <param name="adult">adult is false in default</param>
        /// <param name="gaming">gaming is false in default</param>
        /// <param name="category">category is empty in default</param>
        /// <returns>a list over online channels</returns>
        public async Task<List<OnlineDetails>> GetOnlineChannelsAsync(bool adult = false, bool gaming = false, string category = null)
        {
            if (string.IsNullOrEmpty(category))
            {
                category = "";
            }

            var response = await Client.GetFromJsonAsync<OnlineChannels>($"online?adult={adult}&gaming={gaming}&categories={category}");
            return response.OnlineDetails;
        }

        /// <summary>
        /// Get user's thumbnail.
        /// </summary>
        /// <param name="name">Username</param>
        /// <returns>thumbnail</returns>
        public async Task<Thumbnail> GetThumbnailAsync(string name = null){
            name = CheckEmptyName(name);
            var response = await GetNameChannelAsync(name);
            return response.Thumbnail;
        } 
        
        /// <summary>
        /// Return a url that send a request to popout a chat based on input.
        /// </summary>
        /// <param name="name">input</param>
        /// <returns>url to the chat</returns>
        public string GetPopOutChat(string name = null)
        {
            name = CheckEmptyName(name);
            string url = $"https://picarto.tv/chatpopout/{name}/public";
            return url;
        }

        /// <summary>
        /// Get Online catagories
        /// </summary>
        /// <returns>list over online catagories</returns>
        public async Task<Categories> GetOnlineCategoriesAsync()
        {
            return await Client.GetFromJsonAsync<Categories>($"categories");
        }

        /// <summary>
        /// get Online events
        /// </summary>
        /// <returns>list over online events</returns>
        public async Task<Events> GetOnlineEventsAsync()
        {
            return await Client.GetFromJsonAsync<Events>($"events");
            
        }
    }
}

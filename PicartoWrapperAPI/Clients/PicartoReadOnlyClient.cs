using Newtonsoft.Json;
using PicartoWrapperAPI.Models;
using PicartoWrapperAPI.Models.Data.Chat;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PicartoWrapperAPI.Clients
{
    public class PicartoReadOnlyClient(string token = null) : BasePicartoClient(token)
    {
        #region Categories

        /// <summary>
        /// Get information about all categories
        /// </summary>
        /// <returns>A successful query, got all categories</returns>
        public async Task<List<Categories>> CategoriesAsync()
        {
            StringBuilder urlBuilder_ = new();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/categories");
            string url_ = urlBuilder_.ToString();
            return await GetAsync<List<Categories>>(url_);
        }

        #endregion

        #region Channel

        /// <summary>
        /// Gets information about a channel by name - providing a bearer token with permission readpub can get followed status in result
        /// </summary>
        /// <param name="channel_name">Channel name of user you wish to read</param>
        /// <returns>A successful query, channel exists</returns>
        public async Task<ChannelDetails> ShowChannelByNameAsync(string channel_name)
        {
            ArgumentNullException.ThrowIfNull(channel_name);
            StringBuilder urlBuilder_ = new();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/channel/name/{channel_name}");
            urlBuilder_.Replace("{channel_name}", Uri.EscapeDataString(ConvertToString(channel_name, System.Globalization.CultureInfo.InvariantCulture)));

            return await GetAsync<ChannelDetails>(urlBuilder_.ToString());
        }

        /// <summary>
        /// Get all videos for a channel by id
        /// </summary>
        /// <param name="channel_id">The id of the application to retrieve</param>
        /// <returns>A successful query, got videos</returns>
        public async Task<ChannelDetails> ShowChannelByIdAsync(long channel_id)
        {
            ArgumentNullException.ThrowIfNull(channel_id);
            StringBuilder urlBuilder_ = new();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/channel/id/{channel_id}");
            urlBuilder_.Replace("{channel_id}", Uri.EscapeDataString(ConvertToString(channel_id, System.Globalization.CultureInfo.InvariantCulture)));

            return await GetAsync<ChannelDetails>(urlBuilder_.ToString());
        }

        /// <summary>
        /// Get all videos for a channel by id
        /// </summary>
        /// <param name="channel_id">Channel id of user you wish to read</param>
        /// <returns>A successful query, got videos</returns>
        public async Task<List<ChannelVideo>> GetChannelVideosByChannelIdAsync(long channel_id)
        {
            ArgumentNullException.ThrowIfNull(channel_id);
            StringBuilder urlBuilder_ = new();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/channel/id/{channel_id}/videos");
            urlBuilder_.Replace("{channel_id}", Uri.EscapeDataString(ConvertToString(channel_id, System.Globalization.CultureInfo.InvariantCulture)));

            return await GetAsync<List<ChannelVideo>>(urlBuilder_.ToString());
        }

        /// <summary>
        /// Get Channel video
        /// </summary>
        /// <returns>videos of the channel</returns>
        public async Task<List<ChannelVideo>> GetChannelVideosByChannelNameAsync(string channel_name)
        {
            ArgumentNullException.ThrowIfNull(channel_name);
            StringBuilder urlBuilder_ = new();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/channel/name/{channel_name}/videos");
            urlBuilder_.Replace("{channel_name}", Uri.EscapeDataString(ConvertToString(channel_name, System.Globalization.CultureInfo.InvariantCulture)));

            return await GetAsync<List<ChannelVideo>>(urlBuilder_.ToString());
        }

        /// <summary>
        /// Gets all currently online channels - providing a bearer token with permission readpub can get followed status in result
        /// </summary>
        /// <param name="adult">Whether or not to include adult channels (defaults to `false`)</param>
        /// <param name="gaming">Whether or not to include gaming channels (defaults to `false`)</param>
        /// <param name="category">What categories to limit this to (blank/not included doesn't filter) - seperate multiple categories by a `,` character</param>
        /// <returns>A successful query, got all online channels</returns>
        public async Task<List<OnlineDetails>> GetAllOnlineChannelsAsync(bool? adult, bool? gaming, object category)
        {
            StringBuilder urlBuilder_ = new ();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/online?");
            if (adult != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("adult") + "=").Append(Uri.EscapeDataString(ConvertToString(adult, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (gaming != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("gaming") + "=").Append(Uri.EscapeDataString(ConvertToString(gaming, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (category != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("category") + "=").Append(Uri.EscapeDataString(ConvertToString(category, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            string url_ = urlBuilder_.ToString();
            return await GetAsync<List<OnlineDetails>>(url_);
        }

        /// <summary>
        /// Get all channels matching the given search criteria (by name and tags)
        /// </summary>
        /// <param name="q">The search query to use (does not currently support special qualifiers)</param>
        /// <param name="adult">Whether or not to include adult channels (defaults to `false`)</param>
        /// <param name="page">The page to display (defaults to `1`)</param>
        /// <param name="commissions">Whether or not to filter by streams offering commissions</param>
        /// <returns>A successful query, got channels</returns>
        public async Task<List<SearchChannel>> SearchAllChannelMatchingCriteriaAsync(string q, bool? adult, long? page, bool? commissions)
        {
            ArgumentNullException.ThrowIfNull(q);

            StringBuilder urlBuilder_ = new ();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/search/channels?");
            urlBuilder_.Append(Uri.EscapeDataString("q") + "=").Append(Uri.EscapeDataString(ConvertToString(q, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            if (adult != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("adult") + "=").Append(Uri.EscapeDataString(ConvertToString(adult, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("page") + "=").Append(Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (commissions != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("commissions") + "=").Append(Uri.EscapeDataString(ConvertToString(commissions, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            string url_ = urlBuilder_.ToString();
            return await GetAsync<List<SearchChannel>>(url_);
        }

        /// <summary>
        /// Get all channels matching the given search criteria (by name and tags)
        /// </summary>
        /// <param name="q">The search query to use (does not currently support special qualifiers)</param>
        /// <param name="adult">Whether or not to include adult channels (defaults to `false`)</param>
        /// <param name="page">The page to display (defaults to `1`)</param>
        /// <returns>A successful query, got channels</returns>
        public async Task<List<SearchVideo>> GetAllChannelsAsync(string q, bool? adult, long? page)
        {
            ArgumentNullException.ThrowIfNull(q);

            StringBuilder urlBuilder_ = new();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/search/videos?");
            urlBuilder_.Append(Uri.EscapeDataString("q") + "=").Append(Uri.EscapeDataString(ConvertToString(q, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            if (adult != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("adult") + "=").Append(Uri.EscapeDataString(ConvertToString(adult, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            if (page != null)
            {
                urlBuilder_.Append(Uri.EscapeDataString("page") + "=").Append(Uri.EscapeDataString(ConvertToString(page, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
            }
            string url_ = urlBuilder_.ToString();
            return await GetAsync<List<SearchVideo>>(url_);
        }
        #endregion

        #region Streams

         /// <summary>
        /// Get stream
        /// </summary>
        /// <param name="channel_id">Channel Id</param>
        /// <returns>A successful query, got stream</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<StreamBody> StreamsAsync(long channel_id)
        {
            ArgumentNullException.ThrowIfNull(channel_id);

            StringBuilder urlBuilder_ = new ();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/channel/id/{channel_id}/streams");
            urlBuilder_.Replace("{channel_id}", Uri.EscapeDataString(ConvertToString(channel_id, System.Globalization.CultureInfo.InvariantCulture)));
            string url_ = urlBuilder_.ToString();
            return await GetAsync<StreamBody>(url_);
        }

        /// <summary>
        /// Get stream
        /// </summary>
        /// <param name="channel_name">Channel Id</param>
        /// <returns>A successful query, got stream</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        public async Task<StreamBody> StreamsAsync(string channel_name)
        {
            ArgumentNullException.ThrowIfNull(channel_name);

            //Shouldnt this be /channel/name/{channel_name}/streams?
            StringBuilder urlBuilder_ = new();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/channel/id/{channel_name}/streams");
            urlBuilder_.Replace("{channel_name}", Uri.EscapeDataString(ConvertToString(channel_name, System.Globalization.CultureInfo.InvariantCulture)));
            string url_ = urlBuilder_.ToString();
            return await GetAsync<StreamBody>(url_);
        }

        /// <summary>
        /// Get all stream server endpoint
        /// </summary>
        /// <returns>A successful query, got all stream server endpoints</returns>
        public async Task<List<StreamServer>> AllStreamsAsync()
        {
            StringBuilder urlBuilder_ = new();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/stream/servers"); 
            string url_ = urlBuilder_.ToString();
            return await GetAsync<List<StreamServer>>(url_);
        }

        #endregion

        #region Nofifications

        /// <summary>
        /// Get all global notifications/announcements
        /// </summary>
        /// <returns>A successful query, got global notifications</returns>
        public async Task<List<Notifications>> NotificationsAsync()
        {
            StringBuilder urlBuilder_ = new();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/notifications");
            string url_ = urlBuilder_.ToString();
            return await GetAsync<List<Notifications>>(url_);
        }

        #endregion

        #region ChatSetting

        /// <summary>
        /// Get all chat settings
        /// </summary>
        /// <returns>Successfully got all chat settings</returns>
        public async Task<DisplayChatSetting> GetChatSettingsAsync()
        {

            StringBuilder urlBuilder_ = new();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/user/chat/settings");
            string url_ = urlBuilder_.ToString();
            return await GetAsync<DisplayChatSetting>(url_);
        }

        /// <summary>
        /// Update the chat display style setting
        /// </summary>
        /// <returns>Successfully set</returns>
        public async Task PostChatSettingsDisplaystyleAsync(ValueBody body)
        {
            var urlBuilder_ = new StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/user/chat/settings/displaystyle");

            string jsonContent = JsonConvert.SerializeObject(body);
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            await PostAsync<ValueBody>(urlBuilder_.ToString(), content);
        }

        /// <summary>
        /// Update the chat whispers setting
        /// </summary>
        /// <returns>Successfully set</returns>
        public async Task PostChatSettingsWhispersAsync(EnableBody body)
        {
            var urlBuilder_ = new StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/user/chat/settings/whispers");

            string jsonContent = JsonConvert.SerializeObject(body);
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            await PostAsync<EnableBody>(urlBuilder_.ToString(), content);
        }

        /// <summary>
        /// Update the chat emotes setting
        /// </summary>
        /// <returns>Successfully set</returns>
        public async Task PostChatSettingsEmotesAsync(EnableBody body)
        {
            var urlBuilder_ = new StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/user/chat/settings/emotes");

            string jsonContent = JsonConvert.SerializeObject(body);
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            await PostAsync<EnableBody>(urlBuilder_.ToString(), content);
        }

        /// <summary>
        /// Update the chat sounds setting
        /// </summary>
        /// <returns>Successfully set</returns>
        public async Task<object> PostChatSettingsSoundsAsync(EnableBody body)
        {
            var urlBuilder_ = new StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/user/chat/settings/sounds");
            return await PostAsync<EnableBody, object>(urlBuilder_.ToString(), body);
        }


        /// <summary>
        /// Update the chat timestamps setting
        /// </summary>
        /// <returns>Successfully set</returns>
        public async Task PostChatSettingsTimestampsAsync(EnableBody body)
        {
            var urlBuilder_ = new StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/user/chat/settings/timestamps");

            string jsonContent = JsonConvert.SerializeObject(body);
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            await PostAsync<EnableBody>(urlBuilder_.ToString(), content);
        }

        /// <summary>
        /// Get the current email settings
        /// </summary>
        /// <returns>Got current email settings</returns>
        public async Task<EmailSettings> GetEmailsAsync()
        {
            StringBuilder urlBuilder_ = new();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/user/emails");
            string url_ = urlBuilder_.ToString();
            return await GetAsync<EmailSettings>(url_);
        }

        /// <summary>
        /// Toggle newsletter emails
        /// </summary>
        /// <returns>Enabled/disabled newsletter emails</returns>
        public async Task PostEmailsNewsletterAsync(EnableBody body)
        {
            var urlBuilder_ = new StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/user/emails/newsletter");

            string jsonContent = JsonConvert.SerializeObject(body);
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            await PostAsync<EnableBody>(urlBuilder_.ToString(), content);
        }

        /// <summary>
        /// Toggle stream online emails
        /// </summary>
        /// <returns>Enabled/disabled newsletter emails</returns>
        public async Task<object> PostEmailsOnlineAsync(EnableBody body)
        {
            var urlBuilder_ = new StringBuilder();
            urlBuilder_.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append("/user/emails/online");
            return await PostAsync<EnableBody, object>(urlBuilder_.ToString(), body);
        }
        #endregion

        #region Misc



        /// <summary>
        /// Return a url that send a request to popout a chat based on input.
        /// </summary>
        /// <param name="name">input</param>
        /// <returns>url to the chat</returns>
        public string GetPopOutChat(string name = null)
        {
            return $"https://picarto.tv/chatpopout/{name}/public";
        }

        #endregion

        /// <summary>
        /// Get User's avatar as an string
        /// Useful for discord bot programming
        /// </summary>
        /// <param name="name">channel name</param>
        /// <returns>the user's avatar</returns>
        public async Task<string> GetUserAvatarAsync(string name = null)
        {
            //var url = $"https://picarto.tv/user_data/usrimg/{name}/dsdefault.jpg";
            var response = await ShowChannelByNameAsync(name);
            return response.Avatar;
        }


        /// <summary>
        /// Get the channel's languages
        /// </summary>
        /// <param name="name">the name of the channel</param>
        /// <returns>a list of languages from the channel</returns>
        public async Task<List<Language>> GetChannelLanguagesAsync(string name = null)
        {
            var response = await ShowChannelByNameAsync(name);
            return response.Languages;
        }

        /// <summary>
        /// Get user's thumbnail.
        /// </summary>
        /// <param name="name">Username</param>
        /// <returns>thumbnail</returns>
        public async Task<Thumbnail> GetThumbnailAsync(string name = null){
            var response = await ShowChannelByNameAsync(name);
            return response.Thumbnail;
        } 
    }
}

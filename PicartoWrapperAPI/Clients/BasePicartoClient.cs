using Newtonsoft.Json;
using PicartoWrapperAPI.Helpers;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PicartoWrapperAPI.Clients;
public class BasePicartoClient : IPicartoClient
{
    public readonly HttpClient httpClient = new();

    public string BaseUrl
    {
        get { return PicartoHelper.BaseUrl; }
    }

    public BasePicartoClient(string authToken = null)
    {
        httpClient = new()
        {
            BaseAddress = new Uri(BaseUrl)
        };
        AddHeaders();

        // Set authorization token if provided
        if (!string.IsNullOrEmpty(authToken))
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", string.Format("Bearer {0}", authToken));
        }
    }

    private void AddHeaders()
    {
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/json"));
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/x-json"));
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/javascript"));
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*+json"));
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
    }

    public void AddClientNameToHeader(string clientname) => httpClient.DefaultRequestHeaders.Add("Client-name", clientname);
    public void AddClientIDToHeader(string clientname) => httpClient.DefaultRequestHeaders.Add("Client-ID", clientname);

    public async Task<bool> PostAsync(string requestUri, HttpContent content = null, CancellationToken cancellationToken = default)
    {
        try
        {
            HttpResponseMessage response = await httpClient.PostAsync(requestUri, null, cancellationToken);
            return response.IsSuccessStatusCode;
        }
        catch (Exception)
        {
            // Log the exception or handle it as needed
            // For now, we just return false to indicate failure
            return false;
        }
    }

    public async Task<bool> GetAsync(string requestUri, CancellationToken cancellationToken = default)
    {
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(requestUri, cancellationToken);
            
            return response.IsSuccessStatusCode;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<TResponse> GetAsync<TResponse>(string requestUri, CancellationToken cancellationToken = default)
    {
        HttpResponseMessage response = await httpClient.GetAsync(requestUri, cancellationToken);
        return await HandleResponse<TResponse>(response);
    }

    public async Task<TResponse> PostAsync<TResponse>(string requestUri, HttpContent content = null, CancellationToken cancellationToken = default)
    {
        HttpResponseMessage response = await httpClient.PostAsync(requestUri, null, cancellationToken);
        return await HandleResponse<TResponse>(response);
    }

    public async Task<TResponse> PostAsync<TRequest, TResponse>(string requestUri, TRequest requestData, CancellationToken cancellationToken = default)
    {
        string jsonContent = JsonConvert.SerializeObject(requestData);
        HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await httpClient.PostAsync(requestUri, content, cancellationToken);
        return await HandleResponse<TResponse>(response);
    }

    

    private async Task<TResponse> HandleResponse<TResponse>(HttpResponseMessage response)
    {
        string responseData = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            return JsonConvert.DeserializeObject<TResponse>(responseData);
        }
        else
        {
            // Handle specific error cases here
            throw response.StatusCode switch
            {
                HttpStatusCode.BadRequest => new HttpRequestException($"Bad request. Response: {responseData}"),
                HttpStatusCode.Forbidden => new HttpRequestException($"You do not have access to this channel with your access token. Response: {responseData}"),
                HttpStatusCode.NotFound => new HttpRequestException($"Channel does not exist. Response: {responseData}"),
                _ => new HttpRequestException($"Request failed with status code {response.StatusCode}. Response: {responseData}"),// For unexpected status codes, throw a general exception
            };
        }
    }

    public string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
    {
        if (value == null)
        {
            return string.Empty;
        }

        if (value is Enum)
        {
            var name = Enum.GetName(value.GetType(), value);
            if (name != null)
            {
                var field = System.Reflection.IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                if (field != null)
                {
                    System.Runtime.Serialization.EnumMemberAttribute attribute = System.Reflection.CustomAttributeExtensions.GetCustomAttribute(field, typeof(System.Runtime.Serialization.EnumMemberAttribute))
                        as System.Runtime.Serialization.EnumMemberAttribute;
                    if (attribute != null)
                    {
                        return attribute.Value ?? name;
                    }
                }

                var converted = Convert.ToString(Convert.ChangeType(value, Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                return converted ?? string.Empty;
            }
        }
        else if (value is bool)
        {
            return Convert.ToString((bool)value, cultureInfo).ToLowerInvariant();
        }
        else if (value is byte[])
        {
            return Convert.ToBase64String((byte[])value);
        }
        else if (value.GetType().IsArray)
        {
            System.Collections.Generic.IEnumerable<object> array = System.Linq.Enumerable.OfType<object>((Array)value);
            return string.Join(",", System.Linq.Enumerable.Select(array, o => ConvertToString(o, cultureInfo)));
        }

        string result = Convert.ToString(value, cultureInfo);
        return result ?? "";
    }

}

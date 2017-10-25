# Picarto C# Wrapper for picarto v1 REST API

## Notes
This library/wrapper is inspired of/by [Twitch C# Wrapper for the Twitch v3 REST API](https://github.com/michidk/TwitchCSharp)'s development style.
If it wasn't for michidk's work, I wouldn't be able to make this wrapper. I would love to thank him for his amazing work...

I know that there are a chance that this might break in the future, if so, just contact me or someone who are smarter than a fly to fix it. 

## Documentation
This project is a wrapper for picarto API, so that you can interact with it using C#.
Most of the methods, functions, models and etc are named after their api from picarto.
The Picarto API is documented [here](https://docs.picarto.tv/api/).

# Installation

PicartoWrapperAPI is [available on NuGet](https://www.nuget.org/packages/picartowrapperapi/). Use the package manager
console in Visual Studio to install it:

```
Install-Package PicartoWrapperAPI
```

If you're using .NET Core, you can use the `dotnet` command from your favorite shell:

```
dotnet add package picartowrapperapi
```


## Usage
### Client
To interact with the API you need at least a [client-ID](#oauth-key-/-client-id). Some requests can only be made by authorized users. These also need a [OAuth-key](#oauth-key-/-client-id).

There are three client classes:

| Class                          | Explanation                                                            |
| ------------------------------ | ---------------------------------------------------------------------- |
| PicartohReadOnlyClient         | you can use this client without an auth-key to access public data      |
| PicartoAuthenticatedClient     | needs to authenticate via auth-key, can access and change private data |


### OAuth-Key / Client-ID
Your Picarto client-ID is used to protect their servers from spam-attacks. 

Read more about the picarto Oauth authentication API [here](https://oauth.picarto.tv/).

### Example
```c#
Using PicartoWrapperAPI.Clients;

 var client = new PicartoReadOnlyClient("Djinnet");
 var channel = client.GetOnlineChannels();

 var mychannel = client.GetNameChannel();

 Console.WriteLine(mychannel.title);

 Console.WriteLine("This is a list over those who are online on picarto right now.");

            
 foreach (var user in channel)
 {
    Console.WriteLine(user.Name);
 }

```

## Dependencies
- [RestSharp](http://restsharp.org/)
- [Json.NET](http://www.newtonsoft.com/json)

### Unimplemented APIs

The following APIs are not yet implemented by PicartoWrapperAPI, but I'm slowly working through the list. The APIs are implemented in random order. **Need one of these APIs right now?** Please open an issue or make a pull request! 

| API | Notes |
|-----|-------|
| [User](https://docs.picarto.tv/api/#!/user/get_user) | Get private info about the currently authenticated user|
| [User-streamkey](https://docs.picarto.tv/api/#!/user/get_user_streamkey) | Get the stream key of the currently authenticated user|
| [User-jwtkey](https://docs.picarto.tv/api/#!/user/get_user_jwtkey) | Generate a bot JWT token to connect to a channel|
| [User-title](https://docs.picarto.tv/api/#!/user/post_user_title) | Update the user's channel title|
| [User-category](https://docs.picarto.tv/api/#!/user/post_user_category) | Update the user's channel title|
| [user-adult](https://docs.picarto.tv/api/#!/user/post_user_adult) | Update the user's adult status|
| [GET - webhooks](https://docs.picarto.tv/api/#!/webhook/get_webhooks) | Get all registered webhooks for your account|
| [POST - webhooks](https://docs.picarto.tv/api/#!/webhook/post_webhooks) | Register a webhook|
| [DELETE - webhooks with ID](https://docs.picarto.tv/api/#!/webhook/delete_webhooks_webhook_id) | Delete a webhook|
| [GET - webhooks with ID](https://docs.picarto.tv/api/#!/webhook/get_webhooks_webhook_id) | Get a webhook|
| [PUT - webhooks with ID](https://docs.picarto.tv/api/#!/webhook/put_webhooks_webhook_id) | Update a webhook's URI|

## License
Used some code from [Gibletto](https://github.com/gibletto).
Used some code from [michidk](https://github.com/michidk)
open-source library - MIT license should be fine for that.

# Picarto C# Wrapper for picarto v1 REST API

## Notes
This library/wrapper is inspired of/by [Twitch C# Wrapper for the Twitch v3 REST API](https://github.com/michidk/TwitchCSharp)'s development style.
If it wasn't for michidk's work, I wouldn't be able to make this wrapper. I would love to thank him for his amazing work...

I know that there are a chance that this might break in the future, if so, just contact me or someone who are smarter than a fly to fix it. 

## Documentation
This project is a wrapper for picarto API, so that you can interact with it using C#.
Most of the methods, functions, models and etc are named after their api from picarto.
The Picarto API is documented [here](https://docs.picarto.tv/api/).

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

## License
Used some code from [Gibletto](https://github.com/gibletto).
Used some code from [michidk](https://github.com/michidk)
open-source library - MIT license should be fine for that.

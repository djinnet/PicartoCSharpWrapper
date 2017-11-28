# Picarto C# Wrapper for picarto v1 REST API


## Documentation
This project is a wrapper for picarto API, so that you can interact with it using C#.
Most of the methods, functions, models and etc are named after their api from picarto.
The Picarto API is documented [here](https://docs.picarto.tv/api/).

# Installation
## SOON FINISHING (you can't use this ATM)



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

            //You have to pass at least one parameter to work
            var client = new PicartoReadOnlyClient(1); //an ID
            var client2 = new PicartoReadOnlyClient("Djinnet"); //an username

            //allow to fetch info about every online channel
            var channel = client.GetOnlineChannels(true);

            //allow to get channel property from my client2 object
            var client2Channel = client2.GetNameChannel();

            //Allow to check on a certain user is online based on a string
            var isOnline = client.Live("djinnet");

            //allow to check which account type the user is. 
            //you can also check on other users's account type based on string. There are a override method for that.
            var myaccounttype = client2.GetAccountType();

            //you can get your channel's title based on your ID
            Console.WriteLine(client.GetIDChannel().title);

            //then what if you want to get an unknown user's channel title?
            //you can just write their username as an parameter and it's it. 
            //Simple and clean.
            Console.WriteLine(client.GetChannelTitle("Djinnet"));

            //okay, what if I want to know how many are online on Picarto right now.
            //just use this code then!
            //it'll returned a list and you can limit the list into an integer.
            Console.WriteLine($"There are {channel.Capacity} users those who are online on picarto right now.");

            //even variable is possible.
            Console.WriteLine("My account type is: " + myaccounttype);

            //isOnline is a bool value, so remember to make a if-statement to return if you're online or not.
            if (isOnline)
            {
                Console.WriteLine("I'm Online!");
            }
            else
            {
                Console.WriteLine("I'm not online!");
            }

            //you can also return all current users who are online on picarto's name.
            // remember channel is a list, so therefore you can do this.

            //works with linq. 
            foreach (var x in channel.Where(x => x.Adult))
            {
                //return adult channels
                Console.WriteLine("{0}, {1}", x.Name, x.Adult);
            }

            //simple example
            foreach (var user in channel)
            {
                //return not adult and not gaming channels
                Console.WriteLine(user.Name); 
            }


            //allow me to check if the data is correct. 
            //not a feature that is required in a program tho. :P (JK)
            Console.ReadKey();

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
| [Chat popout](https://picarto.tv/chatpopout/{username}/public) | Get chat popout|







## Notes
This library/wrapper is inspired of [Twitch C# Wrapper for the Twitch v3 REST API](https://github.com/michidk/TwitchCSharp)'s development style.

I know that there are a chance that this might break in the future, if so, just contact me or submit an issue on github.

## License
- Used some code from [Gibletto](https://github.com/gibletto).
- development style from [michidk](https://github.com/michidk)
- MIT license.

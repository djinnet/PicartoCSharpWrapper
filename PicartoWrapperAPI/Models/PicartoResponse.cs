using System;
using Newtonsoft.Json;
using PicartoWrapperAPI.Enums;

namespace PicartoWrapperAPI.Models
{
    public class PicartoResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("_total")]
        public long Total { get; set; }

        public PicartoResponse()
        {

        }

        public State GetState()
        {
            State state;
            switch (Status)
            {
                case 200:
                    state = State.success;
                    break;
                case 400:
                    state = State.bad_request;
                    break;
                case 403:
                    state = State.Do_not_have_access_with_your_access_token;
                    break;
                case 404:
                    state = State.Channel_does_not_exist;
                    break;
                default:
                    state = State.bad_request;
                    break;
            }
            return state;
        }

    }
}

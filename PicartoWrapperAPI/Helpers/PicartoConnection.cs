using System;
using RestSharp;
using RestSharp.Deserializers;



namespace PicartoWrapperAPI
{
    public class PicartoConnection
    {
        public readonly string username;
        public readonly string clientId;
        public readonly string oAuthToken;

        public PicartoConnection(string username, string clientId, string oAuthToken)
        {
            this.username = username;
            this.clientId = clientId;
            this.oAuthToken = oAuthToken;
        }
    }
}

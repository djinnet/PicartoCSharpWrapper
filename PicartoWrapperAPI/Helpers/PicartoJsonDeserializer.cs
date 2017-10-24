using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers;
using RestSharp.Deserializers;
using System.Collections.Generic;
using System.IO;
using PicartoWrapperAPI.Interfaces;

namespace PicartoWrapperAPI.Helpers
{
    class PicartoJsonDeserializer : IDeserializer
    {
        private Newtonsoft.Json.JsonSerializer serializer;

        public PicartoJsonDeserializer(Newtonsoft.Json.JsonSerializer serializer)
        {
            this.serializer = serializer;
        }

        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }

        public string ContentType
        {
            get { return "application/json"; }
            set { }
        }

        public T Deserialize<T>(IRestResponse response)
        {
            var content = response.Content;
            return JsonConvert.DeserializeObject<T>(content);
        }

        

        public static PicartoJsonDeserializer Default
        {
            get
            {
                return new PicartoJsonDeserializer(new Newtonsoft.Json.JsonSerializer()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                });
            }
        }
        
    }
}


using System.Collections.Generic;
using Newtonsoft.Json;
using PicartoWrapperAPI.Helpers;

namespace PicartoWrapperAPI.Models
{
    [JsonObject(ItemConverterType = typeof (PicartoListConverter))]
    public class PicartoList<T> : PicartoResponse
    {
        public List<T> List { get; set; }
    }
}

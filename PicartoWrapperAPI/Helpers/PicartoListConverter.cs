using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PicartoWrapperAPI.Models;

namespace PicartoWrapperAPI.Helpers
{
    class PicartoListConverter : JsonConverter
    {

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = Activator.CreateInstance(objectType) as PicartoResponse;
            var genericArg = objectType.GetGenericArguments()[0];
            var key = genericArg.GetCustomAttribute<JsonObjectAttribute>();
            if (value == null || key == null)
            {
                return null;
            }
            var JsonObject = JObject.Load(reader);
            value.Total = SetValue<long>(JsonObject["_total"]);
            value.Error = SetValue<string>(JsonObject["error"]);
            value.Message = SetValue<string>(JsonObject["message"]);
            var list = JsonObject[key.Id];
            var prop = value.GetType().GetProperty("List");
            if (prop != null && list != null)
            {
                prop.SetValue(value, list.ToObject(prop.PropertyType, serializer));
            }
            return value;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType.IsGenericType && typeof(PicartoList<>) == objectType.GetGenericTypeDefinition();
        }

        private T SetValue<T>(JToken token)
        {
            if (token != null)
            {
                return (T)token.ToObject(typeof(T));
            }
            return default(T);
        }
    }
}

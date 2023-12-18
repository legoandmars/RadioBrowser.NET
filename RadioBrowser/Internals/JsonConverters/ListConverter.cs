using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioBrowser.Internals.JsonConverters
{
    public class ListConverter : JsonConverter<List<string>>
    {
        public override List<string> ReadJson(JsonReader reader, Type objectType, List<string> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var inputString = (string)reader.Value;
            return inputString?.Split(',').Select(s => s.Trim()).ToList();
        }

        public override void WriteJson(JsonWriter writer, List<string> value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}
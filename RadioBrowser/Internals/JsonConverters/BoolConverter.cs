using Newtonsoft.Json;
using System;

namespace RadioBrowser.Internals.JsonConverters
{
    public class BoolConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                    // Assuming the JSON value is a string that represents an integer (e.g., "0" or "1")
                    var stringValue = reader.Value.ToString();
                    return stringValue == "1";
                case JsonToken.Integer:
                    // Assuming the JSON value is a number (e.g., 0 or 1)
                    var intValue = Convert.ToInt32(reader.Value);
                    return intValue == 1;
                default:
                    throw new JsonSerializationException("Unexpected token type: " + reader.TokenType);
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}
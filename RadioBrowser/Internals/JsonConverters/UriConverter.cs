using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace RadioBrowser.Internals.JsonConverters
{
    public class UriConverter : JsonConverter<Uri>
    {
        public override Uri ReadJson(JsonReader reader, Type objectType, Uri existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            try
            {
                return new Uri((string)reader.Value);
            }
            catch (UriFormatException)
            {
                // Trace.WriteLine("Cannot parse URI.");
                return null;
            }
        }

        public override void WriteJson(JsonWriter writer, Uri value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}
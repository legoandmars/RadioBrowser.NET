using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Globalization;

namespace RadioBrowser.Internals.JsonConverters
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            try
            {
                return DateTime.ParseExact((string)reader.Value, "yyyy-MM-dd HH:mm:ss", CultureInfo.CurrentCulture);
            }
            catch (FormatException)
            {
                // Trace.WriteLine("Cannot parse date.");
                return new DateTime(0);
            }
        }

        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}
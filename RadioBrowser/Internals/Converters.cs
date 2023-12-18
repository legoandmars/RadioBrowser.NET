using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using RadioBrowser.Models;

namespace RadioBrowser.Internals
{
    internal class Converters
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        internal Converters()
        {
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                // Match case-insensitive property names
                ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver
                {
                    NamingStrategy = new Newtonsoft.Json.Serialization.CamelCaseNamingStrategy
                    {
                        ProcessDictionaryKeys = true,
                        OverrideSpecifiedNames = false
                    }
                },
                // Ignore null values in serialization and deserialization
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        internal List<StationInfo> ToStationsList(string json)
        {
            return JsonConvert.DeserializeObject<List<StationInfo>>(json, _jsonSerializerSettings);
        }

        internal List<NameAndCount> ToNameAndCountList(string json)
        {
            return JsonConvert.DeserializeObject<List<NameAndCount>>(json, _jsonSerializerSettings);
        }

        internal List<State> ToStatesList(string json)
        {
            return JsonConvert.DeserializeObject<List<State>>(json, _jsonSerializerSettings);
        }

        internal ActionResult ToActionResult(string json)
        {
            return JsonConvert.DeserializeObject<ActionResult>(json, _jsonSerializerSettings);
        }

        internal ClickResult ToClickResult(string json)
        {
            return JsonConvert.DeserializeObject<ClickResult>(json, _jsonSerializerSettings);
        }

        internal AddStationResult ToAddStationResult(string json)
        {
            return JsonConvert.DeserializeObject<AddStationResult>(json, _jsonSerializerSettings);
        }

        internal static string GetQueryString(object obj)
        {
            var properties = obj.GetType()
                .GetProperties()
                .Where(p => p.GetValue(obj, null) != null)
                .Select(p =>
                    char.ToLowerInvariant(p.Name[0]) + p.Name.Substring(1) + "=" +
                    HttpUtility.UrlEncode(Convert.ToString(p.GetValue(obj, null))));

            return string.Join("&", properties.ToArray());
        }
    }
}
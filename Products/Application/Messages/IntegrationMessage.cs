using Newtonsoft.Json;
using System;

namespace Avanade.eShop.Application.Messages
{
    public abstract class IntegrationMessage
    {
        [JsonProperty(PropertyName = "version")]
        public int Version { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public DateTimeOffset Timestamp { get; set; }
    }
}

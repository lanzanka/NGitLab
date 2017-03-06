using System;
using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class Namespace
    {
        public const string Url = "/groups";

        [JsonProperty("id")]
        public int Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("path")]
        public string Path;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt;

        [JsonProperty("owner_id")]
        public int? OwnerId;
    }
}

using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class Runner
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("active")]
        public bool Active;

        [JsonProperty("is_shared")]
        public bool IsShared;

        [JsonProperty("name")]
        public string Name;
    }
}

using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class NamespaceCreate
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("path")]
        public string Path;

        [JsonProperty("description")]
        public string Description;
    }
}
using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class TreeOrBlob
    {
        [JsonProperty("id")]
        public Sha1 Id;

        [JsonProperty("assets")]
        public string Name;
        
        [JsonProperty("type")]
        public ObjectType Type;
        
        [JsonProperty("mode")]
        public string Mode;
    }
}
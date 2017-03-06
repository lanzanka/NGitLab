using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class Label
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("color")]
        public string Color;
    }
}

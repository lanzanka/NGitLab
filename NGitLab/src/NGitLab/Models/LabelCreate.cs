using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class LabelCreate
    {
        [JsonProperty("id")]
        public int Id;
        
        [JsonProperty("name")]
        public string Name;
        
        [JsonProperty("color")]
        public string Color;
    }
}

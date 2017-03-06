using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class LabelDelete
    {
        [JsonProperty("id")]
        public int Id;
        
        [JsonProperty("name")]
        public string Name;
    }
}

using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class MergeRequestComment
    {
        [JsonProperty("body")] 
        public string Body;

        [JsonProperty("author")]
        public User Author { get; set; }
    }
}
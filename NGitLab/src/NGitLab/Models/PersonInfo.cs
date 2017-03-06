using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class PersonInfo
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("email")]
        public string Email;
    }
}
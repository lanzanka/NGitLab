using System;
using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class Author
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("username")]
        public string Username;

        [JsonProperty("email")]
        public string Email;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("state")]
        public string State;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;
    }
}

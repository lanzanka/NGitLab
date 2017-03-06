using System;
using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class Milestone
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("title")]
        public string Title;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("due_date")]
        public string DueDate;

        [JsonProperty("state")]
        public string State;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt;
    }
}

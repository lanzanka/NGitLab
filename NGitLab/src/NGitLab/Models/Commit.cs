using System;
using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class Commit
    {
        public const string Url = "/commits";

        [JsonProperty("id")]
        public Sha1 Id;

        [JsonProperty("title")]
        public string Title;

        [JsonProperty("short_id")]
        public string ShortId;

        [JsonProperty("author_name")]
        public string AuthorName;

        [JsonProperty("author_email")]
        public string AuthorEmail;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;

        [JsonProperty("message")]
        public string Message;
    }
}
using System;
using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class Pipeline
    {
        public const string Url = "/pipelines";

        [JsonProperty("id")]
        public int Id;

        [JsonProperty("status")]
        public string Status;

        [JsonProperty("ref")]
        public string Ref;

        [JsonProperty("sha")]
        public Sha1 Sha;

        [JsonProperty("before_sha")]
        public Sha1 BeforeSha;

        [JsonProperty("tag")]
        public Tag Tag;

        [JsonProperty("path")]
        public string Path;

        [JsonProperty("yaml_errors")]
        public string YamlErrors;

        [JsonProperty("user")]
        public User User;

        [JsonProperty("created_at")]
        public DateTime? CreatedAt;

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt;

        [JsonProperty("started_at")]
        public DateTime? StartedAt;

        [JsonProperty("commited_at")]
        public DateTime? CommitedAt;

        [JsonProperty("duration")]
        public string Duration;

        [JsonProperty("coverage")]
        public string Coverage;
    }
}

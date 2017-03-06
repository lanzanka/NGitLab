using System;
using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class Build
    {
        [JsonProperty("commit")]
        public Commit Commit;

        [JsonProperty("coverage")]
        public string Coverage;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;

        [JsonProperty("artifacts_file")]
        public ArtifactsFile ArtifactsFile;

        [JsonProperty("finished_at")]
        public DateTime? FinishedAt;

        [JsonProperty("id")]
        public int Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("pipeline")]
        public Pipeline Pipeline;

        [JsonProperty("ref")]
        public string Ref;

        [JsonProperty("runner")]
        public Runner Runner;

        [JsonProperty("stage")]
        public string Stage;

        [JsonProperty("started_at")]
        public DateTime? StartedAt;

        [JsonProperty("status")]
        public string Status;

        [JsonProperty("tag")]
        public bool Tag;

        [JsonProperty("user")]
        public User User;
    }
}
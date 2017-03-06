using System;
using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class Issue
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("iid")]
        public int IssueId;

        [JsonProperty("project_id")]
        public int ProjectId;

        [JsonProperty("title")]
        public string Title;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("labels")]
        public string[] Labels;

        [JsonProperty("milestone")]
        public Milestone Milestone;

        [JsonProperty("assignee")]
        public Assignee Assignee;

        [JsonProperty("author")]
        public Author Author;

        [JsonProperty("state")]
        public string State;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt;
    }
}

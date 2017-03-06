using System;
using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class MergeRequest
    {
        public const string Url = "/merge_requests";

        [JsonProperty("id")]
        public int Id;

        [JsonProperty("iid")]
        public int Iid;

        [JsonProperty("state")]
        public string State;

        [JsonProperty("title")]
        public string Title;    
            
        [JsonProperty("assignee")]
        public User Assignee;

        [JsonProperty("author")]
        public User Author;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("downvotes")]
        public int Downvotes;

        [JsonProperty("upvotes")]
        public int Upvotes;

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt;

        [JsonProperty("target_branch")]
        public string TargetBranch;

        [JsonProperty("source_branch")]
        public string SourceBranch;

        [JsonProperty("project_id")]
        public int ProjectId;

        [JsonProperty("source_project_id")]
        public int SourceProjectId;

        [JsonProperty("target_project_id")]
        public int TargetProjectId;

        [JsonProperty("work_in_progress")]
        public bool? WorkInProgress;

        [JsonProperty("labels")]
        public string[] Labels;
    }
}

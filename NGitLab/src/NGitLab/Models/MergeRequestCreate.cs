using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class MergeRequestCreate
    {        
        [JsonProperty("source_branch")]
        public string SourceBranch;

        [JsonProperty("target_branch")]
        public string TargetBranch;

        [JsonProperty("assignee_id")]
        public int? AssigneeId;

        [JsonProperty("title")]
        public string Title;

        [JsonProperty("target_project_id")]
        public int? TargetProjectId;        
    }
}
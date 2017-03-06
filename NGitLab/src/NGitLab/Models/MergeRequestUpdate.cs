using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class MergeRequestUpdate
    {        
        [JsonProperty("source_branch")]
        public string SourceBranch;

        [JsonProperty("target_branch")]
        public string TargetBranch;

        [JsonProperty("assignee_id")]
        public int? AssigneeId;

        [JsonProperty("title")]
        public string Title;

        [JsonProperty("state_event")]
        public string NewState; 
    }

    // ReSharper disable InconsistentNaming
    public enum MergeRequestStateEvent
    {
        close,
        reopen,
        merge
    }
}
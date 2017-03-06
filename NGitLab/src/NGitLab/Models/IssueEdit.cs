using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class IssueEdit
    {
        [JsonProperty("id")]
        public int Id;
        
        [JsonProperty("issue_id")]
        public int IssueId;

        [JsonProperty("title")]
        public string Title;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("assignee_id")]
        public int? AssigneeId;

        [JsonProperty("milestone_id")]
        public int? MilestoneId;

        [JsonProperty("labels")]
        public string Labels;

        [JsonProperty("state_event")]
        public string State;
    }
}

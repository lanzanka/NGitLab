using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class IssueCreate
    {
        [JsonProperty("id")]
        public int ProjectId;

        [JsonProperty("title")]
        public string Title;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("assignee_id")]
        public int? AssigneeId;

        [JsonProperty("milestone_id")]
        public int? MileStoneId;

        [JsonProperty("labels")]
        public string Labels;
    }
}

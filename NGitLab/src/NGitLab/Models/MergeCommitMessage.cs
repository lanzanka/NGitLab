using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class MergeCommitMessage
    {
        [JsonProperty("merge_commit_message")]
        public string Message;
    }
}
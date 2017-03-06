using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class FileDelete
    {
        [JsonProperty("file_path")]
        public string Path;
        
        [JsonProperty("branch_name")]
        public string Branch;
        
        [JsonProperty("commit_message")]
        public string CommitMessage;
    }
}
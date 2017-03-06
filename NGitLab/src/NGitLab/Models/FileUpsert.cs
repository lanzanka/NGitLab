using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class FileUpsert
    {
        [JsonProperty("file_path")]
        public string Path; 
        
        [JsonProperty("branch_name")]
        public string Branch;

        [JsonProperty("encoding")]
        public string Encoding;

        [JsonProperty("content")]
        public string Content;
        
        [JsonProperty("commit_message")]
        public string CommitMessage;
    }
}
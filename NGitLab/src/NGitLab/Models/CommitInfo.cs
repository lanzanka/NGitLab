using System;
using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class CommitInfo
    {
        [JsonProperty("id")]
        public Sha1 Id;

        [JsonProperty("parents")]
        public Sha1[] Parents;

        [JsonProperty("tree")]
        public Sha1 Tree;
            
        [JsonProperty("message")]
        public string Message;
            
        [JsonProperty("author")]
        public PersonInfo Author;

        [JsonProperty("committer")]
        public PersonInfo Committer;

        [JsonProperty("authored_date")]
        public DateTime AuthoredDate;

        [JsonProperty("committed_date")]
        public DateTime CommittedDate;
    }
}
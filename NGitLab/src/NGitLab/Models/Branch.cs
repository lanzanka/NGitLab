using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class Branch
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("commit")]
        public CommitInfo Commit;

        [JsonProperty("protected")]
        public bool Protected;
    }
}
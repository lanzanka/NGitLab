using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class Tag
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("commit")]
        public CommitInfo Commit;
    }
}
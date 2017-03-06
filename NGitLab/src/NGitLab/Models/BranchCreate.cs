using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class BranchCreate
    {
        [JsonProperty("branch_name")]
        public string Name;

        [JsonProperty("ref")]
        public string Ref;
    }
}
using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class Diff
    {
        [JsonProperty("diff")]
        public string Difference;

        [JsonProperty("new_path")]
        public string NewPath;

        [JsonProperty("old_path")]
        public string OldPath;

        [JsonProperty("a_mode")]
        public string AMode;

        [JsonProperty("b_mode")]
        public string BMode;

        [JsonProperty("new_file")]
        public bool IsNewFile;

        [JsonProperty("renamed_file")]
        public bool IsRenamedFile;

        [JsonProperty("deleted_file")]
        public bool IsDeletedFile;
    }
}
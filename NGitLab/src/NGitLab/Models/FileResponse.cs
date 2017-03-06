using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class FileResponse
    {
        [JsonProperty("file_name")]
        public string Name { get; set; }

        [JsonProperty("branch_name")]
        public string Branch { get; set; }
    }
}

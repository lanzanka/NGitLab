using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class ArtifactsFile
    {
        [JsonProperty("filename")]
        public string Filename;

        [JsonProperty("size")]
        public long Size;
    }
}
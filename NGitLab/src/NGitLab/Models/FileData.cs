using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class FileData
    {
        [JsonProperty("file_name")]
        public string Name;
        [JsonProperty("file_path")]
        public string Path;
        [JsonProperty("size")]
        public int Size;
        [JsonProperty("encoding")]
        public string Encoding;
        [JsonProperty("content")]
        public string Content;
        [JsonProperty("ref")]
        public string Ref;
        [JsonProperty("blob_id")]
        public string BlobId;
        [JsonProperty("commit_id")]
        public string CommitId;
    }
}
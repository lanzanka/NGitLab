using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class ProjectCreate
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("namespace_id")]
        public string NamespaceId;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("path")]
        public string Path;

        [JsonProperty("issues_enabled")]
        public bool IssuesEnabled;

        [JsonProperty("wall_enabled")]
        public bool WallEnabled;

        [JsonProperty("merge_requests_enabled")]
        public bool MergeRequestsEnabled;

        [JsonProperty("snippets_enabled")]
        public bool SnippetsEnabled;

        [JsonProperty("wiki_enabled")]
        public bool WikiEnabled;

        [JsonProperty("import_url")]
        public string ImportUrl;

        [JsonProperty("visibility_level")]
        public VisibilityLevel VisibilityLevel;
    }
}
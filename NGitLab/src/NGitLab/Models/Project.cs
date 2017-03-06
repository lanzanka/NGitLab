using System;
using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class Project
    {
        public const string Url = "/projects";

        [JsonProperty("id")]
        public int Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("default_branch")]
        public string DefaultBranch;

        [JsonProperty("owner")]
        public User Owner;

        [JsonProperty("public")]
        public bool Public;

        [JsonProperty("path")]
        public string Path;

        [JsonProperty("path_with_namespace")]
        public string PathWithNamespace;

        [JsonProperty("issues_enabled")]
        public bool IssuesEnabled;

        [JsonProperty("merge_requests_enabled")]
        public bool MergeRequestsEnabled;

        [JsonProperty("wall_enabled")]
        public bool WallEnabled;

        [JsonProperty("wiki_enabled")]
        public bool WikiEnabled;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;

        [JsonProperty("ssh_url_to_repo")]
        public string SshUrl;

        [JsonProperty("http_url_to_repo")]
        public string HttpUrl;

        [JsonProperty("namespace")]
        public Namespace Namespace;
    }
}
using System;
using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class ProjectHookUpsert
    {
        [JsonProperty("url")]
        public Uri Url;

        [JsonProperty("push_events")]
        public bool? PushEvents;
        
        [JsonProperty("merge_requests_events")]
        public bool? MergeRequestsEvents;

        [JsonProperty("issues_events")]
        public bool? IssuesEvents;

        [JsonProperty("tag_push_events")]
        public bool? TagPushEvents;

        [JsonProperty("note_events")]
        public bool? NoteEvents;

        [JsonProperty("build_events")]
        public bool? BuildEvents;

        [JsonProperty("pipeline_events")]
        public bool? PipelineEvents;

        [JsonProperty("enable_ssl_verification")]
        public bool? EnableSslVerification;
    }
}
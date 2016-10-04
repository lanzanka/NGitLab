using System;
using System.Runtime.Serialization;

namespace NGitLab.Models
{
    [DataContract]
    public class ProjectHookUpsert
    {
        [DataMember(Name = "url")]
        public Uri Url;

        [DataMember(Name = "push_events")]
        public bool PushEvents;
        
        [DataMember(Name = "merge_requests_events")]
        public bool MergeRequestsEvents;
    }
}

using System.Runtime.Serialization;

namespace NGitLab.Models
{
    [DataContract]
    public class IssueEdit
    {
        [DataMember(Name = "id")]
        public int Id;
        
        [DataMember(Name = "issue_id")]
        public int IssueId;

        [DataMember(Name = "title")]
        public string Title;

        [DataMember(Name = "description")]
        public string Description;

        [DataMember(Name = "assignee_id")]
        public int? AssigneeId;

        [DataMember(Name = "milestone_id")]
        public int? MilestoneId;

        [DataMember(Name = "labels")]
        public string Labels;

        [DataMember(Name = "state_event")]
        public string State;
    }
}

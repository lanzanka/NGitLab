
using System.Runtime.Serialization;
using System.Text;

namespace NGitLab.Models
{
    [DataContract]
    public class IssueCreate
    {
        [DataMember(Name = "id")]
        public int ProjectId;

        [DataMember(Name = "title")]
        public string Title;

        [DataMember(Name = "description")]
        public string Description;

        [DataMember(Name = "assignee_id")]
        public int? AssigneeId;

        [DataMember(Name = "milestone_id")]
        public int? MileStoneId;

        [DataMember(Name = "labels")]
        public string Labels;
    }
}

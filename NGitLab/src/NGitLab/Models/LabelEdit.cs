
using System.Runtime.Serialization;


namespace NGitLab.Models
{
    [DataContract]
    public class LabelEdit
    {
        public LabelEdit() { }

        public LabelEdit(int projectId, Label label)
        {
            Id = projectId;
            Name = label.Name;
        }

        [DataMember(Name = "id")]
        public int Id;

        [DataMember(Name = "name")]
        public string Name;

        [DataMember(Name = "new_name")]
        public string NewName;

        [DataMember(Name = "color")]
        public string Color;
    }
}

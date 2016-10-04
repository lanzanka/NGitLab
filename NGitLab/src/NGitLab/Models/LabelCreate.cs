
using System.Runtime.Serialization;

namespace NGitLab.Models
{
    [DataContract]
    public class LabelCreate
    {
        [DataMember(Name = "id")]
        public int Id;
        
        [DataMember(Name = "name")]
        public string Name;
        
        [DataMember(Name = "color")]
        public string Color;
    }
}

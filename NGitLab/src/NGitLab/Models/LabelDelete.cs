
using System.Runtime.Serialization;

namespace NGitLab.Models
{
    [DataContract]
    public class LabelDelete
    {
        [DataMember(Name = "id")]
        public int Id;
        
        [DataMember(Name = "name")]
        public string Name;
    }
}

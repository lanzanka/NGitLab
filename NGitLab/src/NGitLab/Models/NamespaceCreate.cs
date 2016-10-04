using System.Runtime.Serialization;

namespace NGitLab.Models
{
    [DataContract]
    public class NamespaceCreate
    {
        [DataMember(Name = "name")]
        public string Name;

        [DataMember(Name = "path")]
        public string Path;

        [DataMember(Name = "description")]
        public string Description;
    }
}
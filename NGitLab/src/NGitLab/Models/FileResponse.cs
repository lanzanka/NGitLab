using System.Runtime.Serialization;

namespace NGitLab.Models
{
    [DataContract]
    public class FileResponse
    {
        [DataMember(Name = "file_name")]
        public string Name { get; set; }

        [DataMember(Name = "branch_name")]
        public string Branch { get; set; }
    }
}

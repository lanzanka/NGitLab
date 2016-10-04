using System.Runtime.Serialization;

namespace NGitLab.Models
{
    [DataContract]
    public class FileDelete
    {
        [DataMember(Name = "file_path")]
        public string Path;
        
        [DataMember(Name = "branch_name")]
        public string Branch;
        
        [DataMember(Name = "commit_message")]
        public string CommitMessage;
    }
}
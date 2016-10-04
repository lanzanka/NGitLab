using System.Runtime.Serialization;

namespace NGitLab.Models
{
    [DataContract]
    public class FileUpsert
    {
        [DataMember(Name="file_path")]
        public string Path; 
        
        [DataMember(Name="branch_name")]
        public string Branch;

        [DataMember(Name="encoding")]
        public string Encoding;

        [DataMember(Name="content")]
        public string Content;
        
        [DataMember(Name="commit_message")]
        public string CommitMessage;
    }
}
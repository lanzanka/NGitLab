using System.Runtime.Serialization;

namespace NGitLab.Models
{
    [DataContract]
    public class Error
    {
        [DataMember(Name = "message")]
        public string Message;
    }
}

using System;
using System.Runtime.Serialization;

namespace NGitLab.Models
{
    public enum MemberAccessLevel
    {
        Guest = 10,
        Reporter = 20,
        Developer = 30,
        Master = 40,
        /// <summary>Only valid for groups</summary>
        Owner = 50
    }

    [DataContract]
    public class Member
    {
        [DataMember(Name = "id")]
        public int UserId { get; set; }

        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "access_level")]
        public MemberAccessLevel AccessLevel { get; set; }
    }
}

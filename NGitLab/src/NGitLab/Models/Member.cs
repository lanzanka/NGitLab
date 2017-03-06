using System;
using Newtonsoft.Json;

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

    public class Member
    {
        [JsonProperty("id")]
        public int UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("access_level")]
        public MemberAccessLevel AccessLevel { get; set; }
    }
}

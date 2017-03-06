using System;
using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class User
    {
        public const string Url = "/users";

        [JsonProperty("id")]
        public int Id;

        [JsonProperty("username")]
        public string Username;

        [JsonProperty("email")]
        public string Email;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("skype")]
        public string Skype;

        [JsonProperty("linkedin")]
        public string Linkedin;

        [JsonProperty("twitter")]
        public string Twitter;

        [JsonProperty("provider")]
        public string Provider;

        [JsonProperty("state")]
        public string State;

        [JsonProperty("blocked")]
        public bool Blocked;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;

        [JsonProperty("avatar_url")]
        public string AvatarURL;

        [JsonProperty("bio")]
        public string Bio;

        [JsonProperty("color_scheme_id")]
        public int ColorSchemeId;

        [JsonProperty("theme_id")]
        public int ThemeId;

        [JsonProperty("extern_uid")]
        public string ExternUid;

        [JsonProperty("website_url")]
        public string WebsiteURL;

        [JsonProperty("is_admin")]
        public bool IsAdmin;

        [JsonProperty("can_create_group")]
        public bool CanCreateGroup;

        [JsonProperty("can_create_project")]
        public bool CanCreateProject;
    }
}
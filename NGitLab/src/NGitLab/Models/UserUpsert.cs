using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class UserUpsert
    {
        [JsonProperty("email")]
        public string Email;

        [JsonProperty("password")]
        public string Password;

        [JsonProperty("username")]
        public string Username;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("skype")]
        public string Skype;

        [JsonProperty("linkedin")]
        public string Linkedin;

        [JsonProperty("twitter")]
        public string Twitter;

        [JsonProperty("website_url")]
        public string WebsiteURL;

        [JsonProperty("projects_limit")]
        public int ProjectsLimit;

        [JsonProperty("provider")]
        public string Provider;

        [JsonProperty("bio")]
        public string Bio;

        [JsonProperty("admin")]
        public bool IsAdmin;

        [JsonProperty("can_create_group")]
        public bool CanCreateGroup;
    }
}
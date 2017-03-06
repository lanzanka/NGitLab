using Newtonsoft.Json;

namespace NGitLab.Models
{
    public class Error
    {
        [JsonProperty("message")]
        public string Message;
    }
}

using Newtonsoft.Json;

namespace NGitLab.Models
{

    public class LabelEdit
    {
        public LabelEdit() { }

        public LabelEdit(int projectId, Label label)
        {
            Id = projectId;
            Name = label.Name;
        }

        [JsonProperty("id")]
        public int Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("new_name")]
        public string NewName;

        [JsonProperty("color")]
        public string Color;
    }
}

using System.Text.Json.Serialization;

namespace Clean.Core.Entities
{
    public class Students
    {
        public int id { get; set; }
        public string fullName { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;

        public int courseId { get; set; }

        [JsonIgnore]
        public Courses? Course { get; set; }
    }
}

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Clean.Core.Entities
{
    public class Instructors
    {
        public int id { get; set; }
        public string fullname { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Courses> Courses { get; set; } = new List<Courses>();
    }
}

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Clean.Core.Entities
{
    public class Categories
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Courses> Courses { get; set; } = new List<Courses>();
    }
}

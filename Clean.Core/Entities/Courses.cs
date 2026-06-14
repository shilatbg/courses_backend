using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Clean.Core.Entities
{
    public class Courses
    {
        public int id { get; set; }
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public int hours { get; set; }
        public double price { get; set; }
        public string location { get; set; } = string.Empty;
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public int categoryId { get; set; }

        [JsonIgnore]
        public Categories? Category { get; set; }

        public int instructorId { get; set; }

        [JsonIgnore]
        public Instructors? Instructor { get; set; }

        [JsonIgnore]
        public List<Students> Students { get; set; } = new List<Students>();
    }
}

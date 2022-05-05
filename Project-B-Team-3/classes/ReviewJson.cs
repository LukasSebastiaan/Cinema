using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjectB
{
    public class Review
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Text")]
        public string Text { get; set; }
    }
    internal class ReviewsList
    {
        public List<Review> Reviews;
        private string ReviewJsonName = @$"Data{Path.DirectorySeparatorChar}Reviews.json";

        public void Save()
        {
            var options = new JsonSerializerOptions();
            options.WriteIndented = true;
            File.WriteAllText(ReviewJsonName, JsonSerializer.Serialize(Reviews, options: options));
        }

        public void Load()
        {
            string json = File.ReadAllText(ReviewJsonName);
            Reviews = JsonSerializer.Deserialize<List<Review>>(json);
        }
    }
}

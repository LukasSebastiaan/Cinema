using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjectB
{
    public class Movies
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Discription")]
        public string Discription { get; set; }

        [JsonPropertyName("Genre")]
        public string Genre { get; set; }

        [JsonPropertyName("Time")]
        public string Dates { get; set; }
    }
    internal class MoviesList
    {
        public List<Movies> Movies;

        public MoviesList() 
        {
                
        }

        public void Load()
        {
            string json = File.ReadAllText(@"Data\Movie.json");

            Movies = JsonSerializer.Deserialize<List<Movies>>(json);

        }
    }

}

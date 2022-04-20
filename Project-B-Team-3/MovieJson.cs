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
        public string Password { get; set; }

        [JsonPropertyName("Time")]
        public string Time { get; set; }
    }
    internal class MoviesList
    {
        private List<Movies> Movies;

        public MoviesList()
        {
                
        }

        public void Load()
        {
            string json = File.ReadAllText("Movie.json");

            Movies = JsonSerializer.Deserialize<List<Movies>>(json);

            Console.WriteLine("test: " + Movies[0].Name);
        }
    }

}

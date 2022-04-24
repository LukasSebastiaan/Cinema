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

        [JsonPropertyName("Dates")]
        public List<Dictionary<string, List<string>>> Dates { get; set; }

        
    }
    internal class MoviesList
    {
        public List<Movies> Movies;
        private string MovieJsonName = @$"Data{Path.DirectorySeparatorChar}Movie.json";


        public void Add(string name, string discription, string genre)
        {
            Movies add_Movie = new Movies();
            add_Movie.Name = name;
            add_Movie.Discription = discription;
            add_Movie.Genre = genre;

            Movies.Add(add_Movie);
            Save();
        }

        public int Remove(string name)
        {
            Load();
            for(int i = 0; i < Movies.Count; i++)
            {
                if(Movies[i].Name == name)
                {
                    Movies.RemoveAt(i);
                    Save();
                    return i;
                }
            }
            Save();
            return -1;


        }
        public void Save()
        {
            var options = new JsonSerializerOptions();
            options.WriteIndented = true;
            File.WriteAllText(MovieJsonName, JsonSerializer.Serialize(Movies, options: options));
        }
        public void Load()
        {
            string json = File.ReadAllText(MovieJsonName);

            Movies = JsonSerializer.Deserialize<List<Movies>>(json);

        }
    }

}

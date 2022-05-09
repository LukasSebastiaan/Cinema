﻿using System;
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
        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("Text")]
        public string Text { get; set; }
    }
    internal class ReviewsList
    {
        public List<Review> _reviews;
        private string ReviewJsonName = @$"Data{Path.DirectorySeparatorChar}Reviews.json";
        
        public ReviewsList()
        {
            if (File.Exists(ReviewJsonName))
            {
                if (new FileInfo(ReviewJsonName).Length != 0)
                {
                    Load();
                }
                else
                {
                    _reviews = new List<Review>();
                }
            }
            else
            {
                File.Create(ReviewJsonName);
                _reviews = new List<Review>();
            }
        }

        public void Add(string text)
        {
            Review add_Review = new Review();
            add_Review.Email = Program.information.Member.Email;
            add_Review.Text = text;
            
            _reviews.Add(add_Review);
            Save();
        }

        public int Remove(string email)
        {
            Load();
            for (int i = 0; i < _reviews.Count; i++)
            {
                if (_reviews[i].Email == email)
                {
                    _reviews.RemoveAt(i);
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
            File.WriteAllText(ReviewJsonName, JsonSerializer.Serialize(_reviews, options: options));
        }

        public void Load()
        {
            string json = File.ReadAllText(ReviewJsonName);
            _reviews = JsonSerializer.Deserialize<List<Review>>(json);
        }
    }
}

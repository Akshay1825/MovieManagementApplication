using MovieProjectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace MovieProjectLibrary.Services
{
    public class SerializationHelper
    {
        public static string SerializeMovies(List<Movie> movies)
        {
            return JsonSerializer.Serialize(movies);
        }

        public static List<Movie> DeserializeMovies(string json)
        {
            return JsonSerializer.Deserialize<List<Movie>>(json);
        }

        public static void SaveMoviesToFile(List<Movie> movies, string filePath)
        {
            var json = SerializeMovies(movies);
            File.WriteAllText(filePath, json);
        }

        public static List<Movie> LoadMoviesFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<Movie>();

            var json = File.ReadAllText(filePath);
            return DeserializeMovies(json);
        }
    }
}

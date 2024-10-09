using MovieProjectLibrary.Exceptions;
using MovieProjectLibrary.Models;
using MovieProjectLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProjectLibrary.Controller
{
    public class MovieManager
    {
        static string FilePath = @"C:\Users\Akshay Utekar\source\repos\MovieProjectLibrary\MovieProjectLibrary\bin\Debug\net8.0\movies.json";
        static List<Movie> movies = SerializationHelper.LoadMoviesFromFile(FilePath);
        const int MaxCapacity = 5;

        public static void AddNewMovie(Movie movie)
        {
            if (movies.Count >= MaxCapacity)
                throw new MovieStoreFullException("MovieStore is Full");

            movies.Add(movie);
            SerializationHelper.SaveMoviesToFile(movies, FilePath);
        }

        public static void EditMovie(int id, Movie updatedMovie)
        {
            if (movies.Count == 0)
                throw new MovieStoreEmptyException("MovieStore is Empty");

            var movie = movies.Find(m => m.Id == id);
            if (movie == null)
                throw new InvalidMovieIdException("No Movie exists with this ID");

            movie.Name = updatedMovie.Name;
            movie.Genre = updatedMovie.Genre;
            movie.Year = updatedMovie.Year;

            SerializationHelper.SaveMoviesToFile(movies, FilePath);
        }

        public static Movie FindMovieById(int id)
        {
            if (movies.Count == 0)
                throw new MovieStoreEmptyException("MovieStore is Empty");
            
            var movie = movies.Find(m => m.Id == id);
            if (movie == null)
                throw new InvalidMovieIdException("No Movie Exists with this ID");
            
            return movie;
        }

        public static Movie FindMovieByName(string name)
        {
            if (movies.Count == 0)
                throw new MovieStoreEmptyException("MovieStore is Empty");

            var movie = movies.Find(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (movie == null)
                throw new InvalidMovieIdException("No Movie Exists with this Name");
            
            return movie;
        }

        public static List<Movie> DisplayAllMovies()
        {
            if (movies.Count == 0)
                throw new MovieStoreEmptyException("MovieStore is Empty");
            return new List<Movie>(movies);
        }

        public static void RemoveMovieById(int id)
        {
            if (movies.Count == 0)
                throw new MovieStoreEmptyException("MovieStore is Empty");

            var movie = movies.Find(m => m.Id == id);
            if (movie == null)
                throw new InvalidMovieIdException("No Movie Exists with this ID");

            movies.Remove(movie);
            SerializationHelper.SaveMoviesToFile(movies, FilePath);  
        }

        public static void ClearAllMovies()
        {
            if (movies.Count == 0)
                throw new MovieStoreEmptyException("MovieStore is Empty");

            movies.Clear();
            SerializationHelper.SaveMoviesToFile(movies, FilePath);
        }
    }
}

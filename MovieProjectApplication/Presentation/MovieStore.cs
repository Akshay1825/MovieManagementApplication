using MovieProjectLibrary.Controller;
using MovieProjectLibrary.Exceptions;
using MovieProjectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProjectApplication.Presentation
{
    public class MovieStore
    {
        public static void ShowMenu()
        {
            Console.WriteLine("Welcome To Movie Management Application\n");
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add New Movie");
                Console.WriteLine("2. Edit Movie");
                Console.WriteLine("3. Find Movie By Id");
                Console.WriteLine("4. Find Movie By Name");
                Console.WriteLine("5. Display All Movies");
                Console.WriteLine("6. Remove Movie By Id");
                Console.WriteLine("7. Clear All Movies");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine()); 
                MyTasks(choice);
            }
        }

        static void MyTasks(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddNewMovie();
                    break;
                case 2:
                    EditMovie();
                    break;
                case 3:
                    FindMovieById();
                    break;
                case 4:
                    FindMovieByName();
                    break;
                case 5:
                    DisplayAllMovies();
                    break;
                case 6:
                    RemoveMovieById();
                    break;
                case 7:
                    ClearAllMovies();
                    break;
                case 8:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice.Please try again");
                    break;

            }
        }
        static void AddNewMovie()
        {
            Console.Write("Enter Movie Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Movie Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Movie Genre: ");
            string genre = Console.ReadLine();

            Console.Write("Enter Movie Year: ");
            int year = Convert.ToInt32(Console.ReadLine());

            Movie movie = new Movie
            {   
                Id = id,
                Name = name,
                Genre = genre,
                Year = year 
            };
            try
            {
                MovieManager.AddNewMovie(movie);
                Console.WriteLine("Movie added successfully.");
            }
            catch(MovieStoreFullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void EditMovie()
        {
            Console.Write("Enter Movie Id to edit: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter New Movie Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter New Movie Genre: ");
            string genre = Console.ReadLine();

            Console.Write("Enter New Movie Year: ");
            int year = Convert.ToInt32(Console.ReadLine());

            Movie updatedMovie = new Movie 
            { 
                Name = name, 
                Genre = genre, 
                Year = year 
            };
            try
            {
                MovieManager.EditMovie(id, updatedMovie);
                Console.WriteLine("Movie updated successfully.");
            }
            catch (MovieStoreEmptyException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidMovieIdException ee)
            {
                Console.WriteLine(ee.Message);
            }
        }

        static void FindMovieById()
        {
            Console.Write("Enter Movie Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                Movie movie = MovieManager.FindMovieById(id);

                Console.WriteLine($"Movie Found: {movie.Name}\n" +
                    $"Genre: {movie.Genre}\n" +
                    $"Year: {movie.Year}\n");
            }
            catch (MovieStoreEmptyException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidMovieIdException ee)
            {
                Console.WriteLine(ee.Message);
            }
        }

        static  void FindMovieByName()
        {
            Console.Write("Enter Movie Name: ");
            string name = Console.ReadLine();

            try
            {
                Movie movie = MovieManager.FindMovieByName(name);
                Console.WriteLine($"Movie Found: {movie.Name}\n" +
                    $"Genre: {movie.Genre}\n" +
                    $"Year: {movie.Year}\n");
            }
            catch (MovieStoreEmptyException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidMovieIdException ee)
            {
                Console.WriteLine(ee.Message);
            }
        }

        static void DisplayAllMovies()
        {
            try
            {
                var movies = MovieManager.DisplayAllMovies();
                foreach (var movie in movies)
                {
                    Console.WriteLine($"Id: {movie.Id}\n" +
                        $"Name: {movie.Name}\n" +
                        $"Genre: {movie.Genre}\n" +
                        $"Year: {movie.Year}\n");
                }
            }
            catch (MovieStoreEmptyException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void RemoveMovieById()
        {
            Console.Write("Enter Movie Id to remove: ");
            int id = Convert.ToInt32(Console.ReadLine());

            try
            {
                MovieManager.RemoveMovieById(id);
                Console.WriteLine("Movie removed successfully");
            }
            catch (MovieStoreEmptyException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidMovieIdException ee)
            {
                Console.WriteLine(ee.Message);
            }
        }

        static void ClearAllMovies()
        {
            try
            {
                MovieManager.ClearAllMovies();
                Console.WriteLine("All movies cleared");
            }
            catch (MovieStoreEmptyException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

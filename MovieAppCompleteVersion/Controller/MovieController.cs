using MovieAppLibrary;
using MovieAppLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppCompleteVersion.Controller
{
    internal class MovieController
    {
        public MovieController()
        {
            Start();
        }
        public static void Start()
        {
            DisplayMenu();
        }
        private static void DisplayMenu()
        {
            while (true)
            {
                List<Movie> movies = new List<Movie>();
                MovieManager.LoadMovies();
                try
                {
                    movies = MovieManager.GetMovies();
                }
                catch (Exception ex)
                { }
                //Console.WriteLine("Movies count is :" + movies.Count + "/5");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Movies count is : " + movies.Count + "/5");
                Console.WriteLine("1 = Add movies : \n" +
                    "2 = Display all movies\n" +
                    "3 = Display Movies by year\n" +
                    "4 = Remove movie by name\n" +
                    "5 = Remove all\n" +
                    "6 = Exit");
                Console.Write("Enter your choice :");
                int choice =0;
                try { choice = Convert.ToInt32(Console.ReadLine()); }
                catch(Exception e){  }
                Console.WriteLine("-------------------------------");
                if (choice == 1)
                    SetMovieDetails();
                else if (choice == 2)
                {
                    try
                    {
                        DisplayAll(MovieManager.GetMovies());
                    }
                    catch (ListEmptyException le)
                    {
                        Console.WriteLine(le.Message);
                    }
                }
                else if (choice == 3)
                {
                    try
                    {
                        DisplayByYear(MovieManager.GetMoviesByYear());
                    }
                    catch (ListEmptyException le) { Console.WriteLine(le.Message); }
                }
                else if (choice == 4)
                    try
                    {
                        MovieManager.ClearMoviesByName();
                    }
                    catch (ListEmptyException le)
                    {
                        Console.WriteLine(le.Message);
                    }
                else if (choice == 5)
                {
                    try
                    {
                        MovieManager.DeleteAllMovies();
                    }
                    catch (ListEmptyException le) { Console.WriteLine(le.Message); }
                }
                else if (choice == 6)
                    Environment.Exit(0);
                else
                    Console.WriteLine("Invalid input !!");
            }
        }

        private static Movie SetMovieDetails()
        {
            string Name;
            string genre;
            string director;
            int year;
            Console.Write("Enter Movie Name :");
            Name = Console.ReadLine();
            Console.Write("Enter Movie Genre :");
            genre = Console.ReadLine();
            Console.Write("Enter Movie Director Name :");
            director = Console.ReadLine();
            Console.Write("Enter Movie year of Release :");
            year = Convert.ToInt32(Console.ReadLine());
            Movie movieObject = new Movie(Name, genre, director, year);
            try
            {
                MovieManager.AddMovies(movieObject);
                Console.WriteLine("Movie Added in the list");
            }
            catch (ListFullException le)
            {
                Console.WriteLine(le.Message);
            }
            return movieObject;
        }
        public static void DisplayAll(List<Movie> movies)
        {
            foreach (Movie movieObject in movies)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine(movieObject);
            }
        }
        public static void DisplayByYear(List<Movie> movi)
        {
            for (int i = 0; i < movi.Count; i++)
            {
                Console.WriteLine(movi[i]);
                Console.WriteLine("-------------------------------");
            }
        }

    }
}

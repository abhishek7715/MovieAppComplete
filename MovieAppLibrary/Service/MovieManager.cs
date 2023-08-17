using MovieAppLibrary.Exceptions;
using MovieAppLibrary.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppLibrary
{
    public class MovieManager
    {
        private static List<Movie> movies;
        private static readonly string filePath = ConfigurationManager.AppSettings["path"];
        public const int length = 4;
        public MovieManager()
        {
            movies = new List<Movie>();
            LoadMovies();
        }
        public static void AddMovies(Movie movie)
        {
            if (movies.Count <= length)
            {
                movies.Add(movie);
                SaveMovies();
            }
            else
                throw new ListFullException("List is Full !!");
        }
        public static void ClearMoviesByName()
        {
            if (movies.Count > 0)
            {
                Console.WriteLine("-------------------------------");
                Console.Write("Enter Movie name: ");
                string findMovie = Console.ReadLine();
                File.WriteAllText(filePath, string.Empty);
                for (int i = 0; i < movies.Count; i++)
                {
                    if (movies[i].MovieName == findMovie)
                    {
                        Movie a = movies[i];
                        movies.Remove(a);
                    }
                }
                SaveMovies();
                Console.WriteLine("Movie Deleted Succesfully");
            }
            else
                throw new ListEmptyException("List is Empty !!");
        }
        public static List<Movie> GetMovies()
        {
            if (movies.Count > 0)
            {
                LoadMovies();
                return movies;
            }
            throw new ListEmptyException("List is Empty");
        }
        public static List<Movie> GetMoviesByYear()
        {
            if (movies.Count > 0)
            {
                Console.WriteLine("-------------------------------");
                Console.Write("Enter Movie year : ");
                int movieYear = Convert.ToInt32(Console.ReadLine());//2011
                List<Movie> movi = new List<Movie>();

                for (int i = 0; i < movies.Count; i++)
                {
                    if (movies[i].Year == movieYear)
                        movi.Add(movies[i]);
                }
                return movi;
            }
            throw new ListEmptyException("List is Empty");
        }
        public static void LoadMovies()
        {
            movies = DataSerializer.BinaryDeserializer(filePath);

        }
        public static void SaveMovies()
        {
            DataSerializer.BinarySerializer(movies, filePath);
        }
        public static void DeleteAllMovies()
        {
            if (movies.Count > 0)
            {
                movies.Clear();
                File.WriteAllText(filePath, string.Empty);
                //   SaveMovies();
                Console.WriteLine("All Movie removed from the list !!");
            }
            else { throw new ListEmptyException("List is empty !"); }
        }

    }
}

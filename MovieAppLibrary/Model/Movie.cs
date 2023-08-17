
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppLibrary
{
    [Serializable]
    public class Movie
    {
        public string MovieName { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }

        public Movie() { }
        public Movie(string movieName, string genre, string director, int year)
        {
            MovieName = movieName;
            Genre = genre;
            Director = director;
            Year = year;
        }
        public override string ToString()
        {
            return $"Movie Name : {MovieName}\n" + $"Movie Director : {Director}\n"
                   + $"Movie Genre :{Genre}\n" +
                   $"Year Of Realse :{Year}";
        }

    }
}

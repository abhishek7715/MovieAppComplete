using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppLibrary.Service
{
    public class DataSerializer
    {
        public static void BinarySerializer(List<Movie> data, string filePath)
        {
            using (FileStream file = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                foreach (Movie mov in data)
                {
                    formatter.Serialize(file, mov);
                }
            }
        }
        public static List<Movie> BinaryDeserializer(string filePath)
        {

            List<Movie> movies = new List<Movie>();

            using (FileStream file = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                BinaryFormatter binary = new BinaryFormatter();
                while (file.Position < file.Length)
                {
                    movies.Add((Movie)binary.Deserialize(file));
                }
            }
            return movies;

        }

    }
}

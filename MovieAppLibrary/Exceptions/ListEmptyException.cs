using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppLibrary.Exceptions
{
    public class ListEmptyException:Exception
    {
        public ListEmptyException(string message):base(message) { }
    }
}

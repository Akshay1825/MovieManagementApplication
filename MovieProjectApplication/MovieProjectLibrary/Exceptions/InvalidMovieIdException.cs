using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProjectLibrary.Exceptions
{
    public class InvalidMovieIdException:Exception
    {
        public InvalidMovieIdException(string message) : base(message)
        { }
        
    }
}

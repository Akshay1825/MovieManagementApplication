using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProjectLibrary.Exceptions
{
    public class MovieStoreEmptyException:Exception
    {
        public MovieStoreEmptyException(string message):base (message)
        { }
    }
}

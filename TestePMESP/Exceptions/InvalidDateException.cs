using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestePMESP.Exceptions
{
    public class InvalidDateException : Exception
    {
        public InvalidDateException()
        {

        }

        public InvalidDateException(string message) : base(message)
        {

        }

        public InvalidDateException(string message, Exception internalException) : base(message, internalException)
        {

        }
    }
}

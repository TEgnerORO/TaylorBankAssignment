using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaylorBank.Exceptions
{
    /// <summary>
    /// Exceptions raised for errors in the Customer Class
    /// </summary>
    public class CustomerException:ApplicationException
    {
        /// <summary>
        /// Constructor initializing exception message
        /// </summary>
        /// <param name="message">exception message</param>
        public CustomerException(string message):base(message)
        {
        }

        /// <summary>
        /// Constructor that initializes an exception message and inner exception
        /// </summary>
        /// <param name="message">exception message</param>
        /// <param name="innerException">inner exception</param>
        public CustomerException(string message, Exception innerException):base(message, innerException)
        {
        }
    }
}

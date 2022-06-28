using System;

namespace TaylorBank.Exceptions
{
    /// <summary>
    /// Exceptions raised for errors in the Account Class
    /// </summary>
    public class AccountException : ApplicationException
    {
        /// <summary>
        /// Constructor initializing exception message
        /// </summary>
        /// <param name="message">exception message</param>
        public AccountException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor that initializes an exception message and inner exception
        /// </summary>
        /// <param name="message">exception message</param>
        /// <param name="innerException">inner exception</param>
        public AccountException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}


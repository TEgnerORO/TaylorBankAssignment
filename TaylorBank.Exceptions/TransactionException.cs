using System;

namespace TaylorBank.Exceptions
{
    /// <summary>
    /// Exceptions raised for errors in the Transaction Class
    /// </summary>
    public class TransactionException : ApplicationException
    {
        /// <summary>
        /// Constructor initializing exception message
        /// </summary>
        /// <param name="message">exception message</param>
        public TransactionException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor that initializes an exception message and inner exception
        /// </summary>
        /// <param name="message">exception message</param>
        /// <param name="innerException">inner exception</param>
        public TransactionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

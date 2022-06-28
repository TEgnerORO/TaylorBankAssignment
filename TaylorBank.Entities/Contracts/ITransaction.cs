using System;

namespace TaylorBank.Entities.Contracts
{
    
    /// <summary>
    /// Enumeration for transaction types (Debit or Credit). Account must contain sufficient funds for debit transactions.
    /// </summary>
    public enum TransactionTypes
    {
        Debit,
        Credit,
    }
    /// <summary>
    /// Interface detailing properties and methods of Transaction objects.
    /// </summary>
    public interface ITransaction
    {
        #region Properties
        /// <summary>
        /// The unique Guid identifier for the transaction
        /// </summary>
        Guid TransactionID { get; set; }
        /// <summary>
        /// The date of the transaction.
        /// </summary>
        DateTime TransactionDate { get; set; }
        /// <summary>
        /// The amount of the transaction.
        /// </summary>
        double TransactionAmount { get; set; }
        /// <summary>
        /// Transaction type (Debit or Credit)
        /// </summary>
        TransactionTypes TransactionType { get; set; }

        #endregion

    }
}

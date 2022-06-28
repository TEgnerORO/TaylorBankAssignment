using System;
using TaylorBank.Entities;
using System.Collections.Generic;

namespace TaylorBank.DataAccessLayer.DALContracts
{

    /// <summary>
    /// Interface that represents the transaction data access layer
    /// </summary>
    public interface ITransactionDAL
    {
        #region Methods
        /// <summary>
        /// Retrieves a list of all transactions
        /// </summary>
        /// <returns>List of transactions</returns>
        List<Transaction> GetTransactions();
        /// <summary>
        /// Retrieves a list of transactions which satisfy the passed condition
        /// </summary>
        /// <param name="predicate">lambda expression detailing the condition</param>
        /// <returns>List of transactions</returns>
        List<Transaction> GetTransactionsByCondition(Predicate<Transaction> predicate);
        /// <summary>
        /// Adds a transaction record
        /// </summary>
        /// <param name="transaction">The transaction object to be added</param>
        /// <returns>The unique Guid identifier of the new transaction</returns>
        Guid AddTransaction(Transaction transaction);

        #endregion
    }
}

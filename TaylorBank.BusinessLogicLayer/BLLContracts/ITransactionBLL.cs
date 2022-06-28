using System;
using System.Collections.Generic;
using TaylorBank.Entities;
using TaylorBank.DataAccessLayer;
using TaylorBank.Configuration;
using TaylorBank.Exceptions;

namespace TaylorBank.BusinessLogicLayer.BLLContracts
{
    /// <summary>
    /// Leverages the Data Access Layer CRUD operations.
    /// </summary>
    public interface ITransactionBLL
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
        /// <param name="predicate">logical expression detailing the condition</param>
        /// <returns>Filtered list of transactions</returns>
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

using System;
using System.Collections.Generic;

namespace TaylorBank.Entities.Contracts
{
    /// <summary>
    /// Interface defining the properties and methods of account objects.
    /// </summary>
    public interface IAccount
    {
        #region Properties
        /// <summary>
        /// The unique account number for external use
        /// </summary>
        long AccountNumber { get; set; }
        /// <summary>
        /// The unique Guid account indentifier
        /// </summary>
        Guid AccountID { get; set; }
        /// <summary>
        /// The Customer that owns the account.
        /// </summary>
        Customer AccountOwner { get; set; }
        /// <summary>
        /// The current account balance
        /// </summary>
        double AccountBalance { get; set; }
        /// <summary>
        /// The list of transactions for this account
        /// </summary>
        List<Transaction> Transactions { get;}


        #endregion

        #region Methods
        /// <summary>
        /// Submit a transaction to the account.
        /// </summary>
        /// <param name="transaction">The Transaction object</param>
        /// <returns>True if transaction submitted successfully, else false.</returns>
        bool SubmitTransaction(Transaction transaction);

        #endregion
    }
}

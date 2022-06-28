using System;
using TaylorBank.Entities;
using System.Collections.Generic;

namespace TaylorBank.DataAccessLayer.DALContracts
{

    /// <summary>
    /// Interface that represents the account data access layer
    /// </summary>
    public interface IAccountDAL
    {
        #region Methods
        /// <summary>
        /// Retrieves a list of all customers
        /// </summary>
        /// <returns>List of customers</returns>
        List<Account> GetAccounts();
        /// <summary>
        /// Retrieves a list of customers which satisfy the passed condition
        /// </summary>
        /// <param name="predicate">lambda expression detailing the condition</param>
        /// <returns>List of customers</returns>
        List<Account> GetAccountsByCondition(Predicate<Account> predicate);
        /// <summary>
        /// Adds a customer record
        /// </summary>
        /// <param name="customer">The customer object to be added</param>
        /// <returns>The unique Guid identifier of the new customer</returns>
        Guid AddAccount(Account account);
        /// <summary>
        /// Updates a account record
        /// </summary>
        /// <param name="account">The account object to be updated</param>
        /// <returns>True if update successful, else false</returns>
        bool UpdateAccount(Account account);
        /// <summary>
        /// Deletes a account record
        /// </summary>
        /// <param name="account">The account object to be deleted</param>
        /// <returns>True if deletion successful, else false</returns>
        bool DeleteAccount(Account account);
        /// <summary>
        /// Adds a transaction to the list of account transactions.
        /// </summary>
        /// <param name="account">The Account object</param>
        /// <param name="transaction">The Transaction object</param>
        /// <returns>True if add successful, else false</returns>
        bool AddTransaction(Account account, Transaction transaction);
        /// <summary>
        /// Retrieves a list of all transactions associated with the account
        /// </summary>
        /// <param name="account">The Account object</param>
        /// <returns>List of transactions</returns>
        List<Transaction> GetTransactions(Account account);
        /// <summary>
        /// Retrieves a list of transactions which satisfy the passed condition
        /// </summary>
        /// <param name="account">The Account object</param>
        /// <param name="predicate">lambda expression detailing the condition</param>
        /// <returns>List of transactions</returns>
        List<Transaction> GetTransactionsByCondition(Account account, Predicate<Transaction> predicate);


        #endregion
    }
}

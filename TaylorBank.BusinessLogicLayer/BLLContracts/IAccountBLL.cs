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
    public interface IAccountBLL
    {
        #region Methods
        /// <summary>
        /// Retrieves a list of all accounts
        /// </summary>
        /// <returns>List of accounts</returns>
        List<Account> GetAccounts();
        /// <summary>
        /// Retrieves a list of accounts which satisfy the passed condition
        /// </summary>
        /// <param name="predicate">logical expression detailing the condition</param>
        /// <returns>Filtered list of accounts</returns>
        List<Account> GetAccountsByCondition(Predicate<Account> predicate);
        /// <summary>
        /// Adds a account record
        /// </summary>
        /// <param name="account">The account object to be added</param>
        /// <returns>The unique Guid identifier of the new account</returns>
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
        /// <returns>True if delete successful, else false</returns>
        bool DeleteAccount(Account account);
        /// <summary>
        /// Adds a transaction to the list of account transactions.
        /// </summary>
        /// <param name="account">The Account object</param>
        /// <param name="transaction">The Transaction object</param>
        /// <returns>True if add successful, else false</returns>
        bool AddTransaction(Account account, Transaction transaction);

        /// <summary>
        /// Submits a transaction to the account, updates the account balance, and adds transaction to the account transaction record.
        /// </summary>
        /// <param name="account">The Account object</param>
        /// <param name="transaction">The Transaction object</param>
        /// <returns>True if submit successful, else false</returns>
        bool SubmitTransaction(Account account, Transaction transaction);
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

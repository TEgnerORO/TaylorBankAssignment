using System;
using System.Collections.Generic;
using TaylorBank.Entities;
using TaylorBank.Exceptions;
using TaylorBank.DataAccessLayer.DALContracts;

namespace TaylorBank.DataAccessLayer
{
    /// <summary>
    /// Contains the CRUD operations for account record manipulation
    /// </summary>
    public class AccountDAL : IAccountDAL
    {
        #region Private Fields
        private static List<Account> _accounts;

        #endregion

        #region Private Properties
        private static List<Account> Accounts { get => _accounts; set => _accounts = value; }

        #endregion

        #region Constructors
        static AccountDAL()
        {
            Accounts = new List<Account>();

            ////Initialize some test accounts
            //Accounts.Add(new Account());
            //Accounts.Add(new Account());
        }

        #endregion

        #region CRUD Operations Methods
        public Guid AddAccount(Account account)
        {
            try
            {
                //generate new Guid
                account.AccountID = Guid.NewGuid();

                //add account to the list
                Accounts.Add(account);
                return account.AccountID;
            }
            catch (AccountException) { throw; }
            catch (Exception) { throw; }
        }

        public bool DeleteAccount(Account account)
        {
            try
            {
                //find existing account record with same AccountID
                var toDelete = Accounts.Find(item => item.AccountID == account.AccountID);
                if (toDelete != null)
                {
                    Accounts.Remove(toDelete);
                    return true;
                }
                else return false;
            }
            catch (AccountException) { throw; }
            catch (Exception) { throw; }
        }

        public List<Account> GetAccounts()
        {
            try
            {
                var accountsList = new List<Account>();
                Accounts.ForEach(item => accountsList.Add(item.Clone() as Account));
                return accountsList;
            }
            catch (AccountException) { throw; }
            catch (Exception) { throw; }

        }

        public List<Account> GetAccountsByCondition(Predicate<Account> predicate)
        {
            try
            {
                var accountsList = new List<Account>();
                var filteredAccounts = Accounts.FindAll(predicate);
                filteredAccounts.ForEach(item => accountsList.Add(item.Clone() as Account));
                return accountsList;
            }
            catch (AccountException) { throw; }
            catch (Exception) { throw; }
        }

        public bool UpdateAccount(Account account)
        {
            try
            {
                //find existing account record with same AccountID
                var toUpdate = Accounts.Find(item => item.AccountID == account.AccountID);

                //update all properties of account except unique AccountID
                if (toUpdate != null)
                {
                    toUpdate.AccountBalance = account.AccountBalance;
                    toUpdate.AccountOwner = account.AccountOwner;
                    return true;
                }
                else return false;
            }
            catch (AccountException) { throw; }
            catch (Exception) { throw; }
        }

        public bool AddTransaction(Account account, Transaction transaction)
        {
            try
            {
                //find existing account record with the same AccountID
                var addTo = Accounts.Find(item => item.AccountID == account.AccountID);

                //add the transaction to the list of transactions associated with the account
                if(addTo != null)
                {
                    addTo.Transactions.Add(transaction);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (AccountException) { throw; }
            catch (Exception) { throw; }
        }

        public List<Transaction> GetTransactions(Account account)
        {
            try
            {
                var transactionsList = new List<Transaction>();
                account.Transactions.ForEach(item => transactionsList.Add(item.Clone() as Transaction));
                return transactionsList;
            }
            catch (TransactionException) { throw; }
            catch (Exception) { throw; }

        }

        public List<Transaction> GetTransactionsByCondition(Account account, Predicate<Transaction> predicate)
        {
            try
            {
                var transactionsList = new List<Transaction>();
                var filteredTransactions = account.Transactions.FindAll(predicate);
                filteredTransactions.ForEach(item => transactionsList.Add(item.Clone() as Transaction));
                return transactionsList;
            }
            catch (TransactionException) { throw; }
            catch (Exception) { throw; }
        }

        #endregion
    }
}

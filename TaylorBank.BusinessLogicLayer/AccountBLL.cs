using System;
using System.Collections.Generic;
using TaylorBank.Entities;
using TaylorBank.Entities.Contracts;
using TaylorBank.DataAccessLayer;
using TaylorBank.DataAccessLayer.DALContracts;
using TaylorBank.BusinessLogicLayer.BLLContracts;
using TaylorBank.Exceptions;

namespace TaylorBank.BusinessLogicLayer
{
    /// <summary>
    /// Contains business logic for Account class objects.
    /// </summary>
    public class AccountBLL : IAccountBLL
    {
        #region Private Fields
        private IAccountDAL _accountDAL;

        #endregion

        #region Constructors
        public AccountBLL()
        {
            _accountDAL = new AccountDAL();
        }
        #endregion

        #region Private Properties
        private IAccountDAL AccountDAL
        {
            get => _accountDAL;
            set => _accountDAL = value;
        }

        #endregion

        #region CRUD Methods
        public Guid AddAccount(Account account)
        {
            try
            {

                //Check for highest account number among existing accounts
                var allCustomers = AccountDAL.GetAccounts();
                long maxCode = 0;
                foreach (var cust in allCustomers)
                {
                    if (cust.AccountNumber > maxCode) maxCode = cust.AccountNumber;
                }

                //generate CustomerCode
                if (allCustomers.Count > 0)
                {
                    account.AccountNumber = maxCode + 1;
                }
                else
                {
                    account.AccountNumber = Configuration.Settings.BaseAccountNo + 1;
                }
                return _accountDAL.AddAccount(account);
            }
            catch (AccountException) { throw; }
            catch (Exception) { throw; }
        }

        public bool DeleteAccount(Account account)
        {
            try
            {
                return _accountDAL.DeleteAccount(account);
            }
            catch (AccountException) { throw; }
            catch (Exception) { throw; }
        }

        public List<Account> GetAccounts()
        {
            try
            {
                return _accountDAL.GetAccounts();
            }
            catch (AccountException) { throw; }
            catch (Exception) { throw; }
        }

        public List<Account> GetAccountsByCondition(Predicate<Account> predicate)
        {
            try
            {
                return _accountDAL.GetAccountsByCondition(predicate);
            }
            catch (AccountException) { throw; }
            catch (Exception) { throw; }
        }

        public bool UpdateAccount(Account account)
        {
            try
            {
                return _accountDAL.UpdateAccount(account);
            }
            catch (AccountException) { throw; }
            catch (Exception) { throw; }
        }
        public bool AddTransaction(Account account, Transaction transaction)
        {
            try
            {
                return _accountDAL.AddTransaction(account, transaction);
            }
            catch (AccountException) { throw; }
            catch (Exception) { throw; }
        }
        public List<Transaction> GetTransactions(Account account)
        {
            try
            {
                return _accountDAL.GetTransactions(account);
            }
            catch (TransactionException) { throw; }
            catch (Exception) { throw; }
        }

        public List<Transaction> GetTransactionsByCondition(Account account, Predicate<Transaction> predicate)
        {
            try
            {
                return _accountDAL.GetTransactionsByCondition(account, predicate);
            }
            catch (TransactionException) { throw; }
            catch (Exception) { throw; }
        }

        #endregion

        #region Business Logic Methods
        public bool SubmitTransaction(Account account, Transaction transaction)
        {
            try
            {
                IAccountDAL accountDAL = new AccountDAL();
                switch(transaction.TransactionType)
                {
                    case TransactionTypes.Credit:
                        account.AccountBalance += transaction.TransactionAmount;
                        this.AddTransaction(account, transaction);
                        break;
                    case TransactionTypes.Debit:
                        if (account.AccountBalance >= transaction.TransactionAmount)
                        {
                            account.AccountBalance -= transaction.TransactionAmount;
                            this.AddTransaction(account, transaction);
                        }
                        else
                        {
                            throw new TransactionException("Not enough funds in account to complete transaction");
                        }
                        break;
                }
                return true;
            }
            catch (AccountException) { throw; }
            catch (Exception) { throw; }
        }
        #endregion

    }
}

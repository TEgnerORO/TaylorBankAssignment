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
    /// Contains business logic for Transaction class objects.
    /// </summary>
    public class TransactionBLL : ITransactionBLL
    {
        #region Private Fields
        private ITransactionDAL _transactionDAL;

        #endregion

        #region Constructors
        public TransactionBLL()
        {
            _transactionDAL = new TransactionDAL();
        }
        #endregion

        #region Private Properties
        private ITransactionDAL TransactionDAL
        {
            get => _transactionDAL;
            set => _transactionDAL = value;
        }

        #endregion

        #region CRUD Methods
        public Guid AddTransaction(Transaction account)
        {
            try
            {
                return _transactionDAL.AddTransaction(account);
            }
            catch (TransactionException) { throw; }
            catch (Exception) { throw; }
        }

        public List<Transaction> GetTransactions()
        {
            try
            {
                return _transactionDAL.GetTransactions();
            }
            catch (TransactionException) { throw; }
            catch (Exception) { throw; }
        }

        public List<Transaction> GetTransactionsByCondition(Predicate<Transaction> predicate)
        {
            try
            {
                return _transactionDAL.GetTransactionsByCondition(predicate);
            }
            catch (TransactionException) { throw; }
            catch (Exception) { throw; }
        }

        #endregion

        #region Business Logic Methods
        
        #endregion

    }
}

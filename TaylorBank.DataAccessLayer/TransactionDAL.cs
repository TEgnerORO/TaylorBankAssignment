using System;
using System.Collections.Generic;
using TaylorBank.Entities;
using TaylorBank.Exceptions;
using TaylorBank.DataAccessLayer.DALContracts;

namespace TaylorBank.DataAccessLayer
{
    /// <summary>
    /// Contains the CRUD operations for transaction record manipulation
    /// </summary>
    public class TransactionDAL : ITransactionDAL
    {
        #region Private Fields
        private static List<Transaction> _transactions;

        #endregion

        #region Private Properties
        private static List<Transaction> Transactions { get => _transactions; set => _transactions = value; }

        #endregion

        #region Constructors
        static TransactionDAL()
        {
            Transactions = new List<Transaction>();

            ////Initialize some test transactions
            //Transactions.Add(new Transaction());
            //Transactions.Add(new Transaction());
        }

        #endregion

        #region CRUD Operations Methods
        public Guid AddTransaction(Transaction transaction)
        {
            try
            {
                //generate new Guid
                transaction.TransactionID = Guid.NewGuid();

                //add transaction to the list
                Transactions.Add(transaction);
                return transaction.TransactionID;
            }
            catch (TransactionException) { throw; }
            catch (Exception) { throw; }
        }

        public List<Transaction> GetTransactions()
        {
            try
            {
                var transactionsList = new List<Transaction>();
                Transactions.ForEach(item => transactionsList.Add(item.Clone() as Transaction));
                return transactionsList;
            }
            catch (TransactionException) { throw; }
            catch (Exception) { throw; }

        }

        public List<Transaction> GetTransactionsByCondition(Predicate<Transaction> predicate)
        {
            try
            {
                var transactionsList = new List<Transaction>();
                var filteredTransactions = Transactions.FindAll(predicate);
                filteredTransactions.ForEach(item => transactionsList.Add(item.Clone() as Transaction));
                return transactionsList;
            }
            catch (TransactionException) { throw; }
            catch (Exception) { throw; }
        }

        #endregion
    }
}

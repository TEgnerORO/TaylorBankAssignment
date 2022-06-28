using System;
using System.Collections.Generic;
using TaylorBank.Exceptions;
using TaylorBank.Entities.Contracts;

namespace TaylorBank.Entities
{
    /// <summary>
    /// Class that represents transactions that affect account balances.
    /// </summary>
    public class Transaction:ITransaction, ICloneable
    {
        #region Private Fields
        private Guid _transactionID;
        private DateTime _transactionDate;
        private double _transactionAmount;
        private TransactionTypes transactionType;

        #endregion

        #region Properties
        public Guid TransactionID { get => _transactionID; set => _transactionID = value; }
        public DateTime TransactionDate { get => _transactionDate; set => _transactionDate = value; }
        public double TransactionAmount { get => _transactionAmount; set => _transactionAmount = value; }
        public TransactionTypes TransactionType { get => transactionType; set => transactionType = value; }

        #endregion

        #region Methods
        /// <summary>
        /// Generates a clone of the transaction object
        /// </summary>
        /// <returns>Cloned Transaction object</returns>
        public object Clone()
        {
            return new Transaction()
            {
                TransactionID = this.TransactionID,
                TransactionDate = this.TransactionDate,
                TransactionAmount = this.TransactionAmount,
                TransactionType = this.TransactionType,
            };
        }
        /// <summary>
        /// Generates a clone of the transaction object with the transaction type swapped
        /// </summary>
        /// <returns>Cloned Transaction object</returns>
        public object CloneSwap()
        {
             TransactionTypes swapType;
            if (this.transactionType is TransactionTypes.Credit) swapType = TransactionTypes.Debit;
            else swapType = TransactionTypes.Credit;

            return new Transaction()
            {
                TransactionID = this.TransactionID,
                TransactionDate = this.TransactionDate,
                TransactionAmount = this.TransactionAmount,
                TransactionType = swapType,                
            };
        }

        #endregion


    }
}

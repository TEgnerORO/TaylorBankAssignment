using System;
using System.Collections.Generic;
using TaylorBank.Entities.Contracts;
using TaylorBank.Exceptions;

namespace TaylorBank.Entities
{
    public class Account:IAccount
    {
        #region Private Fields
        private Guid _accountID;
        private long _accountNumber;
        private Customer _accountOwner;
        private double _accountBalance;
        private List<Transaction> _transactions;

        #endregion

        #region Properties
        public Guid AccountID { get => _accountID; set => _accountID = value; }
        public long AccountNumber { get => _accountNumber; set => _accountNumber = value; }
        public Customer AccountOwner { get => _accountOwner; set => _accountOwner = value; }
        public double AccountBalance { get => _accountBalance; set => _accountBalance = value; }
        public List<Transaction> Transactions { get => _transactions;}

        #endregion

        #region Methods
        /// <summary>
        /// Submits a transaction to the account and updates account balance.
        /// </summary>
        /// <param name="transaction">The Transaction object</param>
        /// <returns>True if submit successful, else false.</returns>
        public bool SubmitTransaction(Transaction transaction)
        {
            try
            {
                this._transactions.Add(transaction);
                switch (transaction.TransactionType)
                {
                    case TransactionTypes.Credit:
                        this.AccountBalance += transaction.TransactionAmount;
                        break;
                    case TransactionTypes.Debit:
                        if (this.AccountBalance >= transaction.TransactionAmount)
                        {
                            this.AccountBalance -= transaction.TransactionAmount;
                            break;
                        }
                        else
                        {
                            return false;
                        }
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        
        /// <summary>
        /// Generates a clone of the account object
        /// </summary>
        /// <returns>Cloned Account object</returns>
        public object Clone()
        {
            return new Transaction()
            {
                //TransactionID = this.TransactionID,
                //TransactionDate = this.TransactionDate,
                //TransactionAmount = this.TransactionAmount,
                //TransactionType = this.TransactionType,
            };
        }

        #endregion
    }
}

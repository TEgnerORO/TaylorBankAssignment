using System;
using System.Collections.Generic;
using TaylorBank.Exceptions;
using TaylorBank.Entities.Contracts;

namespace TaylorBank.Entities
{
    public class Transfer : ITransfer, ICloneable
    {
        #region Private Fields
        Guid _transferID;
        Account _sourceAccount, _targetAccount;
        Transaction _transaction;

        #endregion

        #region Properties
        public Account SourceAccount { get => _sourceAccount; set => _sourceAccount = value; }
        public Account TargetAccount { get => _targetAccount; set => _targetAccount = value; }
        public Transaction Transaction { get => _transaction; set => _transaction = value; }
        public Guid TransferID { get => _transferID; set => _transferID = value; }

        #endregion

        #region Methods
        /// <summary>
        /// Creates a clone of the Transfer object
        /// </summary>
        /// <returns>The cloned Transfer object</returns>
        public object Clone()
        {
            return new Transfer()
            {
                SourceAccount = this.SourceAccount,
                TargetAccount = this.TargetAccount,
                Transaction = this.Transaction,
            };
        }

        #endregion

    }
}

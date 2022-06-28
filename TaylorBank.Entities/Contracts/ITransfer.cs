using System;
using System.Collections.Generic;

namespace TaylorBank.Entities.Contracts
{
    /// <summary>
    /// Interface defining the properties and methods of a Transfer object. Transaction must be of Debit type and source account must contain sufficient funds.
    /// </summary>
    public interface ITransfer
    {
        #region Properties
        /// <summary>
        /// Unique Guid identifier for internal use
        /// </summary>
        Guid TransferID { get; set; }
        /// <summary>
        /// Account where the funds are to be drawn from.
        /// </summary>
        Account SourceAccount { get; set; }
        /// <summary>
        /// Account where the funds will be deposited.
        /// </summary>
        Account TargetAccount { get; set; }
        /// <summary>
        /// Transaction details of the Transfer
        /// </summary>
        Transaction Transaction { get; set; }

        #endregion
    }
}

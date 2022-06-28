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
    public interface ITransferBLL
    {
        #region Methods
        /// <summary>
        /// Retrieves a list of all transfers
        /// </summary>
        /// <returns>List of transfers</returns>
        List<Transfer> GetTransfers();
        /// <summary>
        /// Retrieves a list of transfers which satisfy the passed condition
        /// </summary>
        /// <param name="predicate">logical expression detailing the condition</param>
        /// <returns>Filtered list of transfers</returns>
        List<Transfer> GetTransfersByCondition(Predicate<Transfer> predicate);
        /// <summary>
        /// Adds a transfer record
        /// </summary>
        /// <param name="transfer">The transfer object to be added</param>
        /// <returns>The unique Guid identifier of the new transfer</returns>
        Guid AddTransfer(Transfer transfer);
        /// <summary>
        /// Applies the transfer to the source and target accounts.
        /// </summary>
        /// <param name="transfer">The Transfer object</param>
        /// <returns>True if apply successful, else false</returns>
        bool ApplyTransfer(Transfer transfer);
        /// <summary>
        /// Validates fund availability in the source account.
        /// </summary>
        /// <param name="transfer">The Transfer object</param>
        /// <returns>True if transfer is valid, else false</returns>
        bool ValidateTransfer(Transfer transfer);

        #endregion
    }
}

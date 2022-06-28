using System;
using TaylorBank.Entities;
using System.Collections.Generic;

namespace TaylorBank.DataAccessLayer.DALContracts
{

    /// <summary>
    /// Interface that represents the transfer data access layer
    /// </summary>
    public interface ITransferDAL
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
        /// <param name="predicate">lambda expression detailing the condition</param>
        /// <returns>List of transfers</returns>
        List<Transfer> GetTransfersByCondition(Predicate<Transfer> predicate);
        /// <summary>
        /// Adds a transfer record
        /// </summary>
        /// <param name="transfer">The transfer object to be added</param>
        /// <returns>The unique Guid identifier of the new transfer</returns>
        Guid AddTransfer(Transfer transfer);

        #endregion
    }
}

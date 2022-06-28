using System;
using System.Collections.Generic;
using TaylorBank.Entities;
using TaylorBank.Exceptions;
using TaylorBank.DataAccessLayer.DALContracts;

namespace TaylorBank.DataAccessLayer
{
    /// <summary>
    /// Contains the CRUD operations for transfer record manipulation
    /// </summary>
    public class TransferDAL : ITransferDAL
    {
        #region Private Fields
        private static List<Transfer> _transfers;

        #endregion

        #region Private Properties
        private static List<Transfer> Transfers { get => _transfers; set => _transfers = value; }

        #endregion

        #region Constructors
        static TransferDAL()
        {
            Transfers = new List<Transfer>();

            ////Initialize some test transfers
            //Transfers.Add(new Transfer());
            //Transfers.Add(new Transfer());
        }

        #endregion

        #region CRUD Operations Methods
        public Guid AddTransfer(Transfer transfer)
        {
            try
            {
                //generate new Guid
                transfer.TransferID = Guid.NewGuid();

                //add transfer to the list
                Transfers.Add(transfer);
                return transfer.TransferID;
            }
            catch (TransferException) { throw; }
            catch (Exception) { throw; }
        }

        public List<Transfer> GetTransfers()
        {
            try
            {
                var transfersList = new List<Transfer>();
                Transfers.ForEach(item => transfersList.Add(item.Clone() as Transfer));
                return transfersList;
            }
            catch (TransferException) { throw; }
            catch (Exception) { throw; }

        }

        public List<Transfer> GetTransfersByCondition(Predicate<Transfer> predicate)
        {
            try
            {
                var transfersList = new List<Transfer>();
                var filteredTransfers = Transfers.FindAll(predicate);
                filteredTransfers.ForEach(item => transfersList.Add(item.Clone() as Transfer));
                return transfersList;
            }
            catch (TransferException) { throw; }
            catch (Exception) { throw; }
        }

        #endregion
    }
}

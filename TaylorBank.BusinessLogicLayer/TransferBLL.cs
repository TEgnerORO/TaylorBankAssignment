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
    /// Contains business logic for Transfer class objects.
    /// </summary>
    public class TransferBLL : ITransferBLL
    {
        #region Private Fields
        private ITransferDAL _transferDAL;

        #endregion

        #region Constructors
        public TransferBLL()
        {
            _transferDAL = new TransferDAL();
        }
        #endregion

        #region Private Properties
        private ITransferDAL TransferDAL
        {
            get => _transferDAL;
            set => _transferDAL = value;
        }

        #endregion

        #region CRUD Methods
        public Guid AddTransfer(Transfer transfer)
        {
            try
            {
                if (!ValidateTransfer(transfer)) throw new TransferException("Transfer is invalid. See documentation for details.");
                return _transferDAL.AddTransfer(transfer);
            }
            catch (TransferException) { throw; }
            catch (Exception) { throw; }
        }

        public List<Transfer> GetTransfers()
        {
            try
            {
                return _transferDAL.GetTransfers();
            }
            catch (TransferException) { throw; }
            catch (Exception) { throw; }
        }

        public List<Transfer> GetTransfersByCondition(Predicate<Transfer> predicate)
        {
            try
            {
                return _transferDAL.GetTransfersByCondition(predicate);
            }
            catch (TransferException) { throw; }
            catch (Exception) { throw; }
        }

        #endregion

        #region Business Logic Methods
        public bool ValidateTransfer(Transfer transfer)
        {
            try
            {
                if(transfer.SourceAccount != null && transfer.TargetAccount != null && transfer.SourceAccount.AccountBalance >= transfer.Transaction.TransactionAmount && transfer.Transaction.TransactionType is TransactionTypes.Debit)
                {
                    return true;
                }
                else
                {
                    throw new TransferException("Transfer is invalid. See documentation for Transfer requirements.");
                }
            }
            catch (TransferException) { throw; }
            catch (Exception) { throw; }
        }

        public bool ApplyTransfer(Transfer transfer)
        {
            try
            {
                //Validate transfer before application
                if (ValidateTransfer(transfer))
                {
                    IAccountBLL transferBLL = new AccountBLL();
                    //Create Credit transaction for target account
                    Transaction swappedTransaction = (Transaction)transfer.Transaction.CloneSwap();

                    //Apply transaction as debit to source account and credit to target account
                    transferBLL.SubmitTransaction(transfer.SourceAccount, transfer.Transaction);
                    transferBLL.SubmitTransaction(transfer.TargetAccount, swappedTransaction);
                    return true;
                }
                else return false;
            }
            catch (TransferException) { throw; }
            catch (Exception) { throw; }


        }
        #endregion

    }
}

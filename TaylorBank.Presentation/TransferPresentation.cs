using System;
using System.Collections.Generic;
using TaylorBank.Entities;
using TaylorBank.Entities.Contracts;
using TaylorBank.Exceptions;
using TaylorBank.BusinessLogicLayer;
using TaylorBank.BusinessLogicLayer.BLLContracts;


namespace TaylorBank.Presentation
{
    public static class TransferPresentation
    {
        #region Methods

        internal static void AddTransfer()
        {
            try
            {
                IAccountBLL accountBLL = new AccountBLL();
                ITransferBLL transferBLL = new TransferBLL();
                var transfer = new Transfer();
                //Read account details from the user
                Console.WriteLine("\n************CREATE TRANSFER************");

                //Get source account details
                Console.Write("Enter source account number: ");
                long accNum = long.Parse(Console.ReadLine());
                var matches = accountBLL.GetAccountsByCondition(item => item.AccountNumber == accNum);
                if (matches.Count >= 1)
                {
                    transfer.SourceAccount = matches[0];
                    
                    //Get target account details
                    Console.Write("Enter target account number: ");
                    accNum = long.Parse(Console.ReadLine());
                    var accs = accountBLL.GetAccountsByCondition(item => item.AccountNumber == accNum);
                    if (accs.Count >= 1)
                    {
                        transfer.TargetAccount = accs[0];
                        //Get transfer amount
                        Console.Write("Enter Transfer Amount: ");
                        double amount = double.Parse(Console.ReadLine());

                        //Create Transaction
                        transfer.Transaction = new Transaction()
                        {
                            TransactionID = Guid.NewGuid(),
                            TransactionAmount = amount,
                            TransactionDate = DateTime.Now,
                            TransactionType = TransactionTypes.Debit,
                        };

                        transferBLL.ApplyTransfer(transfer);

                        Console.WriteLine("Transfer created successfully.");
                    }
                    else Console.WriteLine("Customer code invalid.");
                }
                else
                {
                    Console.WriteLine("Customer code invalid.");
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }

        }

        internal static void ViewTransfers()
        {
            try
            {
                //Create BL object
                ITransferBLL transferBLL = new TransferBLL();

                Console.WriteLine("\n************TRANSFERS DIRECTORY************");
                Console.Write("Enter Start Date:");
                DateTime startFrom = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter End Date: ");
                DateTime endAt = DateTime.Parse(Console.ReadLine());
                Console.WriteLine();
                //Return account listing
                var allTransfers = transferBLL.GetTransfersByCondition(item => item.Transaction.TransactionDate >= startFrom && item.Transaction.TransactionDate <= endAt);
                //Read accounts and print details
                foreach (Transfer cust in allTransfers)
                {
                    PrintTransfer(cust);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        private static void PrintTransfer(Transfer transfer)
        {
            Console.WriteLine("Transfer Date: " + transfer.Transaction.TransactionDate.ToShortDateString());
            Console.WriteLine("Source Account Number: " + transfer.SourceAccount.AccountNumber);
            Console.WriteLine("Target Account Number: " + transfer.TargetAccount.AccountNumber);
            Console.WriteLine("Transfer Amount: " + transfer.Transaction.TransactionAmount.ToString("C2"));
            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
        }

        #endregion
    }
}

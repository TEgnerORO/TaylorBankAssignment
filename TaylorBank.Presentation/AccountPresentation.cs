using System;
using System.Collections.Generic;
using TaylorBank.Entities;
using TaylorBank.Exceptions;
using TaylorBank.BusinessLogicLayer;
using TaylorBank.BusinessLogicLayer.BLLContracts;


namespace TaylorBank.Presentation
{
    public static class AccountPresentation
    {
        #region Methods

        internal static void AddAccount()
        {
            try
            {
                ICustomerBLL customerBLL = new CustomerBLL();
                var account = new Account();
                //Read account details from the user
                Console.WriteLine("\n************ADD ACCOUNT************");
                
                //Get record of Customer who owns the account
                Console.Write("Enter customer code of account owner: ");
                long customerCode = long.Parse(Console.ReadLine());
                var matches = customerBLL.GetCustomersByCondition(item => item.CustomerCode == customerCode);
                if (matches.Count >= 1)
                {
                    account.AccountOwner = matches[0];
                    //Create BL object
                    IAccountBLL accountBusinessLogicLayer = new AccountBLL();
                    //Add account and get back AccountID
                    Guid accGuid = accountBusinessLogicLayer.AddAccount(account);
                    var newAcc = accountBusinessLogicLayer.GetAccountsByCondition(item => item.AccountID == accGuid);
                    if (newAcc.Count >= 1)
                    {
                        Console.WriteLine("Account Number: " + newAcc[0].AccountNumber);
                        Console.WriteLine("Account added successfully.\n");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong. Account not added.\n");
                    }
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

        internal static void ViewAccounts()
        {
            try
            {
                //Create BL object
                IAccountBLL accountBLL = new AccountBLL();

                //Return account listing
                var allAccounts = accountBLL.GetAccounts();

                Console.WriteLine("\n************ACCOUNT DIRECTORY************");
                //Read accounts and print details
                foreach (Account cust in allAccounts)
                {
                    PrintAccount(cust);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void DeleteAccount()
        {
            try
            {
                //Get account code from user
                Console.WriteLine("\n**********DELETE ACCOUNT**********");
                Console.Write("Enter Account Number: ");
                var code = long.Parse(Console.ReadLine());

                //Search for account with matching code
                IAccountBLL accountBLL = new AccountBLL();
                var matches = accountBLL.GetAccountsByCondition(item => item.AccountNumber == code);

                if (matches.Count >= 1)
                {
                    var toDel = matches[0];
                    if (accountBLL.DeleteAccount(toDel))
                    {
                        Console.WriteLine("Account successfully deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong. Account not deleted.\n");
                    }
                }
                else
                {
                    Console.WriteLine($"Account ({code}) not found.\n");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void UpdateAccount()
        {
            try
            {
                //Get account code from user
                Console.WriteLine("\n**********EDIT ACCOUNT**********");
                Console.Write("Enter Account Number: ");
                var code = long.Parse(Console.ReadLine());

                //Search for account with matching code
                IAccountBLL accountBLL = new AccountBLL();
                ICustomerBLL customerBLL = new CustomerBLL();
                var matches = accountBLL.GetAccountsByCondition(item => item.AccountNumber == code);

                if (matches.Count >= 1)
                {
                    var toUpdate = matches[0];
                    Console.WriteLine("Account found, please enter new details...\n");
                    //Get customer code of new owner and check for existence
                    Console.Write("New Account Owner (customer code): ");
                    long customerCode = long.Parse(Console.ReadLine());
                    var customers = customerBLL.GetCustomersByCondition(item => item.CustomerCode == customerCode);
                    if (matches.Count >= 1)
                    {
                        toUpdate.AccountOwner = customers[0];
                        if (accountBLL.UpdateAccount(toUpdate))
                        {
                            Console.WriteLine("Account update successful.\n");
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong, account not updated.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid customer code.");
                    }                   
                }
                else
                {
                    Console.WriteLine($"Account ({code}) not found.\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void ViewAccountStatement()
        {
            try
            {
                //Get account code from user
                Console.WriteLine("\n**********ACCOUNT STATEMENT**********");
                Console.Write("Enter Account Number: ");
                var code = long.Parse(Console.ReadLine());

                //Search for account with matching code
                IAccountBLL accountBLL = new AccountBLL();
                var matches = accountBLL.GetAccountsByCondition(item => item.AccountNumber == code);

                if (matches.Count >= 1)
                {
                    Console.Write("Enter Start Date:");
                    DateTime startFrom = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter End Date: ");
                    DateTime endAt = DateTime.Parse(Console.ReadLine());

                    Account acc = matches[0];
                    //Get account transactions between the specified dates
                    var txns = accountBLL.GetTransactionsByCondition(acc, item => item.TransactionDate >= startFrom && item.TransactionDate <= endAt);
                    Console.WriteLine($"Transaction History for Account {acc.AccountNumber}:");
                    Console.WriteLine("-------------------------------------");
                    foreach(Transaction tr in txns)
                    {
                        Console.WriteLine($"{tr.TransactionDate.ToShortDateString()}  |  Amount: {tr.TransactionAmount.ToString("C2")} ({tr.TransactionType})");
                    }
                    Console.WriteLine("-------------------------------------");
                }
                else
                {
                    Console.WriteLine("Invalid account number.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        private static void PrintAccount(Account account)
        {
            Console.WriteLine("Account Number: " + account.AccountNumber);
            Console.WriteLine("Account Owner: " + account.AccountOwner.CustomerName + $"(Customer Code: {account.AccountOwner.CustomerCode})");
            Console.WriteLine("Account Balance: " + account.AccountBalance);
            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
        }

        #endregion
    }
}

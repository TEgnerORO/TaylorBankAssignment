using System;
using System.Collections.Generic;
using TaylorBank.Entities;
using TaylorBank.Exceptions;
using TaylorBank.BusinessLogicLayer;
using TaylorBank.BusinessLogicLayer.BLLContracts;


namespace TaylorBank.Presentation
{
    public static class CustomerPresentation
    {
        #region Methods

        internal static void AddCustomer()
        {
            try
            {
                var customer = new Customer();
                //Read customer details from the user
                Console.WriteLine("\n************ADD CUSTOMER************");
                Console.Write("Customer Name: ");
                customer.CustomerName = Console.ReadLine();
                Console.Write("Address: ");
                customer.Address = Console.ReadLine();
                Console.Write("Landmark: ");
                customer.Landmark = Console.ReadLine();
                Console.Write("City: ");
                customer.City = Console.ReadLine();
                Console.Write("Country: ");
                customer.Country = Console.ReadLine();
                Console.Write("Mobile: ");
                customer.Mobile = Console.ReadLine();

                //Create BL object
                ICustomerBLL customerBusinessLogicLayer = new CustomerBLL();
                //Add customer and get back CustomerID
                Guid custGuid = customerBusinessLogicLayer.AddCustomer(customer);
                var newCust = customerBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerID == custGuid);
                if (newCust.Count >= 1)
                {
                    Console.WriteLine("Customer Code: " + newCust[0].CustomerCode);
                    Console.WriteLine("Customer added successfully.\n");
                }
                else
                {
                    Console.WriteLine("Something went wrong. Customer not added.\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
            
        }

        internal static void ViewCustomers()
        {
            try
            {
                //Create BL object
                ICustomerBLL customerBLL = new CustomerBLL();

                //Return customer listing
                var allCustomers = customerBLL.GetCustomers();

                Console.WriteLine("\n************CUSTOMER DIRECTORY************");
                //Read customers and print details
                foreach(Customer cust in allCustomers)
                {
                    PrintCustomer(cust);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void DeleteCustomer()
        {
            try
            {
                //Get customer code from user
                Console.WriteLine("\n**********DELETE CUSTOMER**********");
                Console.Write("Enter Customer Code: ");
                var code = long.Parse(Console.ReadLine());

                //Search for customer with matching code
                ICustomerBLL customerBLL = new CustomerBLL();
                var matches = customerBLL.GetCustomersByCondition(item => item.CustomerCode == code);

                if (matches.Count >=1)
                {
                    var toDel = matches[0];
                    if(customerBLL.DeleteCustomer(toDel))
                    {
                        Console.WriteLine("Customer successfully deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong. Customer not deleted.\n");
                    }
                }
                else
                {
                    Console.WriteLine($"Customer ({code}) not found.\n");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void UpdateCustomer()
        {
            try
            {
                //Get customer code from user
                Console.WriteLine("\n**********UPDATE CUSTOMER**********");
                Console.Write("Enter Customer Code: ");
                var code = long.Parse(Console.ReadLine());

                //Search for customer with matching code
                ICustomerBLL customerBLL = new CustomerBLL();
                var matches = customerBLL.GetCustomersByCondition(item => item.CustomerCode == code);

                if (matches.Count >= 1)
                {
                    var toUpdate = matches[0];
                    Console.WriteLine("Customer found, please enter new details...\n");
                    Console.Write("Customer Name: ");
                    toUpdate.CustomerName = Console.ReadLine();
                    Console.Write("Address: ");
                    toUpdate.Address = Console.ReadLine();
                    Console.Write("Landmark: ");
                    toUpdate.Landmark = Console.ReadLine();
                    Console.Write("City: ");
                    toUpdate.City = Console.ReadLine();
                    Console.Write("Country: ");
                    toUpdate.Country = Console.ReadLine();
                    Console.Write("Mobile: ");
                    toUpdate.Mobile = Console.ReadLine();

                    if (customerBLL.UpdateCustomer(toUpdate))
                    {
                        Console.WriteLine("Customer update successful.\n");
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong, customer not updated.");
                    }
                }
                else
                {
                    Console.WriteLine($"Customer ({code}) not found.\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void SearchCustomers()
        {
            try
            {
                Console.WriteLine("\n**********SEARCH CUSTOMERS**********");
                Console.WriteLine("SEARCH FIELDS:");
                Console.WriteLine("1: Customer Code");
                Console.WriteLine("2: Customer Name");
                Console.WriteLine("3: City");
                Console.WriteLine("4: Country");
                Console.Write("Enter your selection: ");
                var sel = int.Parse(Console.ReadLine());

                //Get list of matching customers by search field
                var matches = new List<Customer>();
                ICustomerBLL customerBLL = new CustomerBLL();
                string searchTerm;
                switch (sel)
                {
                    case 1:
                        Console.Write("\nEnter Customer Code: ");
                        searchTerm = Console.ReadLine();
                        matches = customerBLL.GetCustomersByCondition(item => item.CustomerCode == long.Parse(searchTerm));
                        break;
                    case 2:
                        Console.Write("\nEnter Customer Name: ");
                        searchTerm = Console.ReadLine();
                        matches = customerBLL.GetCustomersByCondition(item => item.CustomerName == searchTerm);
                        break;
                    case 3:
                        Console.Write("\n Enter City: ");
                        searchTerm = Console.ReadLine();
                        matches = customerBLL.GetCustomersByCondition(item => item.City == searchTerm);
                        break;
                    case 4:
                        Console.Write("\n Enter Country: ");
                        searchTerm = Console.ReadLine();
                        matches = customerBLL.GetCustomersByCondition(item => item.Country == searchTerm);
                        break;
                    default:
                        Console.WriteLine("Selection Invalid...");
                        break;
                }
                Console.WriteLine("\nSEARCH RESULTS:\n");
                foreach (Customer cust in matches)
                {
                    PrintCustomer(cust);
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.Write(ex.GetType());
            }
        }

        private static void PrintCustomer(Customer customer)
        {
            Console.WriteLine("Customer Code: " + customer.CustomerCode);
            Console.WriteLine("Customer Name: " + customer.CustomerName);
            Console.WriteLine("Address: " + customer.Address);
            Console.WriteLine("Landmark: " + customer.Landmark);
            Console.WriteLine("City: " + customer.City);
            Console.WriteLine("Country: " + customer.Country);
            Console.WriteLine("Mobile: " + customer.Mobile);
            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
        }

        #endregion
    }
}

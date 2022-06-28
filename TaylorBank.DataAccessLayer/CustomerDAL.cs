using System;
using System.Collections.Generic;
using TaylorBank.Entities;
using TaylorBank.Exceptions;
using TaylorBank.DataAccessLayer.DALContracts;

namespace TaylorBank.DataAccessLayer
{
    /// <summary>
    /// Contains the CRUD operations for customer record manipulation
    /// </summary>
    public class CustomerDAL : ICustomerDAL
    {
        #region Private Fields
        private static List<Customer> _customers;

        #endregion
        
        #region Private Properties
        private static List<Customer> Customers { get => _customers; set => _customers = value; }

        #endregion

        #region Constructors
        static CustomerDAL()
        {
            Customers = new List<Customer>();

            //Initialize some test customers
            Customers.Add(new Customer()
            {
                CustomerID = Guid.NewGuid(),
                CustomerCode = 1001,
                CustomerName = "Taylor",
                Address = "123 Main St",
                Landmark = "Plum Creek",
                City = "Castle Rock",
                Country = "USA",
                Mobile = "0123456789",
            });
            Customers.Add(new Customer()
            {
                CustomerID = Guid.NewGuid(),
                CustomerCode = 1002,
                CustomerName = "Josh",
                Address = "425 Pine St",
                Landmark = "Central",
                City = "Boulder",
                Country = "USA",
                Mobile = "9876543210",
            });
        }
        
        #endregion

        #region CRUD Operations Methods
        public Guid AddCustomer(Customer customer)
        {
            try
            {
                //generate new Guid
                customer.CustomerID = Guid.NewGuid();

                //add customer to the list
                Customers.Add(customer);
                return customer.CustomerID;
            }
            catch(CustomerException) { throw; }
            catch (Exception) { throw; }
        }

        public bool DeleteCustomer(Customer customer)
        {
            try
            {
                //find existing customer record with same CustomerID
                var toDelete = Customers.Find(item => item.CustomerID == customer.CustomerID);
                if (toDelete != null)
                {
                    Customers.Remove(toDelete);
                    return true;
                }
                else return false;
            }
            catch (CustomerException) { throw; }
            catch (Exception) { throw; }
        }

        public List<Customer> GetCustomers()
        {
            try
            {
                var customersList = new List<Customer>();
                Customers.ForEach(item => customersList.Add(item.Clone() as Customer));
                return customersList;
            }
            catch (CustomerException) { throw; }
            catch (Exception) { throw; }

        }

        public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate)
        {
            try
            {
                var customersList = new List<Customer>();
                var filteredCustomers = Customers.FindAll(predicate);
                filteredCustomers.ForEach(item => customersList.Add(item.Clone() as Customer));
                return customersList;
            }
            catch (CustomerException) { throw; }
            catch (Exception) { throw; }
        }

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                //find existing customer record with same CustomerID
                var toUpdate = Customers.Find(item => item.CustomerID == customer.CustomerID);

                //update all properties of customer except unique CustomerID
                if (toUpdate != null)
                {
                    toUpdate.CustomerCode = customer.CustomerCode;
                    toUpdate.CustomerName = customer.CustomerName;
                    toUpdate.Address = customer.Address;
                    toUpdate.City = customer.City;
                    toUpdate.Landmark = customer.Landmark;
                    toUpdate.Country = customer.Country;
                    toUpdate.Mobile = customer.Mobile;
                    return true;
                }
                else return false;
            }
            catch (CustomerException) { throw; }
            catch (Exception) { throw; }
        }

        #endregion
    }
}

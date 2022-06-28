using System;
using System.Collections.Generic;
using TaylorBank.Entities;
using TaylorBank.DataAccessLayer;
using TaylorBank.DataAccessLayer.DALContracts;
using TaylorBank.BusinessLogicLayer.BLLContracts;
using TaylorBank.Exceptions;

namespace TaylorBank.BusinessLogicLayer
{
    /// <summary>
    /// Contains business logic for Customer class objects.
    /// </summary>
    public class CustomerBLL : ICustomerBLL
    {
        #region Private Fields
        private ICustomerDAL _customerDAL;

        #endregion

        #region Constructors
        public CustomerBLL()
        {
            _customerDAL = new CustomerDAL();
        }
        #endregion

        #region Private Properties
        private ICustomerDAL CustomerDAL
        {
            get => _customerDAL;
            set => _customerDAL = value;
        }

        #endregion

        #region CRUD Methods
        public Guid AddCustomer(Customer customer)
        {
            try
            {
                //Check for highest customer number among existing customers
                var allCustomers = CustomerDAL.GetCustomers();
                long maxCode = 0;
                foreach(var cust in allCustomers)
                {
                    if (cust.CustomerCode > maxCode) maxCode = cust.CustomerCode;
                }

                //generate CustomerCode
                if (allCustomers.Count > 0)
                {
                    customer.CustomerCode = maxCode + 1;
                }
                else
                {
                    customer.CustomerCode = Configuration.Settings.BaseCustomerNo + 1;
                }

                return _customerDAL.AddCustomer(customer);
            }
            catch (CustomerException) { throw; }
            catch (Exception) { throw; }
        }

        public bool DeleteCustomer(Customer customer)
        {
            try
            {
                return _customerDAL.DeleteCustomer(customer);
            }
            catch (CustomerException) { throw; }
            catch (Exception) { throw; }
        }

        public List<Customer> GetCustomers()
        {
            try
            {
                return _customerDAL.GetCustomers();
            }
            catch (CustomerException) { throw; }
            catch (Exception) { throw; }            
        }

        public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate)
        {
            try
            {
                return _customerDAL.GetCustomersByCondition(predicate);
            }
            catch (CustomerException) { throw; }
            catch (Exception) { throw; }
        }

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                return _customerDAL.UpdateCustomer(customer);
            }
            catch (CustomerException) { throw; }
            catch (Exception) { throw; }
        }

        #endregion


    }
}

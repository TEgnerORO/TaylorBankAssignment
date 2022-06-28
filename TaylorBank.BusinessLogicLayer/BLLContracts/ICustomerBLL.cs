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
    public interface ICustomerBLL
    {
        #region Methods
        /// <summary>
        /// Retrieves a list of all customers
        /// </summary>
        /// <returns>List of customers</returns>
        List<Customer> GetCustomers();
        /// <summary>
        /// Retrieves a list of customers which satisfy the passed condition
        /// </summary>
        /// <param name="predicate">logical expression detailing the condition</param>
        /// <returns>Filtered list of customers</returns>
        List<Customer> GetCustomersByCondition(Predicate<Customer> predicate);
        /// <summary>
        /// Adds a customer record
        /// </summary>
        /// <param name="customer">The customer object to be added</param>
        /// <returns>The unique Guid identifier of the new customer</returns>
        Guid AddCustomer(Customer customer);
        /// <summary>
        /// Updates a customer record
        /// </summary>
        /// <param name="customer">The customer object to be updated</param>
        /// <returns>True if update successful, else false</returns>
        bool UpdateCustomer(Customer customer);
        /// <summary>
        /// Deletes a customer record
        /// </summary>
        /// <param name="customer">The customer object to be deleted</param>
        /// <returns>True if delete successful, else false</returns>
        bool DeleteCustomer(Customer customer);

        #endregion
    }
}

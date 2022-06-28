using System;
using TaylorBank.Entities;
using System.Collections.Generic;

namespace TaylorBank.DataAccessLayer.DALContracts
{
    
    /// <summary>
    /// Interface that represents the customer data access layer
    /// </summary>
    public interface ICustomerDAL
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
        /// <param name="predicate">lambda expression detailing the condition</param>
        /// <returns>List of customers</returns>
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
        /// <returns>True if deletion successful, else false</returns>
        bool DeleteCustomer(Customer customer);

        #endregion
    }
}

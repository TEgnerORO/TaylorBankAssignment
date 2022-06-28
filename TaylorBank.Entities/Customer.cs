using System;
using TaylorBank.Entities.Contracts;
using TaylorBank.Exceptions;

namespace TaylorBank.Entities
{
    /// <summary>
    /// Represents a customer of the bank.
    /// </summary>
    public class Customer : ICustomer, ICloneable
    {
        #region Private Fields
        private Guid _customerID;
        private long _customerCode;
        private string _customerName, _address, _landmark, _city, _country, _mobile;
        
        #endregion

        #region Public Properties
        public Guid CustomerID { get => _customerID; set => _customerID = value; }
        public long CustomerCode { 
            get => _customerCode; 
            set
            {
                if(value>0)
                {
                    _customerCode = value;
                }
                else
                {
                    throw new CustomerException("Customer code should be a positive number.");
                }
            }
        }
        public string CustomerName { 
            get => _customerName; 
            set
            {
                if (value.Length <= 40 && !string.IsNullOrEmpty(value))
                {
                    _customerName = value;
                }
                else
                {
                    throw new CustomerException("Customer Name should not be null and 40 characters or less");
                }
            }
        }
        public string Address { get => _address; set => _address = value; }
        public string Landmark { get => _landmark; set => _landmark = value; }
        public string City { get => _city; set => _city = value; }
        public string Country { get => _country; set => _country = value; }
        public string Mobile { 
            get => _mobile; 
            set
            {
                if(value.Length==10)
                {
                    _mobile = value;
                }
                else
                {
                    throw new CustomerException("Mobile number should be 10-digit number");
                }
            }
        }

        #endregion

        #region Public Methods

        public object Clone()
        {
            return new Customer()
            {
                CustomerID = this.CustomerID,
                CustomerCode = this.CustomerCode,
                CustomerName = this.CustomerName,
                Address = this.Address,
                Landmark = this.Landmark,
                City = this.City,
                Country = this.Country,
                Mobile = this.Mobile,
            };
        }

        #endregion
    }
}
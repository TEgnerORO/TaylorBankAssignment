using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaylorBank.Entities.Contracts
{
    /// <summary>
    /// Defines the properties and methods of the customer entity.
    /// </summary>
    public interface ICustomer
    {
        #region Properties
        /// <summary>
        /// A unique Guid customer identifier for internal use.
        /// </summary>
        Guid CustomerID { get; set; }
        /// <summary>
        /// Auto-generated code number of the customer.
        /// </summary>
        long CustomerCode { get; set; }
        /// <summary>
        /// Name of the customer
        /// </summary>
        string CustomerName { get; set; }
        /// <summary>
        /// Customer address
        /// </summary>
        string Address { get; set; }
        /// <summary>
        /// Landmark of the customer's address
        /// </summary>
        string Landmark { get; set; }
        /// <summary>
        /// Customer city of residence
        /// </summary>
        string City { get; set; }
        /// <summary>
        /// Customer country of residence
        /// </summary>
        string Country { get; set; }
        /// <summary>
        /// Customer's 10-digit Mobile number
        /// </summary>
        string Mobile { get; set; }

        #endregion
        #region Methods


        #endregion
    }
}

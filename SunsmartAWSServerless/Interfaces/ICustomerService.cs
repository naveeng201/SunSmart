using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SunsmartAWSServerless.EntityModels;
using SunsmartAWSServerless.Models;

namespace SunsmartAWSServerless.Interfaces
{
    public interface ICustomerService
    {
        /// <summary>
        /// Create or update the customer
        /// </summary>
        /// <param name="customerModel"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        TCustomer CreateCustomer(TCustomer customerModel);

        /// <summary>
        /// Fetch the customer details based on given id
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        TCustomer GetCustomer(int customerId);

        /// <summary>
        /// Fetch all customers
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        IEnumerable<TCustomer> GetAllCustomers();

        /// <summary>
        /// Soft delete the customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        bool DeleteCustomer(int customerId);
    }
}

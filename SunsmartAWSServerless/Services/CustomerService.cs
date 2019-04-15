using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SunsmartAWSServerless.DataAccess;
using SunsmartAWSServerless.DataManager;
using SunsmartAWSServerless.EntityModels;
//using SunsmartAWSServerless.EntityModels;
using SunsmartAWSServerless.Interfaces;
using SunsmartAWSServerless.Models;
using SunsmartAWSServerless.Utils;

namespace SunsmartAWSServerless.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<TCustomer> _customerRepository;

        public CustomerService(IRepository<TCustomer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        #region Create/Update cutsomer
        /// <summary>
        /// Create or update the customer
        /// </summary>
        /// <param name="customerModel"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public TCustomer CreateCustomer(TCustomer customer)
        {
            if (customer.Customerid != 0)
            {
                _customerRepository.Insert(customer);
            }
            else
            {
                _customerRepository.Update(customer);
            }
            
            return customer;
        }

        #endregion Create/Update cutsomer

        #region GetCustomer
        /// <summary>
        /// Fetch customer details based on given id
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public TCustomer GetCustomer(int customerId)
        {
            if (customerId == 0)
            {
                return new TCustomer();
            }
            var customer = _customerRepository.Get(customerId);
            return customer;  
        }

        /// <summary>
        /// Fetch all customers
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public IEnumerable<TCustomer> GetAllCustomers()
        {
            var customers = _customerRepository.GetAll();
            return customers;
        }

        #endregion GetCustomer

        #region Delete Customer
        /// <summary>
        /// Soft delete the customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool DeleteCustomer(int customerId)
        {
            var customer = _customerRepository.Get(customerId);
            if (customer == null)
            {
                return false;
            }
            //customer.IsActive = false; //This is a soft delete
            _customerRepository.Update(customer);
            return true;
        }
        public bool DeleteCustomer(TCustomer customer)
        {
            if (customer == null)
            {
                return false;
            }
            //customer.IsActive = false; //This is a soft delete
            _customerRepository.Update(customer);
            return true;
        }
        #endregion Delete customer

        #region Validate user input
        /// <summary>
        /// Validate the user input
        /// </summary>
        /// <param name="customerModel"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private bool ValidateModel(TCustomer customerModel, out string message)
        {
            message = string.Empty;
           if(customerModel == null)
            {
                message = "Invalid Input";
                return false;
            }

           //Return if all properties are empty
            var allStringPropertyValues =
            from property in customerModel.GetType().GetProperties()
            where property.PropertyType == typeof(string) && property.CanRead
            select (string)property.GetValue(customerModel);

            if(allStringPropertyValues.All(value => string.IsNullOrEmpty(value)))
            {
                message = "All fields are empty. Customer could not be added/updated.";
                return false;
            }

            //Check if email is valid or not
            if (!IsValidEmailAddress(customerModel.Emailid))
            {
                message = "Please enter a valid email address";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check if email address is valid
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static bool IsValidEmailAddress(string address) => address != null && new EmailAddressAttribute().IsValid(address);

        #endregion Validate user input


    }
}

using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using SunsmartAWSServerless.EntityModels;
using SunsmartAWSServerless.Interfaces;
using SunsmartAWSServerless.Models;
using SunsmartAWSServerless.Utils;

namespace SunsmartAWSServerless.Controllers
{
    [Route("v1/sunsmartapi/customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        #region HttpPost -> Create/Update customer
        /// <summary>
        /// Create the customer with details obtained from request body
        /// </summary>
        /// <param name="customerModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult createcustomer([FromBody] TCustomer customerModel)
        {
            TCustomer customer = null;
            try
            {
                if (ModelState.IsValid)
                {
                     customer = _customerService.CreateCustomer(customerModel);
                }
                return CustomerAPIResponse(customer);
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return BadRequest(new { status = Constants.Error, message = ex.Message, customer = customer });
            }
        }

        #endregion HttpPost -> Create/Update customer

        #region HttpGet
        /// <summary>
        /// Fetch the customer details based on id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                string message = string.Empty;
                var customers = _customerService.GetAllCustomers();
                return CustomerAPIResponse(customers, message);
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return BadRequest(new { status = Constants.Error, message = Constants.ErrorMessage, user = "" });
            }
        }

        /// <summary>
        /// Fetch the customer details based on id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                string message = string.Empty;
                var customer = _customerService.GetCustomer(id);
                return CustomerAPIResponse(customer, message);
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return BadRequest(new { status = Constants.Error, message = Constants.ErrorMessage, user = "" });
            }
        }
        #endregion HttpGet

        #region HttpDelete

        /// <summary>
        /// Soft delete the customer based on given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult deletecustomer(int id)
        {
            try
            {
                string message = string.Empty;
                var status = _customerService.DeleteCustomer(id);
                return CustomerAPIResponse(null, message);
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return BadRequest(new { status = Constants.Error, message = Constants.ErrorMessage, user = "" });
            }
        }

        #endregion HttpDelete

        #region API Response
        /// <summary>
        /// Generate the responses
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private IActionResult CustomerAPIResponse(object customer, string msg ="")
        {
            if (customer == null)
            {
                return BadRequest(new { status = Constants.Failed, message = msg, customer = "" });
            }
            else
            {
                return Ok(new { status = Constants.Success, message = msg, customer = customer });
            }
        }

        #endregion API response
    }
}

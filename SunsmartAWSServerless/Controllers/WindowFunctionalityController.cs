using System;
using Microsoft.AspNetCore.Mvc;
using SunsmartAWSServerless.EntityModels;
using SunsmartAWSServerless.Interfaces;
using SunsmartAWSServerless.Models;
using SunsmartAWSServerless.Utils;

namespace SunsmartAWSServerless.Controllers
{
    [Route("v1/sunsmartapi/windowfunctionality")]
    public class WindowFunctionalityController : Controller
    {
        private readonly IWindowFunctionalityService _winfuncService;

        public WindowFunctionalityController(IWindowFunctionalityService winfunctionService)
        {
            _winfuncService = winfunctionService;
        }

        #region HttpPost -> Create/Update window functionality
        /// <summary>
        /// Create the window functionality with details obtained from request body
        /// </summary>
        /// <param name="winfuncModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult createwinfunction([FromBody] WindowFunctionalityModel winfuncModel)
        {
            try
            {
                string msg = string.Empty;
                var winfunction = _winfuncService.CreateWinfunction(winfuncModel, out msg);
                return Ok(new { status = (winfunction == null) ? Constants.Failed : Constants.Success, message = msg, windowfunctionality = winfunction });
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return Ok(new { status = Constants.Error, message = Constants.ErrorMessage, windowfunctionality = "" });
            }
        }

        #endregion HttpPost -> Create/Update winfunction

        #region HttpGet
        /// <summary>
        /// Fetch the winfunction details based on id
        /// </summary>
        /// <param name="winfunctionId"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult getwinfunction(int id)
        {
            try
            {
                string msg = string.Empty;
                var winfunction = _winfuncService.GetWinfunction(id, out msg);
                return Ok(new { status = (winfunction == null) ? Constants.Failed : Constants.Success, message = msg, windowfunctionality = winfunction });
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return Ok(new { status = Constants.Error, message = Constants.ErrorMessage, windowfunctionality = "" });
            }
        }

        /// <summary>
        /// Fetch all winfunctions 
        /// </summary>
        /// <param name="winfunctionId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult getallwinfunctions()
        {
            try
            {
                string msg = string.Empty;
                var winfunctions = _winfuncService.GetAllWindowFunctionalities(out msg);
                return Ok(new { status = (winfunctions == null) ? Constants.Failed : Constants.Success, message = msg, windowfunctionality = winfunctions });
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return Ok(new { status = Constants.Error, message = Constants.ErrorMessage, windowfunctionality = "" });
            }
        }

        #endregion HttpGet

        #region HttpDelete

        /// <summary>
        /// Soft delete the winfunction based on given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult deletewinfunction(int id)
        {
            try
            {
                string msg = string.Empty;
                var status = _winfuncService.DeleteWindowsfunctionality(id, out msg);
                return Ok(new { status = (status == true)?Constants.Success : Constants.Failed, message = msg});
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return Ok(new { status = Constants.Error, message = Constants.ErrorMessage, windowfunctionality = "" });
            }
        }

        #endregion HttpDelete

        
    }
}

using System;
using Microsoft.AspNetCore.Mvc;
using SunsmartAWSServerless.EntityModels;
using SunsmartAWSServerless.Interfaces;
using SunsmartAWSServerless.Models;
using SunsmartAWSServerless.Utils;

namespace SunsmartAWSServerless.Controllers
{
    [Route("v1/sunsmartapi/login")]
    public class LoginController : Controller
    {
        private readonly IUserAuthenticationService _userAuthenticationService;

        public LoginController(IUserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
        }

        /// <summary>
        /// Autheticate the user by details obtained from request body
        /// </summary>
        /// <param name="userCredentialModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult authenticateuser([FromBody] UserCredentialModel userCredentialModel)
        {
            try
            {
                string msg = string.Empty;
                var user = _userAuthenticationService.AuthenticateUser(userCredentialModel, out msg);
                return AuthenticationResponse(user, msg);
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = Constants.Error, message = Constants.ErrorMessage, user = "" });
            }
        }

        /// <summary>
        /// Generate the responses
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private IActionResult AuthenticationResponse(TUsers user, string msg)
        {
            if (user == null)
            {
                return NotFound(new { status = Constants.Failed, message = msg, user = "" });
            }
            return Ok(new { status = Constants.Success, message = msg, user = user });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SunsmartAWSServerless.EntityModels;
using SunsmartAWSServerless.Models;

namespace SunsmartAWSServerless.Interfaces
{
    public interface IUserAuthenticationService
    {
         TUsers AuthenticateUser(UserCredentialModel userCredentialModel, out string message);
    }
}

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
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly IRepository<TUsers> _userRepository;
        private readonly IUserDataManager _userDataManager;

        public UserAuthenticationService(IRepository<TUsers> userRepository, IUserDataManager userDataManager)
        {
            _userRepository = userRepository;
            _userDataManager = userDataManager;
        }

        /// <summary>
        /// Autheticate the user
        /// </summary>
        /// <param name="userCredentialModel"></param>
        /// <returns></returns>
        public TUsers AuthenticateUser(UserCredentialModel userCredentialModel, out string message)
        {
            message = string.Empty;
            var users = _userRepository.FindByCondition(x => x.Emailid == userCredentialModel.Email);
            if (users != null && users.Count() > 0) //user is found, now let's decrypt and compare the password
            {
                foreach(var userDetails in users)
                {
                    if(userCredentialModel.Password == CryptoUtil.DecryptStringAES(userDetails.Password))
                    {
                        var user = _userDataManager.LoadUserRoles(userDetails);
                        ClearAttributes(user);
                        message = "User authenticated successfully";
                        return user;
                    }
                }
            }
            message = "User authentication failed";
            return null;
        }

        /// <summary>
        /// Clear the attributes, that we dont want to write in output
        /// </summary>
        /// <param name="user"></param>
        public void ClearAttributes(TUsers user)
        {
            user.Password = null;
            user.Role.TUsers = null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SunsmartAWSServerless.EntityModels;

namespace SunsmartAWSServerless.DataManager
{
    public class UserDataManager : IUserDataManager
    {
        private SunsmartContext context { get; set; }

        public UserDataManager(SunsmartContext context)
        {
            this.context = context;
        }
        public TUsers LoadUserRoles(TUsers user)
        {
            context.Entry(user).Reference(u => u.Role).Load();
            //user.Role.TUsers = null;
            return user;
        }
    }
}

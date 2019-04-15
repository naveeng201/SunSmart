using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SunsmartAWSServerless.EntityModels;

namespace SunsmartAWSServerless.DataManager
{
    public interface IUserDataManager
    {
        TUsers LoadUserRoles(TUsers user);
    }
}

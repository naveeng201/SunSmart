using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SunsmartAWSServerless.DataAccess
{
    public class DataAccessUtil
    {
        IConfiguration _iConfiguration;

        public DataAccessUtil(IConfiguration iConfiguration)
        {
            _iConfiguration = iConfiguration;
        }

        public string GetConnectionString()
        {
            return _iConfiguration["ConnectionString"];
        }
    }
}

using System;
using System.Collections.Generic;

namespace SunsmartAWSServerless.EntityModels
{
    public partial class TUsers
    {
        public int Userid { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public string Emailid { get; set; }
        public string Mobilenumber { get; set; }
        public int Roleid { get; set; }
        public int Companyid { get; set; }

        public TCompanies Company { get; set; }
        public TRoles Role { get; set; }
    }
}

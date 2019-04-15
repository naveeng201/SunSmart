using System;
using System.Collections.Generic;

namespace SunsmartAWSServerless.EntityModels
{
    public partial class TRoles
    {
        public TRoles()
        {
            TUsers = new HashSet<TUsers>();
        }

        public int Roleid { get; set; }
        public string Rolename { get; set; }
        public string Allowedscreenids { get; set; }

        public ICollection<TUsers> TUsers { get; set; }
    }
}

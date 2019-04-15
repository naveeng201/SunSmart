using System;
using System.Collections.Generic;

namespace SunsmartAWSServerless.EntityModels
{
    public partial class TCompanies
    {
        public TCompanies()
        {
            TUsers = new HashSet<TUsers>();
        }

        public int Companyid { get; set; }
        public string Companyname { get; set; }
        public string Companydesc { get; set; }
        public int? Companysuitnumber { get; set; }
        public string Streetname { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Bankname { get; set; }
        public string Accnumber { get; set; }
        public string Routingnumber { get; set; }
        public byte[] Companylogo { get; set; }

        public ICollection<TUsers> TUsers { get; set; }
    }
}

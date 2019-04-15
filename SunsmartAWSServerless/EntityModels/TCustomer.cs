using System;
using System.Collections.Generic;

namespace SunsmartAWSServerless.EntityModels
{
    public partial class TCustomer
    {
        public int Customerid { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Emailid { get; set; }
        public string Mobilenumber { get; set; }
        public string Licensenumber { get; set; }
        public string Suitnumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
       // public bool? IsActive { get; set; }
    }
}

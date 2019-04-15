using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SunsmartAWSServerless.EntityModels;

namespace SunsmartAWSServerless.EntityModels
{
    [ModelMetadataType(typeof(CustomerMetadata))]
    public partial class TCustomer
    {

    }

    public class CustomerMetadata
    {
        public int? Customerid { get; set; }
        [Required]
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        [Required]
        [EmailAddress]
        public string Emailid { get; set; }
        [Phone]
        public string Mobilenumber { get; set; }
        public string Licensenumber { get; set; }
        public string Suitnumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
    }
}

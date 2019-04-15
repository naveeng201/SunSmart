using System;
using System.Collections.Generic;

namespace SunsmartAWSServerless.EntityModels
{
    public partial class TSubscriptionmodel
    {
        public int Subscriptionid { get; set; }
        public int? Numberofyears { get; set; }
        public int? Numberofsalespersons { get; set; }
        public decimal? Subscriptionamout { get; set; }
        public int? Companyint { get; set; }
    }
}

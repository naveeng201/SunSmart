using System;
using System.Collections.Generic;

namespace SunsmartAWSServerless.EntityModels
{
    public partial class TTransactions
    {
        public int Transid { get; set; }
        public DateTime Transdate { get; set; }
        public string Transdesc { get; set; }
        public decimal Amount { get; set; }
        public int? Userid { get; set; }
        public int? Customerid { get; set; }
        public int? Companyid { get; set; }
    }
}

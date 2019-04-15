using System;
using System.Collections.Generic;

namespace SunsmartAWSServerless.EntityModels
{
    public partial class TProjects
    {
        public int Projectid { get; set; }
        public int? Customerid { get; set; }
        public string Projectdesc { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int? Companyid { get; set; }
        public int? Workflowid { get; set; }
        public int? Salesmanid { get; set; }
        public int? Handymanid { get; set; }
        public decimal? Materialcost { get; set; }
        public decimal? Laborcost { get; set; }
        public bool? Isactive { get; set; }
    }
}

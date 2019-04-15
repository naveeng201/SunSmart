using System;
using System.Collections.Generic;

namespace SunsmartAWSServerless.EntityModels
{
    public partial class TCatalogue
    {
        public int Itemid { get; set; }
        public string Itemname { get; set; }
        public byte[] Itempic { get; set; }
        public string Itemdesc { get; set; }
        public int? Winshapeid { get; set; }
        public int? Companyid { get; set; }
        public decimal? Itemprice { get; set; }
        public bool? Isactive { get; set; }
    }
}

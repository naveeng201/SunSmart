using System;
using System.Collections.Generic;

namespace SunsmartAWSServerless.EntityModels
{
    public partial class TMeasurements
    {
        public int Measurementid { get; set; }
        public int? Winshapeid { get; set; }
        public int? Winfuncid { get; set; }
        public byte[] Windowpic { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public string Description { get; set; }
        public int? Projectid { get; set; }
        public int? Itemid { get; set; }
        public bool? Isactive { get; set; }
    }
}

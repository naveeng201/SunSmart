using System;
using System.Collections.Generic;

namespace SunsmartAWSServerless.EntityModels
{
    public partial class TWindowsShape
    {
        public int Winshapeid { get; set; }
        public string Windowshapename { get; set; }
        public byte[] Windowpic { get; set; }
        public string Windowdesc { get; set; }
        public int? Winfuncid { get; set; }
        public int? Companyid { get; set; }
        public bool? Isactive { get; set; }
    }
}

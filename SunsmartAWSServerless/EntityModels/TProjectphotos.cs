using System;
using System.Collections.Generic;

namespace SunsmartAWSServerless.EntityModels
{
    public partial class TProjectphotos
    {
        public int Photoid { get; set; }
        public int? Projectid { get; set; }
        public byte[] Photo { get; set; }
        public string Photodesc { get; set; }
    }
}

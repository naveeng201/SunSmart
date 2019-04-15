using System;
using System.Collections.Generic;

namespace SunsmartAWSServerless.EntityModels
{
    public partial class TUserlocation
    {
        public int Userid { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}

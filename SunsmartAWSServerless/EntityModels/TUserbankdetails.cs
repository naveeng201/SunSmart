using System;
using System.Collections.Generic;

namespace SunsmartAWSServerless.EntityModels
{
    public partial class TUserbankdetails
    {
        public int Recordid { get; set; }
        public int Userid { get; set; }
        public string Bankname { get; set; }
        public string Acctnumber { get; set; }
        public string Routingnumber { get; set; }
    }
}

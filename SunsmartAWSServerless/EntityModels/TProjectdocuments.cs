using System;
using System.Collections.Generic;

namespace SunsmartAWSServerless.EntityModels
{
    public partial class TProjectdocuments
    {
        public int Docid { get; set; }
        public int? Projectid { get; set; }
        public byte[] Document { get; set; }
        public string Docextention { get; set; }
        public string Doctype { get; set; }
    }
}

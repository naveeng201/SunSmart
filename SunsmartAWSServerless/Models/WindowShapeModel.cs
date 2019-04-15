using System;
using Microsoft.AspNetCore.Http;

namespace SunsmartAWSServerless.Models
{
    public class WindowShapeModel
    {
        public int? Winshapeid { get; set; }
        public string Windowshapename { get; set; }
        public byte[] Windowpic { get; set; }
        public string Windowdesc { get; set; }
        public int? Winfuncid { get; set; }
        public int? Companyid { get; set; }
    }
}

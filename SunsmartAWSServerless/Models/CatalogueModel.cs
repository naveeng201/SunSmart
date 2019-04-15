using System;
using Microsoft.AspNetCore.Http;

namespace SunsmartAWSServerless.Models
{
    public class CatalogueModel
    {
        public int ItemId { get; set; }
        public string Itemname { get; set; }
        public byte[] Itempic { get; set; }
        public string Itemdesc { get; set; }
        public int WinshapeId { get; set; }
        public int CompanyId { get; set; }
        public decimal Itemprice { get; set; }
        public IFormFile PicFile { get; set; }
    }
}

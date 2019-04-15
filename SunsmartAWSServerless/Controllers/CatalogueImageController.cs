using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SunsmartAWSServerless.EntityModels;
using SunsmartAWSServerless.Interfaces;
using SunsmartAWSServerless.Models;
using SunsmartAWSServerless.Utils;
using System.Text;
using System.IO;

namespace SunsmartAWSServerless.Controllers
{
    [Route("v1/sunsmartapi/catalogueimage")]
    public class CatalogueImageController : Controller
    {
        private readonly ICatalogueService _catalogueService;
        public CatalogueImageController(ICatalogueService catalogueService)
        {
            _catalogueService = catalogueService;
        }

        /// <summary>
        /// Fetch the catalogue image
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult getCatalogueImage(int id)
        {
            try
            {
                string message = string.Empty;
                var catalogue = _catalogueService.GetCatalogue(id, out message);
                byte[] itemPic = null;
                if (catalogue != null)
                {
                    itemPic = catalogue.Itempic;
                }
                else
                {
                    //! Fetch the image not found picture
                    var defaultCatalogue = _catalogueService.GetImageNotFoundCatalogue();
                    if (defaultCatalogue != null)
                    {
                        itemPic = defaultCatalogue.Itempic;
                    }
                }
                if (itemPic != null)
                {
                    Response.Headers.Add("Content-Disposition", "inline; filename=" + id + ".png");
                    Response.ContentType = "application/image";
                    return new FileContentResult(itemPic, "image/png");
                }
                else
                {
                    return Ok(new { status = Constants.Error, message = message });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { status = Constants.Error, message = Constants.ErrorMessage });
            }
        }
    }

}


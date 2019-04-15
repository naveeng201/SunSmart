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
    [Route("v1/sunsmartapi/catalogue")]
    public class CatalogueController : Controller
    {
        private readonly ICatalogueService _catalogueService;
        public CatalogueController(ICatalogueService catalogueService)
        {
            _catalogueService = catalogueService;
        }

        /// <summary>
        /// Create/update catalogue based on given data
        /// </summary>
        /// <param name="file"></param>
        /// <param name="itemName"></param>
        /// <param name="itemDesc"></param>
        /// <param name="winShapeID"></param>
        /// <param name="companyID"></param>
        /// <param name="itemPrice"></param>
        /// <param name="itemID"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult createcatalogue(IFormFile file, string itemName, string itemDesc,
            int winShapeID, int companyID, decimal itemPrice, int itemID = 0)
        {
            try
            {
                //! Make Model object
                var catalogue = new CatalogueModel()
                {
                    CompanyId = companyID,
                    Itemdesc = itemDesc,
                    ItemId = itemID,
                    Itemname = itemName,
                    Itemprice = itemPrice,
                    WinshapeId = winShapeID,
                    PicFile = file
                };
                if (catalogue.PicFile != null)
                {
                    using (var binaryStream = new BinaryReader(catalogue.PicFile.OpenReadStream()))
                    {
                        byte[] fileData = binaryStream.ReadBytes((int)catalogue.PicFile.Length);
                        catalogue.Itempic = fileData;
                    }
                }
                string strMessage = string.Empty;
                bool bFlag = _catalogueService.CreateCatalogue(catalogue, out strMessage);
                return Ok(new { status = bFlag ? Constants.Success : Constants.Error, message = strMessage });
            }
            catch (Exception ex)
            {
                return Ok(new { status = Constants.Error, message = Constants.ErrorMessage});
            }
        }

        /// <summary>
        /// Fetch the catalogue details based on id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult getcatalogue(int id)
        {
            try
            {
                string message = string.Empty;
                var catalogue = _catalogueService.GetCatalogue(id, out message);
                if(catalogue != null)
                {
                    //clear the image (there is different API call for same)
                    catalogue.Itempic = null;
                }
                return Ok(new { status = catalogue != null ? Constants.Success : Constants.Error, message = message, catalogue = catalogue });
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return Ok(new { status = Constants.Error, message = Constants.ErrorMessage, catalogue = "" });
            }
        }

        /// <summary>
        /// Soft delete the catalogue based on given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult deletecatalogue(int id)
        {
            try
            {
                string message = string.Empty;
                var bFlag = _catalogueService.DeleteCatalogue(id, out message);
                return Ok(new { status = bFlag ? Constants.Success : Constants.Error, message = message });
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return BadRequest(new { status = Constants.Error, message = Constants.ErrorMessage, user = "" });
            }
        }


    }

}

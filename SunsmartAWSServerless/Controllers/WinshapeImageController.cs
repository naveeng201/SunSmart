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
    [Route("v1/sunsmartapi/windowshapeimage")]
    public class WinshapeImageController : Controller
    {
        private readonly IWindowShapeService _winshapeService;
        public WinshapeImageController(IWindowShapeService winshapeService)
        {
            _winshapeService = winshapeService;
        }

        /// <summary>
        /// Fetch the image
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult getwinshapeImage(int id)
        {
            try
            {
                string message = string.Empty;
                var winshape = _winshapeService.GetWindowsShape(id, out message);
                byte[] itemPic = null;
                if (winshape != null)
                {
                    itemPic = winshape.Windowpic;
                }
                else
                {
                    //! Fetch the image not found picture
                    var defaultShape = _winshapeService.GetImageNotFoundWindowShape();
                    if (defaultShape != null)
                    {
                        itemPic = defaultShape.Windowpic;
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
                    return Ok(new { status = Constants.Failed, message = message });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { status = Constants.Error, message = Constants.ErrorMessage });
            }
        }
    }

}


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
    [Route("v1/sunsmartapi/windowshape")]
    public class WindowShapeController : Controller
    {
        private readonly IWindowShapeService _winshapeService;
        public WindowShapeController(IWindowShapeService winshapeService)
        {
            _winshapeService = winshapeService;
        }

        
        [HttpPost]
        public IActionResult createwindowshape(IFormFile file,int winfuncid,
            string windowdesc, int companyID, string windowshapename, int winshapeid = 0)
        {
            try
            {
                //! Make Model object
                var winshape = new WindowShapeModel()
                {
                    Companyid = companyID,
                    Windowdesc = windowdesc,
                    Windowshapename = windowshapename,
                    Winfuncid = winfuncid,
                    Winshapeid = winshapeid
                };
                if (file != null)
                {
                    using (var binaryStream = new BinaryReader(file.OpenReadStream()))
                    {
                        byte[] fileData = binaryStream.ReadBytes((int)file.Length);
                        winshape.Windowpic = fileData;
                    }
                }
                string strMessage = string.Empty;
                var shapeObj = _winshapeService.CreateWinShape(winshape, out strMessage);
                if(shapeObj != null)
                {
                    shapeObj.Windowpic = null;
                }
                return Ok(new { status = shapeObj != null ? Constants.Success : Constants.Failed, message = strMessage, winshape = shapeObj });
            }
            catch (Exception ex)
            {
                return Ok(new { status = Constants.Error, message = Constants.ErrorMessage});
            }
        }

        /// <summary>
        /// Fetch the window shape details based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult getwinshape(int id)
        {
            try
            {
                string message = string.Empty;
                var winshape = _winshapeService.GetWindowsShape(id, out message);
                if(winshape != null)
                {
                    //clear the image (there is different API call for same)
                    winshape.Windowpic = null;
                }
                return Ok(new { status = winshape != null ? Constants.Success : Constants.Failed, message = message, winshape = winshape });
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return Ok(new { status = Constants.Error, message = Constants.ErrorMessage, catalogue = "" });
            }
        }

        /// <summary>
        /// Soft delete the windowshape based on given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult deletewinshape(int id)
        {
            try
            {
                string message = string.Empty;
                var bFlag = _winshapeService.DeleteWinshape(id, out message);
                return Ok(new { status = bFlag ? Constants.Success : Constants.Error, message = message });
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return Ok(new { status = Constants.Error, message = Constants.ErrorMessage, winshape = "" });
            }
        }


    }

}

using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SunsmartAWSServerless.EntityModels;
using SunsmartAWSServerless.Interfaces;
using SunsmartAWSServerless.Models;
using SunsmartAWSServerless.Utils;

namespace SunsmartAWSServerless.Controllers
{
    [Route("v1/sunsmartapi/measurement")]
    public class MeasurementController : Controller
    {
        private readonly IMeasurementService _measurementService;

        public MeasurementController(IMeasurementService measurementService)
        {
            _measurementService = measurementService;
        }

        #region HttpPost -> Create/Update measurement
        /// <summary>
        /// Create the measurement with details obtained from request body
        /// </summary>
        /// <param name="measurementModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult createmeasurement(IFormFile file, int winshapeid, int winfuncid,
            decimal width, decimal height, string description, int projectid, int measurementId = 0)
        {
            try
            {
                byte[] fileData = null;
                if (file != null)
                {
                    using (var binaryStream = new BinaryReader(file.OpenReadStream()))
                    {
                        fileData = binaryStream.ReadBytes((int)file.Length);
                    }
                }
                //! Make Model object
                var measurement = new MeasurementsModel()
                {
                    Measurementid = measurementId,
                    Winshapeid = winshapeid,
                    Winfuncid = winfuncid,
                    Windowpic = fileData,
                    Width = width,
                    Height = height,
                    Description = description,
                    Projectid = projectid
                };
              
                string strMessage = string.Empty;
                var measurementObj = _measurementService.CreateMeasurement(measurement, out strMessage);
                if(measurementObj != null)
                {
                    measurementObj.Windowpic = null;
                }
                return Ok(new { status = measurementObj != null ? Constants.Success : Constants.Failed, message = strMessage, measurement = measurementObj });
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return Ok(new { status = Constants.Error, message = Constants.ErrorMessage, project = "" });
            }
        }

        #endregion HttpPost -> Create/Update measurement

        #region HttpGet
        /// <summary>
        /// Fetch the measurement details based on id
        /// </summary>
        /// <param name="measurementId"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult getmeasurement(int id)
        {
            try
            {
                string msg = string.Empty;
                var measurement = _measurementService.GetMeasurement(id, out msg);
                if(measurement != null)
                {
                    measurement.Windowpic = null;
                }
                return Ok(new { status = (measurement == null) ? Constants.Failed : Constants.Success, message = msg, project = measurement });
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return Ok(new { status = Constants.Error, message = Constants.ErrorMessage, measurement = "" });
            }
        }

        /// <summary>
        /// Fetch all measurements 
        /// </summary>
        /// <param name="measurementId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult getallmeasurements()
        {
            try
            {
                string msg = string.Empty;
                var measurements = _measurementService.GetAllmeasurements(out msg);
                foreach(var item in measurements)
                {
                    item.Windowpic = null;
                }
                return Ok(new { status = (measurements == null) ? Constants.Failed : Constants.Success, message = msg, measurement = measurements });
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return Ok(new { status = Constants.Error, message = Constants.ErrorMessage, measurement = "" });
            }
        }

        #endregion HttpGet

        #region HttpDelete

        /// <summary>
        /// Soft delete the measurement based on given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult deletemeasurement(int id)
        {
            try
            {
                string msg = string.Empty;
                var status = _measurementService.DeleteMeasurement(id, out msg);
                return Ok(new { status = (status == true)?Constants.Success : Constants.Failed, message = msg});
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return Ok(new { status = Constants.Error, message = Constants.ErrorMessage, measurement = "" });
            }
        }

        #endregion HttpDelete

        
    }
}

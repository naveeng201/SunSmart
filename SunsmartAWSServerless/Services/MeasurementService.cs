using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SunsmartAWSServerless.DataAccess;
using SunsmartAWSServerless.DataManager;
using SunsmartAWSServerless.EntityModels;
//using SunsmartAWSServerless.EntityModels;
using SunsmartAWSServerless.Interfaces;
using SunsmartAWSServerless.Models;
using SunsmartAWSServerless.Utils;

namespace SunsmartAWSServerless.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IRepository<TMeasurements> _measurementRepository;

        public MeasurementService(IRepository<TMeasurements> measurementRepository)
        {
            _measurementRepository = measurementRepository;
        }

        #region Create/Update measurement
        public TMeasurements CreateMeasurement(MeasurementsModel measurementModel, out string message)
        {
            message = string.Empty;

            //Map the measurement model to entity model
            TMeasurements measurementEntity = null;
            bool isExisitngmeasurement = (measurementModel.Measurementid != null && measurementModel.Measurementid != 0);

            if (isExisitngmeasurement)
            {
                measurementEntity = _measurementRepository.Get(measurementModel.Measurementid.Value);
                if(measurementEntity == null)
                {
                    message = "No measurements found for update! Please enter a valid measurement id";
                    return null;
                }
            }
            else
            {
                measurementEntity = new TMeasurements();
            }


            //Map the model to entity
            measurementEntity.Winshapeid = measurementModel.Winshapeid;
            measurementEntity.Winfuncid = measurementModel.Winfuncid;
            measurementEntity.Windowpic = measurementModel.Windowpic == null ? measurementEntity == null ? null : measurementEntity.Windowpic : measurementModel.Windowpic;
            measurementEntity.Width = measurementModel.Width;
            measurementEntity.Height = measurementModel.Height;
            measurementEntity.Description = measurementModel.Description;
            measurementEntity.Projectid = measurementModel.Projectid;
            measurementEntity.Itemid = measurementModel.Itemid;
            measurementEntity.Isactive = true;
            

            if (!isExisitngmeasurement)
            {
                _measurementRepository.Insert(measurementEntity);
                message = "Measurement added successfully. Generated measurement Id is " + measurementEntity.Measurementid;
            }
            else
            {
                //Its an existing measurement, update it
                _measurementRepository.Update(measurementEntity);
                message = "Measurement details updated successfully";
            }
            
            return measurementEntity;
        }

        #endregion Create/Update measurement

        #region GetMeasurements
        /// <summary>
        /// Fetch measurement details based on given id
        /// </summary>
        /// <param name="measurementId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public TMeasurements GetMeasurement(int measurementId, out string message)
        {
            message = string.Empty;
            var measurement = _measurementRepository.Get(measurementId);
            message = (measurement == null) ? "Measurement not found" : "Measurement found";
            return measurement;  
        }

        /// <summary>
        /// Fetch all measurements
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public IEnumerable<TMeasurements> GetAllmeasurements(out string message)
        {
            message = string.Empty;
            var measurements = _measurementRepository.FindByCondition(x=>x.Isactive == true).ToList();
            message = (measurements == null || measurements.Count() == 0) ? "No measurements found" : "Total number of measurements found- "+measurements.Count();
            return measurements;
        }

        #endregion GeTMeasurements

        #region Delete measurement
        /// <summary>
        /// Soft delete the measurement
        /// </summary>
        /// <param name="measurementId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool DeleteMeasurement(int measurementId, out string message)
        {
            message = string.Empty;
            var measurement = _measurementRepository.Get(measurementId);
            if (measurement == null)
            {
                message = "No measurements found to delete! Please enter a valid measurement id";
                return false;
            }
            measurement.Isactive = false; //This is a soft delete
            _measurementRepository.Update(measurement);
            message = "measurement deleted successfully!";
            return true;
        }

        #endregion Delete measurement
    }
}

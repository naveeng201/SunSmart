using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SunsmartAWSServerless.EntityModels;
using SunsmartAWSServerless.Models;

namespace SunsmartAWSServerless.Interfaces
{
    public interface IMeasurementService
    {
       
        TMeasurements CreateMeasurement(MeasurementsModel measurementModel, out string message);

        TMeasurements GetMeasurement(int measurementId, out string message);

        IEnumerable<TMeasurements> GetAllmeasurements(out string message);

        bool DeleteMeasurement(int measurementId, out string message);
    }
}

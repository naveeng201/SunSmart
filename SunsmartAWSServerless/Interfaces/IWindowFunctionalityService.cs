using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SunsmartAWSServerless.EntityModels;
using SunsmartAWSServerless.Models;

namespace SunsmartAWSServerless.Interfaces
{
    public interface IWindowFunctionalityService
    {
        /// <summary>
        /// Create or update the window fuctionality
        /// </summary>
        /// <param name="winfuncModel"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        TWindowsfunctionality CreateWinfunction(WindowFunctionalityModel winfuncModel, out string message);

        /// <summary>
        /// Fetch the window functionality details based on given id
        /// </summary>
        /// <param name="winfuncId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        TWindowsfunctionality GetWinfunction(int winfuncId, out string message);

        /// <summary>
        /// Fetch all windows functionalities
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        IEnumerable<TWindowsfunctionality> GetAllWindowFunctionalities(out string message);

        /// <summary>
        /// Soft delete the window functionality
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        bool DeleteWindowsfunctionality(int winfuncId, out string message);
    }
}

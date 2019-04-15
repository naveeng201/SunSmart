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
    public class WindowfunctionalityService : IWindowFunctionalityService
    {
        private readonly IRepository<TWindowsfunctionality> _winfuncRepository;

        public WindowfunctionalityService(IRepository<TWindowsfunctionality> winfuncRepository)
        {
            _winfuncRepository = winfuncRepository;
        }

        #region Create/Update winfunctions
        /// <summary>
        /// Create or update the window functionality
        /// </summary>
        /// <param name="winfuncModel"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public TWindowsfunctionality CreateWinfunction(WindowFunctionalityModel winfuncModel, out string message)
        {
            message = string.Empty;
            if (winfuncModel == null || winfuncModel.FunctionalityName == null || winfuncModel.FunctionalityName.Trim() == string.Empty)
            {
                return null;
            }

            TWindowsfunctionality winfuncEntity = null;
            bool isExisitngItem = (winfuncModel.WindowFuncId != null && winfuncModel.WindowFuncId != 0);

            if (isExisitngItem)
            {
                winfuncEntity = _winfuncRepository.Get(winfuncModel.WindowFuncId.Value);
                if(winfuncEntity == null)
                {
                    message = MessageResource.UpdateInvalidWinfunction;
                    return null;
                }
            }
            else
            {
                winfuncEntity = new TWindowsfunctionality();
            }

            //Map the model to entity
            winfuncEntity.Functionalityname = winfuncModel.FunctionalityName;
            

            if (!isExisitngItem)
            {
                _winfuncRepository.Insert(winfuncEntity);
                message = MessageResource.CreateWinfunction + winfuncEntity.Winfuncid;
            }
            else
            {
                //Its an existing item, update it
                _winfuncRepository.Update(winfuncEntity);
                message = MessageResource.UpdateWinfunction;
            }
            
            return winfuncEntity;
        }

        #endregion Create/Update winfunctions

        #region GetWindowsfunctionality
        /// <summary>
        /// Fetch window functionality details based on given id
        /// </summary>
        /// <param name="winfuncId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public TWindowsfunctionality GetWinfunction(int winfuncId, out string message)
        {
            message = string.Empty;
            var winfunction = _winfuncRepository.Get(winfuncId);
            message = (winfunction == null) ? MessageResource.NotFoundWinfunction : MessageResource.FoundWinfunction;
            return winfunction;  
        }

        /// <summary>
        /// Fetch all Window Functionalities
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public IEnumerable<TWindowsfunctionality> GetAllWindowFunctionalities(out string message)
        {
            message = string.Empty;
            var winfunctions = _winfuncRepository.FindByCondition(x=>x.Isactive == true);
            message = (winfunctions == null || winfunctions.Count() == 0) ? MessageResource.NotFoundAllWinfunction : MessageResource.FoundAllWinfunction + winfunctions.Count();
            return winfunctions;
        }

        #endregion GetWindowsfunctionality

        #region Delete Winfunctions
        /// <summary>
        /// Soft delete the window functionalities
        /// </summary>
        /// <param name="winfuncId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool DeleteWindowsfunctionality(int winfuncId, out string message)
        {
            message = string.Empty;
            var winfunction = _winfuncRepository.Get(winfuncId);
            if (winfunction == null)
            {
                message = MessageResource.DeleteInvalidWinfunction;
                return false;
            }
            winfunction.Isactive = false; //This is a soft delete
            _winfuncRepository.Update(winfunction);
            message = MessageResource.DeleteWinfunction;
            return true;
        }

        #endregion Delete Winfunctions




    }
}

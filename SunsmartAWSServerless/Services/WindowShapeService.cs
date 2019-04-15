using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SunsmartAWSServerless.DataAccess;
using SunsmartAWSServerless.DataManager;
using SunsmartAWSServerless.EntityModels;
using SunsmartAWSServerless.Interfaces;
using SunsmartAWSServerless.Models;
using SunsmartAWSServerless.Utils;

namespace SunsmartAWSServerless.Services
{
    public class WindowShapeService : IWindowShapeService
    {
        private readonly IRepository<TWindowsShape> _winShapeRepository;
        public WindowShapeService(IRepository<TWindowsShape> winShapeRepository)
        {
            _winShapeRepository = winShapeRepository;
        }

        public TWindowsShape CreateWinShape(WindowShapeModel windowShapeModel, out string message)
        {
                //! Do the validation here

                //! TBD --validations

                //! Create or Update the window shape
                bool bNewRecordFlag = false;
                TWindowsShape winshapeEntity = null;
                if (windowShapeModel.Winshapeid == 0 || windowShapeModel.Winshapeid == null) //! New Item
                {
                    winshapeEntity = new TWindowsShape();
                    bNewRecordFlag = true;
                }
                else
                {
                    winshapeEntity = _winShapeRepository.Get(windowShapeModel.Winshapeid.Value);
                    if (winshapeEntity == null)
                    {
                        message = MessageResource.UpdateInvalidWinshape;
                        return null;
                    }
                }
                winshapeEntity.Companyid = windowShapeModel.Companyid.Value;
                winshapeEntity.Isactive = true;
                winshapeEntity.Windowdesc = windowShapeModel.Windowdesc;
                winshapeEntity.Windowpic = windowShapeModel.Windowpic == null ? winshapeEntity == null ? null : winshapeEntity.Windowpic : windowShapeModel.Windowpic;
                winshapeEntity.Winfuncid = windowShapeModel.Winfuncid;
                winshapeEntity.Windowshapename = windowShapeModel.Windowshapename;
                if (bNewRecordFlag)
                {
                    _winShapeRepository.Insert(winshapeEntity);
                    message = MessageResource.CreateWinshape;
                }
                else
                {
                    _winShapeRepository.Update(winshapeEntity);
                    message = MessageResource.UpdateWinshape;
                }
            
            return winshapeEntity;
        }

        /// <summary>
        /// Fetch the window shape details
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public TWindowsShape GetWindowsShape(int itemID, out string message)
        {
                message = string.Empty;
                var winshapeEntity = _winShapeRepository.Get(itemID);
                if (winshapeEntity != null)
                {
                    message = MessageResource.FoundWinshape;
                    return winshapeEntity;
                }
            message = MessageResource.NotFoundWinshape;
            return null;
        }

        /// <summary>
        /// Return image not found catalogue
        /// </summary>
        /// <returns></returns>
        public TWindowsShape GetImageNotFoundWindowShape()
        {
            var winshapeEntity = _winShapeRepository.FindByCondition(x => x.Windowshapename == "SystemImageNotFound").FirstOrDefault();
            return winshapeEntity;
        }

        #region Delete winshape
        /// <summary>
        /// Soft delete the window shape
        /// </summary>
        /// <param name="winShapeId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool DeleteWinshape(int winshapeId, out string message)
        {
            message = string.Empty;
            var winshape = _winShapeRepository.Get(winshapeId);
            if (winshape == null)
            {
                message = MessageResource.DeleteInvalidWinshape;
                return false;
            }
            winshape.Isactive = false; //This is a soft delete
            _winShapeRepository.Update(winshape);
            message = MessageResource.DeleteWinshape;
            return true;
        }

        public IEnumerable<TWindowsShape> GetAllWindowShapes(out string message)
        {
            message = string.Empty;
            var winfunctions = _winShapeRepository.FindByCondition(x => x.Isactive == true);
            message = (winfunctions == null || winfunctions.Count() == 0) ? MessageResource.NotFoundAllWinshapes : MessageResource.FoundAllWinshapes + winfunctions.Count();
            return winfunctions;
        }

        #endregion Delete winshape
    }
}

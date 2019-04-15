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
    public class CatalogueService : ICatalogueService
    {
        private readonly IRepository<TCatalogue> _catalogueRepository;
        public CatalogueService(IRepository<TCatalogue> catalogueRepository)
        {
            _catalogueRepository = catalogueRepository;
        }

        public bool CreateCatalogue(CatalogueModel catalogueModel, out string message)
        {
            try
            {
                //! Do the validation here

                //! TBD --validations

                //! Create or Update the Catalogue
                bool bNewRecordFlag = false;
                TCatalogue catalogueEntity = null;
                if (catalogueModel.ItemId == 0) //! New Item
                {
                    catalogueEntity = new TCatalogue();
                    bNewRecordFlag = true;
                }
                else
                {
                    catalogueEntity = _catalogueRepository.Get(catalogueModel.ItemId);
                    if (catalogueEntity == null)
                    {
                        message = "No Catalogue is found for update! Please enter a valid catalogue id";
                        return false;
                    }
                }
                catalogueEntity.Companyid = catalogueModel.CompanyId;
                catalogueEntity.Itemdesc = catalogueModel.Itemdesc;
                catalogueEntity.Itemname = catalogueModel.Itemname;
                catalogueEntity.Itempic = catalogueModel.Itempic;
                catalogueEntity.Itemprice = catalogueModel.Itemprice;
                catalogueEntity.Isactive = true;
                if (bNewRecordFlag)
                {
                    _catalogueRepository.Insert(catalogueEntity);
                    message = "Catalogue created successfully";
                }
                else
                {
                    _catalogueRepository.Update(catalogueEntity);
                    message = "Catalogue updated successfully";
                }
            }
            catch(Exception ex)
            {
                //! TBD Need to log the exception.
                message = "Error occured in Catalogue transaction "+ex.Message; //! Need to remove ex.Message
                return false;
            }
            return true;
        }

        /// <summary>
        /// Fetch the catalogue details
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public CatalogueModel GetCatalogue(int itemID, out string message)
        {
            try
            {
                message = string.Empty;
                var catalogueEntity = _catalogueRepository.Get(itemID);
                if (catalogueEntity != null)
                {
                    var catalogue = new CatalogueModel()
                    {
                        CompanyId = catalogueEntity.Companyid ?? 0,
                        Itemdesc = catalogueEntity.Itemdesc,
                        ItemId = catalogueEntity.Itemid,
                        Itemname = catalogueEntity.Itemname,
                        Itemprice = catalogueEntity.Itemprice ?? 0,
                        WinshapeId = catalogueEntity.Winshapeid ?? 0,
                        Itempic = catalogueEntity.Itempic

                    };
                    message = "Catalogue Found.";
                    return catalogue;
                }
            }
            catch(Exception)
            {
                //! Need to log the exception.
            }
            message = "No catalogue found for given id.";
            return null;
        }

        /// <summary>
        /// Return image not found catalogue
        /// </summary>
        /// <returns></returns>
        public CatalogueModel GetImageNotFoundCatalogue()
        {
            try
            {
                var catalogueEntity = _catalogueRepository.FindByCondition(x => x.Itemname == "SystemImageNotFound").FirstOrDefault();
                if (catalogueEntity != null)
                {
                    var catalogue = new CatalogueModel()
                    {
                        CompanyId = catalogueEntity.Companyid ?? 0,
                        Itemdesc = catalogueEntity.Itemdesc,
                        ItemId = catalogueEntity.Itemid,
                        Itemname = catalogueEntity.Itemname,
                        Itemprice = catalogueEntity.Itemprice ?? 0,
                        WinshapeId = catalogueEntity.Winshapeid ?? 0,
                        Itempic = catalogueEntity.Itempic

                    };
                    return catalogue;
                }
                return null;
            }
            catch (Exception)
            {
                //! Need to log the exception.
            }
            return null;
        }

        #region Delete Customer
        /// <summary>
        /// Soft delete the catalogue
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool DeleteCatalogue(int catalogueId, out string message)
        {
            message = string.Empty;
            var catalogue = _catalogueRepository.Get(catalogueId);
            if (catalogue == null)
            {
                message = "No catalogue found to delete! Please enter a valid catalogue id";
                return false;
            }
            catalogue.Isactive = false; //This is a soft delete
            _catalogueRepository.Update(catalogue);
            message = "Catalogue deleted successfully!";
            return true;
        }

        #endregion Delete customer
    }
}

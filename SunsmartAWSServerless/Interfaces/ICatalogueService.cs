using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SunsmartAWSServerless.EntityModels;
using SunsmartAWSServerless.Models;

namespace SunsmartAWSServerless.Interfaces
{
    public interface ICatalogueService
    {
        /// <summary>
        /// Creates the catalogue.
        /// </summary>
        /// <returns><c>true</c>, if catalogue was created, <c>false</c> otherwise.</returns>
        /// <param name="catalogue">Catalogue.</param>
        /// <param name="message">Message.</param>
        bool CreateCatalogue(CatalogueModel catalogue, out string message);

        CatalogueModel GetCatalogue(int itemID, out string message);

        CatalogueModel GetImageNotFoundCatalogue();

        bool DeleteCatalogue(int catalogueId, out string message);
    }
}

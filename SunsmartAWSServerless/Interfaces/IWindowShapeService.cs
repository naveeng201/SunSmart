using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SunsmartAWSServerless.EntityModels;
using SunsmartAWSServerless.Models;

namespace SunsmartAWSServerless.Interfaces
{
    public interface IWindowShapeService
    {
        TWindowsShape CreateWinShape(WindowShapeModel windowShapeModel, out string message);

        TWindowsShape GetWindowsShape(int itemID, out string message);

        IEnumerable<TWindowsShape> GetAllWindowShapes(out string message);

        TWindowsShape GetImageNotFoundWindowShape();

        bool DeleteWinshape(int winshapeId, out string message);
    }
}

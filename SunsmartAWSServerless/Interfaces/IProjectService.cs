using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SunsmartAWSServerless.EntityModels;
using SunsmartAWSServerless.Models;

namespace SunsmartAWSServerless.Interfaces
{
    public interface IProjectService
    {
       
        TProjects CreateProject(ProjectModel projectModel, out string message);

        TProjects GetProject(int projectId, out string message);

        IEnumerable<TProjects> GetAllProjects(out string message);

        bool DeleteProjects(int projectId, out string message);
    }
}

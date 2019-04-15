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
    public class ProjectService : IProjectService
    {
        private readonly IRepository<TProjects> _projectRepository;

        public ProjectService(IRepository<TProjects> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        #region Create/Update project
        public TProjects CreateProject(ProjectModel projectModel, out string message)
        {
            message = string.Empty;

            //Map the project model to entity model
            TProjects projectEntity = null;
            bool isExisitngProject = (projectModel.Projectid != null && projectModel.Projectid != 0);

            if (isExisitngProject)
            {
                projectEntity = _projectRepository.Get(projectModel.Projectid.Value);
                if(projectEntity == null)
                {
                    message = "No projects found for update! Please enter a valid project id";
                    return null;
                }
            }
            else
            {
                projectEntity = new TProjects();
            }

            //Map the model to entity
            projectEntity.Customerid = projectModel.Customerid;
            projectEntity.Projectdesc = projectModel.Projectdesc;
            projectEntity.Startdate = projectModel.Startdate;
            projectEntity.Enddate = projectModel.Enddate;
            projectEntity.Companyid = projectModel.Companyid;
            projectEntity.Workflowid = projectModel.Workflowid;
            projectEntity.Salesmanid = projectModel.Salesmanid;
            projectEntity.Handymanid = projectModel.Handymanid;
            projectEntity.Materialcost = projectModel.Materialcost;
            projectEntity.Laborcost = projectModel.Laborcost;

            projectEntity.Isactive = true;
            

            if (!isExisitngProject)
            {
                _projectRepository.Insert(projectEntity);
                message = "Project added successfully. Generated project Id is " + projectEntity.Projectid;
            }
            else
            {
                //Its an existing project, update it
                _projectRepository.Update(projectEntity);
                message = "Project details updated successfully";
            }
            
            return projectEntity;
        }

        #endregion Create/Update project

        #region GetProjects
        /// <summary>
        /// Fetch project details based on given id
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public TProjects GetProject(int projectId, out string message)
        {
            message = string.Empty;
            var project = _projectRepository.Get(projectId);
            message = (project == null) ? "Project not found" : "Project found";
            return project;  
        }

        /// <summary>
        /// Fetch all projects
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public IEnumerable<TProjects> GetAllProjects(out string message)
        {
            message = string.Empty;
            var projects = _projectRepository.FindByCondition(x=>x.Isactive == true).ToList();
            message = (projects == null || projects.Count() == 0) ? "No projects found" : "Total number of projects found- "+projects.Count();
            return projects;
        }

        #endregion GetProjects

        #region Delete project
        /// <summary>
        /// Soft delete the project
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool DeleteProjects(int projectId, out string message)
        {
            message = string.Empty;
            var project = _projectRepository.Get(projectId);
            if (project == null)
            {
                message = "No projects found to delete! Please enter a valid project id";
                return false;
            }
            project.Isactive = false; //This is a soft delete
            _projectRepository.Update(project);
            message = "Project deleted successfully!";
            return true;
        }

        #endregion Delete project
    }
}

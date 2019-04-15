using System;
using Microsoft.AspNetCore.Mvc;
using SunsmartAWSServerless.EntityModels;
using SunsmartAWSServerless.Interfaces;
using SunsmartAWSServerless.Models;
using SunsmartAWSServerless.Utils;

namespace SunsmartAWSServerless.Controllers
{
    [Route("v1/sunsmartapi/project")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        #region HttpPost -> Create/Update project
        /// <summary>
        /// Create the project with details obtained from request body
        /// </summary>
        /// <param name="projectModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult createProject([FromBody] ProjectModel projectModel)
        {
            try
            {
                string msg = string.Empty;
                var project = _projectService.CreateProject(projectModel, out msg);
                return Ok(new { status = (project == null) ? Constants.Failed : Constants.Success, message = msg, project = project });
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return Ok(new { status = Constants.Error, message = Constants.ErrorMessage, project = "" });
            }
        }

        #endregion HttpPost -> Create/Update Project

        #region HttpGet
        /// <summary>
        /// Fetch the Project details based on id
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult getProject(int id)
        {
            try
            {
                string msg = string.Empty;
                var project = _projectService.GetProject(id, out msg);
                return Ok(new { status = (project == null) ? Constants.Failed : Constants.Success, message = msg, project = project });
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return Ok(new { status = Constants.Error, message = Constants.ErrorMessage, project = "" });
            }
        }

        /// <summary>
        /// Fetch all Projects 
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult getallProjects()
        {
            try
            {
                string msg = string.Empty;
                var projects = _projectService.GetAllProjects(out msg);
                return Ok(new { status = (projects == null) ? Constants.Failed : Constants.Success, message = msg, project = projects });
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return Ok(new { status = Constants.Error, message = Constants.ErrorMessage, project = "" });
            }
        }

        #endregion HttpGet

        #region HttpDelete

        /// <summary>
        /// Soft delete the Project based on given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult deleteProject(int id)
        {
            try
            {
                string msg = string.Empty;
                var status = _projectService.DeleteProjects(id, out msg);
                return Ok(new { status = (status == true) ? Constants.Success : Constants.Failed, message = msg });
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                return Ok(new { status = Constants.Error, message = Constants.ErrorMessage, project = "" });
            }
        }

        #endregion HttpDelete


    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProjectManagerWebApi;
using System.Web.Http.Cors;

namespace ProjectManagerWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProjectsController : ApiController
    {
        private ProjectManagerEntities db = new ProjectManagerEntities();

        // GET: api/Projects
        public List<Project> GetProjects()
        {
           // db.Projects = new DbSet<Project>();
            var projects = db.Projects.ToList();
            var response = new List<Project>();

            foreach (var obj in projects)
            {
                response.Add(new Project()
                {
                    ProjectName = obj.ProjectName,
                    Priority = obj.Priority,
                    StartDate = obj.StartDate,
                    EndDate = obj.EndDate,
                    Project_ID = obj.Project_ID,
                    ManagerId=obj.ManagerId,
                    ManagerName=obj.ManagerName                 

                });
            }
            return response;
        }

        // GET: api/Projects/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult GetProject(int id)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

              

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectExists(int id)
        {
            return db.Projects.Count(e => e.Project_ID == id) > 0;
        }
    }
}
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
    public class UsersController : ApiController
    {
        private ProjectManagerEntities db = new ProjectManagerEntities();

        // GET: api/Users
        public List<User> GetUsers()
        {
            var users = db.Users.ToList();
            var response = new List<User>();

            foreach (var obj in users)
            {
                response.Add(new User()
                {
                    User_ID = obj.User_ID,
                    Employee_Id = obj.Employee_Id,
                    FirstName = obj.FirstName,
                    LastName = obj.LastName,
                    Project = obj.Project,
                    Project_ID = obj.Project_ID,
                    Task = obj.Task,
                    Task_ID = obj.Task_ID
                });
            }
            return response;
        }
        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
               

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.User_ID == id) > 0;
        }
    }
}
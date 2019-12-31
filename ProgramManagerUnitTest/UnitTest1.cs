using System;
using NUnit.Framework;
using ProjectManagerWebApi.Controllers;
using ProjectManagerWebApi;
using System.Collections.Generic;
using System.Web.Http;
using System.Net;
using System.Web.Http.Results;

namespace ProjectManagerTest
{
    [TestFixture]
    public class UserControllerTest

    {
        [Test]
        public void GetUsers()
        {
            UsersController user = new UsersController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            List<User> users = user.GetUsers();
            Assert.IsNotNull(users);
        }

        [Test]
        public void GetUser()
        {
            UsersController user = new UsersController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var result = user.GetUser(1) as OkNegotiatedContentResult<User>;
            Assert.IsNotNull(result.Content);

            //Assert.AreEqual(5, result.Content.User_ID);
        }

        [Test]
        public void AddUsers()
        {
            UsersController user = new UsersController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            User userdata = new User()
            {
                User_ID = 1,
                Project_ID = null,
                FirstName = "tstFirstName",
                LastName = "tstLastName",
                Employee_Id = 1,
                Task_ID = null

            };
            Project project = new Project()
            {
                ProjectName = null,

            };
            var result = user.PostUser(userdata) as CreatedAtRouteNegotiatedContentResult<User>;
            Assert.IsNotNull(result.RouteValues);
        }

        [Test]
        public void UpdateUsers()
        {
            UsersController user = new UsersController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            User userdata = new User()
            {
                User_ID = 1002,
                Project_ID = null,
                FirstName = "maoj",
                LastName = "kumar",
                Employee_Id = 25252,
                Task_ID = null

            };
            var result = user.PutUser(5, userdata) as StatusCodeResult;
            Assert.IsNull(result);
        }

        [Test]
        public void GetProject()
        {
            ProjectsController project = new ProjectsController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            List<Project> projects = project.GetProjects();
            Assert.IsNotNull(projects);
        }

        [Test]
        public void GetProjects()
        {
            ProjectsController project = new ProjectsController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var result = project.GetProject(5) as OkNegotiatedContentResult<Project>;
            Assert.IsNotNull(result.Content);

            //Assert.AreEqual(1, result.Content.Project_ID);
        }

        [Test]
        public void AddProject()
        {
            ProjectsController project = new ProjectsController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            Project projectdata = new Project()
            {
                ProjectName = "TestProject",
                ManagerId = 1,
                ManagerName = "TestManager",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Priority = 15

            };
            var result = project.PostProject(projectdata) as CreatedAtRouteNegotiatedContentResult<Project>;
            Assert.IsNotNull(result.RouteValues);
        }

        [Test]
        public void UpdateProject()
        {
            ProjectsController project = new ProjectsController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            Project projectdata = new Project()
            {
                Project_ID = 5,
                ProjectName = "TestingPMO",
                ManagerId = 1,
                ManagerName = "Mohamed Essak",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Priority = 15

            };

            var result = project.PutProject(2, projectdata) as StatusCodeResult;
            Assert.IsNull(result);
            
        }

        [Test]
        public void GetTasks()
        {
            TasksController task = new TasksController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            List<Task> tasks = task.GetTasks();
            Assert.IsNotNull(tasks);
        }

        [Test]
        public void GetTask()
        {
            TasksController task = new TasksController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var result = task.GetTask(2) as OkNegotiatedContentResult<Task>;
            Assert.IsNotNull(result.Content);
        }

        [Test]
        public void AddTask()
        {
            TasksController task = new TasksController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            Task taskdata = new Task()
            {
                ProjectName = "TestProject",
                ParentTaskName = "FirstParent",
                Project_ID = 5,
                Parent_ID = 1,
                STATUS = "Create",
                Task1 = "TestTask",
                UserName = "TestUser",
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now,
                Priority = 25

            };
            var result = task.PostTask(taskdata) as CreatedAtRouteNegotiatedContentResult<Task>;
            Assert.IsNotNull(result.RouteValues);
        }

    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManagerWebApi.Controllers;
using ProjectManagerWebApi;
using System.Collections.Generic;

namespace ProgramManagerUnitTest
{
    [TestClass]
    public class UserControllerTest

    {


        [TestMethod]
        public void GetUsers()
        {
            UsersController user = new UsersController();
             List<User> users= user.GetUsers();
            Assert.IsNotNull(users);
        }
    }
}

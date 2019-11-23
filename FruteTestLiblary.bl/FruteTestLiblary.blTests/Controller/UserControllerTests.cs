using Microsoft.VisualStudio.TestTools.UnitTesting;
using FruteTestLiblary.bl.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruteTestLiblary.bl.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {

        [TestMethod()]
        public void SetNewUserParamTest()
        {
            var userName = Guid.NewGuid().ToString();
            var gend = Guid.NewGuid().ToString();
            var birthDay = DateTime.Now.AddYears(-22);
            var weight = 50;
            var controll = new UserController(userName);
            controll.SetNewUserParam(gend, birthDay, weight);
            var controll2 = new UserController(userName);
            Assert.AreEqual(controll.CurrenUser.Name, controll2.CurrenUser.Name);
        }

        [TestMethod()]
        public void SaveTest()
        {
            var userName = Guid.NewGuid().ToString();
            var controll = new UserController(userName);
            Assert.AreEqual(userName, controll.CurrenUser.Name);
            
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FruteTestLiblary.bl.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruteTestLiblary.bl.Model;

namespace FruteTestLiblary.bl.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddFoodTest()
        {
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userCcontroller = new UserController(userName);
            var aeting = new EatingController(userCcontroller.CurrenUser);
            var prod = new Food(foodName, rnd.Next(10, 50), rnd.Next(10, 50), rnd.Next(10, 50), rnd.Next(10, 50));

            //Act
            aeting.AddFood(prod, 100);


            Assert.AreEqual(prod.Name, aeting.Eating.Foods.First().Key.Name);
        }
    }
}
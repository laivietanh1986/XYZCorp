using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XYZCorp;
using XYZCorp.Controllers;
using XYZCorp.Services;
using XYZCorp.Models;
using XYZCorp.Utility;

namespace XYZCorp.Tests.Controllers
{
    [TestClass]
    public class UserServicesTest
    {
        private UserServices userServices;
        [TestInitialize]
        public void Initial()
        {

            userServices = new UserServices();
        }
        [TestMethod]
        public void GetUser()
        {
            // Arrange
            

            // Act
             var result  = userServices.GetUserList();

            // Assert
            
            Assert.AreEqual(result.ToList().Count, UserData.GetUserData().Count);
            
        }
        [TestMethod]
        public void GetUserByIdFail()
        {
            // Arrange         
            var id = 1000;
            // Act
            var result = userServices.GetUser(1000);

            // Assert

            Assert.AreEqual(result.Result,ResultValue.Fail);

        }
        [TestMethod]
        public void GetUserByIdSuccess()
        {
            // Arrange
            
            var user = UserData.GetUserData().First();
            // Act
            var result = userServices.GetUser(user.Id);

            // Assert

            Assert.AreEqual(result.Result, ResultValue.Success);
            Assert.AreEqual(((User)result.Data).Name, user.Name);

        }
        [TestMethod]
        public void AddUserNameEmpty()
        {
            // Arrange
            
            var user = new User() { Name = string.Empty, Points = 10 };
            // Act
            var result = userServices.InsertUser(user);

            // Assert

            Assert.AreEqual(result.Result, ResultValue.Fail);
            Assert.AreEqual(result.Message, Message.NameIsEmpty);

        }
        [TestMethod]
        public void AddUserExist()
        {
            // Arrange
            
            var existName = UserData.GetUserData().First().Name;
            var user = new User() { Name = existName, Points = 10 };
            // Act
            var result = userServices.InsertUser(user);

            // Assert

            Assert.AreEqual(result.Result, ResultValue.Fail);
            Assert.AreEqual(result.Message, Message.NameAlreadyExist);
        }
        [TestMethod]
        public void AddUserNotExist()
        {
            // Arrange
            
            var guild = Guid.NewGuid();
            var user = new User() { Name = "Viet Anh " + guild.ToString(), Points = 10 };
            // Act
            var result = userServices.InsertUser(user);

            // Assert

            Assert.AreEqual(result.Result, ResultValue.Success);
            Assert.AreEqual((int)result.Data,UserData.GetUserData().Max(x=>x.Id));
        }
        [TestMethod]
        public void AddUserPointSmallerThanZero()
        {
            // Arrange

            var guild = Guid.NewGuid();
            var user = new User() { Name = "Viet Anh " + guild.ToString(), Points = -10 };
            // Act
            var result = userServices.InsertUser(user);

            // Assert

            Assert.AreEqual(result.Result, ResultValue.Fail);
            Assert.AreEqual(result.Message, Message.PointMustGreaterThanZero);
        }

        [TestMethod]
        public void SetPointSuccess()
        {
            // Arrange
            
            var user = new UserPoint() { Id =1,Points = 10 };
            // Act
            var result = userServices.SetPoint(user);

            // Assert

            Assert.AreEqual(result.Result, ResultValue.Success);            
        }

        [TestMethod]
        public void SetPointFail()
        {
            // Arrange
            
            var idNotExist = UserData.GetUserData().Max(x => x.Id) + 10;
            var user = new UserPoint() { Id = idNotExist, Points = 10 };
            // Act
            var result = userServices.SetPoint(user);

            // Assert

            Assert.AreEqual(result.Result, ResultValue.Fail);
        }
        [TestMethod]
        public void SetPointSmallerThanZero()
        {
            // Arrange

            var user = new UserPoint() { Id = 1, Points = -10 };
            // Act
            var result = userServices.SetPoint(user);

            // Assert

            Assert.AreEqual(result.Result, ResultValue.Fail);
            Assert.AreEqual(result.Message, Message.PointMustGreaterThanZero);
        }

    }
}

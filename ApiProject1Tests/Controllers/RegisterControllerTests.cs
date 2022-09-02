using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiProject1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiProject1.Interface;
using Moq;
using apiProject1_lib;

namespace ApiProject1.Controllers.Tests
{
    [TestClass()]
    public class RegisterControllerTests
    {
        [TestMethod()]
        public void GetUserTest()
        {
            var registerMock = new Mock<IRegister>();
            registerMock.Setup(r => r.GetUserDetails()).Returns(new List<Register>
            {
               new Register {  FirstName = "user1", LastName = "1", EmailId = "user1@gmail.com", Password = "user1" },
               new Register {  FirstName = "user2", LastName = "2", EmailId = "user2@gmail.com", Password = "user2" }
            });
            RegisterController rc = new RegisterController(registerMock.Object);

            var getUserResult = rc.Get();
            Assert.IsInstanceOfType(getUserResult, typeof(IEnumerable<Register>));
            Assert.AreEqual(2, getUserResult.Count());
        }
        [TestMethod()]
        public void CreateNewUserTest()
        {
            var registerMock = new Mock<IRegister>();
            registerMock.Setup(r => r.CreateNewUser(It.IsAny<Register>())).Returns(true);
            Register r = new Register();
            r.FirstName = "u";
            r.LastName = "u";
            r.EmailId = "u@gmail.com";
            r.Password = "u";
            RegisterController rc = new RegisterController(registerMock.Object);
            var createNewUserResult = rc.Post(r);
            Assert.IsTrue(createNewUserResult);
        }
    }
}
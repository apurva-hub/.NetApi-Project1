using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiProject1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apiProject1_lib;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace ApiProject1.Services.Tests
{
    [TestClass()]
    public class RegisterServiceTests
    {
        [TestMethod()]
        public void GetUserDetailsTest()
        {
            // Arrange
            var registerData = new List<Register>
            {
                new Register {  FirstName = "user1", LastName = "1", EmailId = "user1@gmail.com", Password = "user1" },
                new Register {  FirstName = "user2", LastName = "2", EmailId = "user2@gmail.com", Password = "user2" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Register>>();
            mockSet.As<IQueryable<Register>>().Setup(m => m.Provider).Returns(registerData.Provider);
            mockSet.As<IQueryable<Register>>().Setup(m => m.Expression).Returns(registerData.Expression);
            mockSet.As<IQueryable<Register>>().Setup(m => m.ElementType).Returns(registerData.ElementType);
            mockSet.As<IQueryable<Register>>().Setup(m => m.GetEnumerator()).Returns(registerData.GetEnumerator());
            var mockContext = new Mock<task_managerContext>();
            mockContext.Setup(c => c.Registers).Returns(mockSet.Object);
            RegisterService rs = new RegisterService(mockContext.Object);

            // Act
            var getUserDetails = rs.GetUserDetails();

            // Assert
            foreach (var r in getUserDetails)
            {
                Assert.IsNotNull(r.FirstName);
                Assert.IsNotNull(r.LastName);
                Assert.IsNotNull(r.EmailId);
                Assert.IsNotNull(r.Password);
            }

        }
        [TestMethod()]
        public bool CreateNewUserTest()
        {
            var mockSet = new Mock<DbSet<Register>>();
            var mockContext = new Mock<task_managerContext>();
            mockContext.Setup(m => m.Registers).Returns(mockSet.Object);
            Register newUser = new Register();
            newUser.FirstName = "user1";
            newUser.LastName = "1";
            newUser.EmailId = "user1@gmail.com";
            newUser.Password = "user1";

            mockSet.Setup(c => c.Add(It.IsAny<Register>()));
            mockContext.Setup(c => c.SaveChanges()).Returns(1);
            RegisterService rs = new RegisterService(mockContext.Object);

            bool result = rs.CreateNewUser(newUser);
            mockSet.Verify(c => c.Add(It.IsAny<Register>()), Times.Once());

            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.IsTrue(result);
            return true;

        }
    }
}
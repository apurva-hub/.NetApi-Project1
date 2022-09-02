using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiProject1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apiProject1_lib;
using Moq;
using Microsoft.EntityFrameworkCore;

namespace ApiProject1.Services.Tests
{
    [TestClass()]
    public class TaskServiceTests
    {
        /*
        [TestMethod()]
        public void DeleteTaskTest()
        {
            var mockSet = new Mock<DbSet<apiProject1_lib.Task>>();
            var mockContext = new Mock<task_managerContext>();
            mockContext.Setup(m => m.Tasks).Returns(mockSet.Object);

            mockSet.Setup(c => c.Remove(It.IsAny<apiProject1_lib.Task>()));
            mockContext.Setup(c => c.SaveChanges()).Returns(1);
            TaskService ts = new TaskService(mockContext.Object);

            int result = ts.DeleteTaskById(1);
            mockSet.Verify(c => c.Remove(It.IsAny<apiProject1_lib.Task>()), Times.Once());

            mockContext.Verify(m => m.SaveChanges(), Times.Once());

        }
        */
    }
}
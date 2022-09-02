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
    public class ProjectServiceTests
    {
        [TestMethod()]
        public void GetProjectTest()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project {  ProjectTitle = "project1", ProjectDescription = "p1", UserId = 1, ProjectId = 2000 },
                new Project {  ProjectTitle = "project2", ProjectDescription = "p2", UserId = 1, ProjectId = 2000 },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Project>>();
            mockSet.As<IQueryable<Project>>().Setup(m => m.Provider).Returns(projects.Provider);
            mockSet.As<IQueryable<Project>>().Setup(m => m.Expression).Returns(projects.Expression);
            mockSet.As<IQueryable<Project>>().Setup(m => m.ElementType).Returns(projects.ElementType);
            mockSet.As<IQueryable<Project>>().Setup(m => m.GetEnumerator()).Returns(projects.GetEnumerator());
            var mockContext = new Mock<task_managerContext>();
            mockContext.Setup(c => c.Projects).Returns(mockSet.Object);
            ProjectService ps = new ProjectService(mockContext.Object);

            // Act
            var getProjects = ps.GetProject();

            // Assert
            foreach (var p in getProjects)
            {
                Assert.IsNotNull(p.ProjectTitle);
                Assert.IsNotNull(p.ProjectDescription);
                Assert.IsNotNull(p.UserId);
            } 
        }
        [TestMethod()]  
        public void GetProjectByIdTest()
        {
            // Arrange
            var projectData = new List<Project>
            {
                new Project {  ProjectTitle = "new1", ProjectDescription = "new1", UserId = 1 },
                new Project {  ProjectTitle = "new2", ProjectDescription = "new2", UserId = 1 },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Project>>();
            mockSet.As<IQueryable<Project>>().Setup(m => m.Provider).Returns(projectData.Provider);
            mockSet.As<IQueryable<Project>>().Setup(m => m.Expression).Returns(projectData.Expression);
            var mockContext = new Mock<task_managerContext>();
            mockContext.Setup(c => c.Projects).Returns(mockSet.Object);
            ProjectService ps = new ProjectService(mockContext.Object);

            // Act
            var getProjectById = ps.GetProjectById(1);

            // Assert
            foreach (var p in getProjectById)
            {
                Assert.AreEqual(1, p.UserId);
                Assert.AreEqual("new1", p.ProjectTitle);
                Assert.IsNotNull(p.ProjectTitle);
                Assert.IsNotNull(p.ProjectDescription);
            }

        }
        [TestMethod()]
        public void CreateNewProjectTest()
        {
            var mockSet = new Mock<DbSet<Project>>();
            var mockContext = new Mock<task_managerContext>();
            mockContext.Setup(m => m.Projects).Returns(mockSet.Object);

            mockSet.Setup(c => c.Add(It.IsAny<Project>()));
            mockContext.Setup(c => c.SaveChanges()).Returns(1);
            ProjectService ps = new ProjectService(mockContext.Object);

            int result = ps.CreateNewProject("title", "desc", 1);
            mockSet.Verify(c => c.Add(It.IsAny<Project>()), Times.Once());

            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(1, result);

        }
        [TestMethod()]
        public void DeleteProjectTest()
        {
            
            var mockSet = new Mock<DbSet<Project>>();           
            var mockContext = new Mock<task_managerContext>();
            mockContext.Setup(m => m.Projects).Returns(mockSet.Object);

            mockSet.Setup(c => c.Remove(It.IsAny<Project>()));
            mockContext.Setup(c => c.SaveChanges()).Returns(1);
            ProjectService ts = new ProjectService(mockContext.Object);

            int result = ts.DeleteProjectById(1);
            mockSet.Verify(c => c.Remove(It.IsAny<Project>()), Times.Once());

            mockContext.Verify(m => m.SaveChanges(), Times.Once());
            Assert.AreEqual(1, result);

        }
    }
}
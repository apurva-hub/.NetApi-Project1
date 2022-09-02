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
    public class ProjectControllerTests
    {
        [TestMethod()]
        public void GetProjectsTest()
        {
            var projectMock = new Mock<IProject>();
            projectMock.Setup(p => p.GetProject()).Returns(new List<Project>
            {
               new Project {  ProjectTitle = "new1", ProjectDescription = "new1", UserId = 1 },
               new Project {  ProjectTitle = "new2", ProjectDescription = "new2", UserId = 1 }
            });
            ProjectController pc = new ProjectController(projectMock.Object);

            var getProjectResult = pc.Get();
            Assert.IsInstanceOfType(getProjectResult, typeof(IEnumerable<Project>));
            Assert.AreEqual(2, getProjectResult.Count());
        }
        [TestMethod()]
        public void GetProjectByIdTest()
        {
            var projectMock = new Mock<IProject>();
            projectMock.Setup(p => p.GetProject()).Returns(new List<Project>
            {
               new Project {  ProjectTitle = "new1", ProjectDescription = "new1", UserId = 1, ProjectId = 10},
               new Project {  ProjectTitle = "new2", ProjectDescription = "new2", UserId = 1, ProjectId = 11}
            });
            ProjectController pc = new ProjectController(projectMock.Object);

            var getProjectByIdResult = pc.Get(11);
            Assert.IsInstanceOfType(getProjectByIdResult, typeof(IEnumerable<Project>));
            foreach(var p in getProjectByIdResult)
            {
                Assert.AreEqual("new1", p.ProjectTitle);
                Assert.AreEqual("new1", p.ProjectDescription);
                Assert.AreEqual(1, p.UserId);
            }
        }
        [TestMethod()]
        public void CreateNewProjectTest()
        {
            var projectMock = new Mock<IProject>();
            projectMock.Setup(p => p.CreateNewProject(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(1);
            ProjectController pc = new ProjectController(projectMock.Object);
            var createNewProjectResult = pc.Post("tile", "tile", 1);
            Assert.AreEqual(1, createNewProjectResult);
        }
    }
}
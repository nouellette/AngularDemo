using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AngularDemo;
using AngularDemo.Controllers;
using AngularDemo.Helpers;
using Moq;
using System.IO;
using AngularDemo.Models;
using System.Diagnostics;

namespace AngularDemo.Tests.Controllers
{
    [TestClass]
    public class ApiControllerTest
    {
        private Mock<ITimeProvider> _mockTimeProvider;
        private Mock<IFileSystemProvider> _mockFileSystemProvider;
        private Mock<IEventLogger> _mockEventLoggerProvider;
        private ApiController _controller;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockTimeProvider = new Mock<ITimeProvider>(MockBehavior.Strict);
            _mockFileSystemProvider = new Mock<IFileSystemProvider>(MockBehavior.Strict);
            _mockEventLoggerProvider = new Mock<IEventLogger>(MockBehavior.Strict);

            _mockTimeProvider.Setup(x => x.GetTime()).Returns(new DateTime(2014, 1, 1));
            _mockFileSystemProvider.Setup(x => x.CreateFile(It.IsAny<string>())).Returns(new MemoryStream());
            _mockFileSystemProvider.Setup(x => x.WriteToFile(It.IsAny<Stream>())).Returns(new StreamWriter(new MemoryStream()));
            _mockEventLoggerProvider.Setup(x => x.EventLogging(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<EventLogEntryType>(), It.IsAny<int>()));

            _controller = new ApiController(_mockTimeProvider.Object, _mockFileSystemProvider.Object, _mockEventLoggerProvider.Object);
        }

        [TestMethod]
        public void ApiController_GetData_Result_Is_Not_Empty()
        {
            JsonResult result = _controller.GetData() as JsonResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ApiController_ExportData_Executes()
        {
            var person = new Person();
            person.first = "FirstTest";
            person.last = "LastTest";
            _controller.ExportData(person);
        }

        [TestMethod]
        public void ApiController_WindowsEventLog()
        {
            var person = new Person();
            person.first = "FirstTest";
            person.last = "LastTest";
            _controller.WindowsEventLog(person);
        }
    }
}

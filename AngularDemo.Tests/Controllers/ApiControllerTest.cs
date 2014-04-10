using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AngularDemo;
using AngularDemo.Controllers;
using AngularDemo.Helpers;

namespace AngularDemo.Tests.Controllers
{
    [TestClass]
    public class ApiControllerTest
    {
        //TODO: ADD MOQ to better return the methods for the providers below.
        TimeProvider _timeProvider = new TimeProvider();
        FileSystemProvider _fileSystemProvider = new FileSystemProvider();

        [TestMethod]
        public void ApiController_Result_Is_Not_Empty()
        {
            ApiController controller = new ApiController(_timeProvider, _fileSystemProvider);
            JsonResult result = controller.GetData() as JsonResult;
            Assert.IsNotNull(result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AngularDemo;
using AngularDemo.Controllers;

namespace AngularDemo.Tests.Controllers
{
    [TestClass]
    public class ApiControllerTest
    {
        [TestMethod]
        public void ApiController_Result_Is_Not_Empty()
        {
            ApiController controller = new ApiController();
            JsonResult result = controller.GetData() as JsonResult;
            Assert.IsNotNull(result);
        }
    }
}

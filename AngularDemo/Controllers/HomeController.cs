using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularDemo.Controllers
{
    /// <summary>
    /// The Home controller displays the main page for the SPA
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The call for the main page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
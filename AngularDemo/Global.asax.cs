using AngularDemo.Configuration;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AngularDemo
{
    public class MyAngularDemo : System.Web.HttpApplication
    {
        Container _container;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            _container = new Container(new DependencyRegistry());
            StructureMapDependencyResolver structureMapDependencyResolver = new StructureMapDependencyResolver(_container);
            DependencyResolver.SetResolver(structureMapDependencyResolver);
        }
    }
}

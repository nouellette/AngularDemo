using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;
using System;

namespace AngularDemo.Configuration
{
    /// <summary>
    /// Helper that allows MVC to create controllers using StructureMap
    /// </summary>
    public class ControllerActivator : IControllerActivator
    {
        /// <summary>
        /// The StructureMap container used to load controllers
        /// </summary>
        private readonly IContainer _container;

        /// <summary>
        /// Constructs an instance of ControllerActivator
        /// </summary>
        /// <param name="container">The StructureMap container used to load controllers</param>
        public ControllerActivator(IContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Factory method to create a controller
        /// </summary>
        /// <param name="requestContext">The request that prompted the creation of the controller</param>
        /// <param name="controllerType">The type of controller to create</param>
        /// <returns></returns>
        public IController Create(RequestContext requestContext, Type controllerType)
        {
            return _container.GetInstance(controllerType) as Controller;
        }
    }
}
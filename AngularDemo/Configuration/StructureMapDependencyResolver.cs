using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularDemo.Configuration
{
    /// <summary>
    /// Mechanism to register StructureMap as a DI container that MVC can use
    /// </summary>
    public class StructureMapDependencyResolver : IDependencyResolver
    {
        /// <summary>
        /// The StructureMap container to use
        /// </summary>
        private readonly IContainer _container;

        /// <summary>
        /// Constructs an instance of StructureMapDependencyResolver
        /// </summary>
        /// <param name="container">The StructureMap container to use</param>
        public StructureMapDependencyResolver(IContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// Returns a single instance of a given type from the Container
        /// </summary>
        /// <param name="serviceType">The type of instance to return</param>
        /// <returns>The instance</returns>
        public object GetService(Type serviceType)
        {
            var instance = _container.TryGetInstance(serviceType);

            if (instance == null && !serviceType.IsAbstract)
            {
                _container.Configure(c => c.AddType(serviceType, serviceType));
                instance = _container.TryGetInstance(serviceType);
            }

            return instance;
        }

        /// <summary>
        /// Return all instances of a given type from the Container
        /// </summary>
        /// <param name="serviceType">The type of instance to return</param>
        /// <returns>The set of instances</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAllInstances(serviceType).Cast<object>();
        }
    }
}
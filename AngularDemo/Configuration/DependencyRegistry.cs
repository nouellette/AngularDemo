using AngularDemo.Helpers;
using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularDemo.Configuration
{
    /// <summary>
    /// Class used with StructureMap to set up DI mappings
    /// </summary>
    public class DependencyRegistry : Registry
    {
        /// <summary>
        /// Constructs an instance of DependencyRegistry
        /// </summary>
        public DependencyRegistry()
        {
            For<ITimeProvider>().Use<TimeProvider>();
            For<IFileSystemProvider>().Use<FileSystemProvider>();
        }
    }
}
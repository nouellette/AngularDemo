using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularDemo.Helpers
{
    /// <summary>
    /// Provides access to the file system
    /// </summary>
    public class FileSystemProvider : IFileSystemProvider
    {
        /// <summary>
        /// Creates a file with a specific name
        /// </summary>
        /// <param name="name">Name of the file</param>
        /// <returns>The stream to write to</returns>
        public System.IO.Stream CreateFile(string name)
        {
            return System.IO.File.Create(name);
        }

        /// <summary>
        /// Allows access to the file stream to write to
        /// </summary>
        /// <param name="file">Stream of the file</param>
        /// <returns></returns>
        public System.IO.StreamWriter WriteToFile(System.IO.Stream file)
        {
            return new System.IO.StreamWriter(file);
        }
    }
}
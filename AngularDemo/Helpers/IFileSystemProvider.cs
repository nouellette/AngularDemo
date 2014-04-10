using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AngularDemo.Helpers
{
    /// <summary>
    /// Provides access to the file system
    /// </summary>
    public interface IFileSystemProvider
    {
        /// <summary>
        /// Creates a file with a specific name
        /// </summary>
        /// <param name="name">Name of the file</param>
        /// <returns>The stream to write to</returns>
        Stream CreateFile(string name);

        /// <summary>
        /// Allows access to the file stream to write to
        /// </summary>
        /// <param name="file">Stream of the file</param>
        /// <returns></returns>
        StreamWriter WriteToFile(Stream file);
    }
}
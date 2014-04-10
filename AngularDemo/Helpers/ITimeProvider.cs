using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularDemo.Helpers
{
    /// <summary>
    /// The interface for the time provider
    /// </summary>
    public interface ITimeProvider
    {
        /// <summary>
        /// Gets the current time
        /// </summary>
        /// <returns></returns>
        DateTime GetTime();
    }
}

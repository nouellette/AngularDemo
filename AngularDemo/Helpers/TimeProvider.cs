using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularDemo.Helpers
{
    /// <summary>
    /// The interface for the time provider
    /// </summary>
    public class TimeProvider : ITimeProvider
    {
        /// <summary>
        /// Gets the current time
        /// </summary>
        /// <returns></returns>
        public DateTime GetTime()
        {
            return DateTime.Now;
        }
    }
}
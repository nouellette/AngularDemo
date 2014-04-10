using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularDemo.Helpers
{
    /// <summary>
    /// Provides access to the Event Log
    /// </summary>
    public interface IEventLogger
    {
        /// <summary>
        /// Will create an event log
        /// </summary>
        /// <param name="applicationName">Name of the application</param>
        /// <param name="message">Message to display in event logs</param>
        /// <param name="type">Type of message</param>
        /// <param name="eventId">Id for reference</param>
        void EventLogging(string applicationName, string message, EventLogEntryType type, int eventId);
    }
}

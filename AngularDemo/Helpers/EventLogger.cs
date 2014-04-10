using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AngularDemo.Helpers
{
    /// <summary>
    /// Provides access to the Event Log
    /// </summary>
    public class EventLogger : IEventLogger
    {
        /// <summary>
        /// Will create an event log
        /// </summary>
        /// <param name="applicationName">Name of the application</param>
        /// <param name="message">Message to display in event logs</param>
        /// <param name="type">Type of message</param>
        /// <param name="eventId">Id for reference</param>
        public void EventLogging(string applicationName, string message, EventLogEntryType type, int eventId)
        {
            EventLog.WriteEntry(applicationName, message, type, eventId);
        }
    }
}
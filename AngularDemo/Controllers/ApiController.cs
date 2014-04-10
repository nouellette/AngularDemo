using System;
using System.Collections.Generic;
using System.Diagnostics;
using AngularDemo.Properties;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using Newtonsoft.Json;
using System.Text;
using AngularDemo.Models;
using System.Web.Script.Serialization;
using AngularDemo.Helpers;

namespace AngularDemo.Controllers
{
    /// <summary>
    /// The Api access points
    /// </summary>
    public class ApiController : Controller
    {
        /// <summary>
        /// Container for the time provider
        /// </summary>
        private ITimeProvider _timeProvider;

        /// <summary>
        /// Container for the file system provider
        /// </summary>
        private IFileSystemProvider _fileSystemProvider;

        /// <summary>
        /// Container for the event logging system
        /// </summary>
        private IEventLogger _eventLogger;

        /// <summary>
        /// Constructor for the main API
        /// </summary>
        /// <param name="timeProvider">Will give access to the DateTime.Now</param>
        /// <param name="fileSystemProvider">Will give access to the file system</param>
        /// <param name="eventLogger">Will give access to the event logging system</param>
        public ApiController(ITimeProvider timeProvider, IFileSystemProvider fileSystemProvider, IEventLogger eventLogger)
        {
            _timeProvider = timeProvider;
            _fileSystemProvider = fileSystemProvider;
            _eventLogger = eventLogger;
        }

        /// <summary>
        /// Parses an Xml file that is acting like a database
        /// </summary>
        /// <returns>JSON of the Xml file</returns>
        public JsonResult GetData()
        {
            var doc = new XmlDocument();
            doc.LoadXml(Resources.SampleData);

            return Json(JsonConvert.SerializeXmlNode(doc), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// This method is used to save a file on the system
        /// </summary>
        /// <param name="person">The person that will be saved to the file</param>
        [HttpPost]
        public void ExportData(Person person)
        {
            var path = @"C:\";
            var filename = "Export_Data_Angular_Demo_" + _timeProvider.GetTime().ToString("s") + ".txt";
            filename = filename.Replace(':', '_');
            var serializedJson = JsonConvert.SerializeObject(person);
            var deserializedJson = JsonConvert.DeserializeObject(serializedJson);
            
            var file = _fileSystemProvider.CreateFile(path + filename);
            using (var writer = _fileSystemProvider.WriteToFile(file))
            {
                writer.WriteLine(deserializedJson);
            }            
        }

        /// <summary>
        /// This will create a windows event log for the application
        /// </summary>
        /// <param name="person">The person that we are using to pass their name to the event log</param>
        [HttpPost]
        public void WindowsEventLog(Person person)
        {
            var message = string.Format("{0} {1} has been logged in the windows application event logs.", person.first, person.last);
            _eventLogger.EventLogging("My Angular Demo App", message, EventLogEntryType.SuccessAudit, 12345);
        }
	}
}
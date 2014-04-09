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

namespace AngularDemo.Controllers
{
    public class ApiController : Controller
    {
        public JsonResult GetData()
        {
            var doc = new XmlDocument();
            doc.LoadXml(Resources.SampleData);

            return Json(JsonConvert.SerializeXmlNode(doc), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void ExportData(Person person)
        {
            var path = @"C:\";
            var filename = "Export_Data_Angular_Demo_" + DateTime.Now.ToString("s") + ".txt";
            filename = filename.Replace(':', '_');
            var serializedJson = JsonConvert.SerializeObject(person);
            var deserializedJson = JsonConvert.DeserializeObject(serializedJson);
            
            var file = System.IO.File.Create(path + filename);
            using (var writer = new System.IO.StreamWriter(file))
            {
                writer.WriteLine(deserializedJson);
            }            
        }

        [HttpPost]
        public void WindowsEventLog(Person person)
        {
            var serializedJson = JsonConvert.SerializeObject(person);
            var deserializedJson = JsonConvert.DeserializeObject(serializedJson);

            EventLog.WriteEntry("My Angular Demo App", deserializedJson.ToString(), EventLogEntryType.SuccessAudit, 12345);
        }
	}
}
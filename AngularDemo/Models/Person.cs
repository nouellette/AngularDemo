using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularDemo.Models
{
    /// <summary>
    /// Defines a person
    /// </summary>
    public class Person
    {
        /// <summary>
        /// First name
        /// </summary>
        public string first { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string last { get; set; }

        /// <summary>
        /// Date of birth
        /// </summary>
        public string dob { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        public string phone { get; set; }
    }
}
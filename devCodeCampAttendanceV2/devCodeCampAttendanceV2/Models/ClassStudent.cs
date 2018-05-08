using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace devCodeCampAttendanceV2.Models
{
    public class ClassStudent
    {
        public int ClassID { get; set; }
        public virtual Class Class { get; set; }
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

    }
}
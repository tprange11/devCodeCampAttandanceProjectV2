using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace devCodeCampAttendanceV2.Models
{
    public class SignIn
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

        public int ClassID { get; set; }
        public virtual Class Class { get; set; }
        public DateTime Date { get; set; }
        public bool Late { get; set; }
    }
}
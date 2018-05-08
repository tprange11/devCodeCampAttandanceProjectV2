using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace devCodeCampAttendanceV2.Models
{
    public class ClassStudent
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Class")]
        public int ClassID { get; set; }
        public virtual Class Class { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

    }
}
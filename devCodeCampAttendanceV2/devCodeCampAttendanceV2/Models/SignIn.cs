using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace devCodeCampAttendanceV2.Models
{
    public class SignIn
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int StudentID { get; set; }
        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }
        [Required]
        public int ClassID { get; set; }
        [ForeignKey("ClassID")]
        public virtual Class Class { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
        public bool Late { get; set; }
        public bool HalfDay { get; set; }
        public string Reason { get; set; }
    }
}
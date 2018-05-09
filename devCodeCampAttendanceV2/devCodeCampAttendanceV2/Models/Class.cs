using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace devCodeCampAttendanceV2.Models
{

    public class Class
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        [Display(Name = "Class")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }





    }
}
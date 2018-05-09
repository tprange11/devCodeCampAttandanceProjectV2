<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace devCodeCampAttendanceV2.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(50)]
        public string SlackID { get; set; }

        public string UserID { get; set; }

    }
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace devCodeCampAttendanceV2.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(50)]
        public string SlackID { get; set; }




    }
>>>>>>> 6f449011293140596d5442e1d5bd389bb072185e
}
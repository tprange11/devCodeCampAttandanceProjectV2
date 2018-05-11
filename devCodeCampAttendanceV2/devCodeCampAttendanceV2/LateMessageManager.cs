using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using devCodeCampAttendanceV2.Models;

namespace devCodeCampAttendanceV2
{
    public class LateMessageManager
    {
        public static void SendLateMessage()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var lateUsers =
                from Student in db.ClassStudents
                select Student.Student.SlackID;
        }
    }
}
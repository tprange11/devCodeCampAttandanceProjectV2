using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace devCodeCampAttendanceV2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(User.IsInRole("Instructor"))
            {
                return RedirectToAction("InstructorHome", "Instructors");
            }
            else if (User.IsInRole("Student"))
            {
                return RedirectToAction("StudentHome", "Students");
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "This application is a single stop where students can check into class, and instructors can view student attendance and run reports.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Find Contact details for devCodeCamp below.";

            return View();
        }

    }
}
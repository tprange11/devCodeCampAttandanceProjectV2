using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using devCodeCampAttendanceV2.Models;

namespace devCodeCampAttendanceV2
{
    public class LateMessageManager
    {
        //public string lateUsers;
        public static void SendLateMessage()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            DateTime today = DateTime.Now.Date;
            var currentClasses = db.Classes.Where(c => c.EndDate > today);
           
            foreach (var c in currentClasses)
            {
                var currentStudents = db.ClassStudents.Where(v => v.ClassID == c.ID);
                foreach (var student in currentStudents)
                {
                    var ID = student.StudentID;
                    var signedIn = db.SignIns.Where(s => s.Date >= today && s.StudentID == ID);
                    var lateUsers = currentStudents.Where(s => signedIn.Count() == 0);
                    foreach (var lateUser in lateUsers)
                    {
                        var slackID = lateUser.Student.SlackID;
                        string urlWithAccessToken = "https://hooks.slack.com/services/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";
                        
                        SlackClient client = new SlackClient(urlWithAccessToken);

                        client.PostMessage(username: "attendotron",
                                   text: "If you havent signed in yet, you can do so here: ",
                                   channel: "@" + slackID);
                    }
                    
                } 
                
                


            }
            //var currentStudents = db.ClassStudents.Where(c => c.Class == currentClasses).ToList();
            //var student = db.Students.Where(s => s.ID == currentStudents.Where(c => c.StudentID == )).FirstOrDefault();
            
            //foreach (var lateStudent in currentStudents)
            {
                //var signedIn = db.SignIns.Where(s => s.Date >= today && s.StudentID == student.ID);
               
                //var lateUserSlackID = lateUser.)
                //from Student in db.ClassStudents
                //where// 
                //select Student.Student.SlackID;

                
            }

            //var user = db.Users.Where(u => u.Id == userID).FirstOrDefault();    //get user 
            //var student = db.Students.Where(s => s.UserID == user.Id).FirstOrDefault();
            //var signedIn = db.SignIns.Where(s => s.Date >= today && s.StudentID == student.ID);
            //var lateUser = db.Students.Where(s => signedIn.Count() == 0);
            ////from Student in db.ClassStudents
            ////where 
            ////select Student.Student.SlackID;

            //string urlWithAccessToken = "https://hooks.slack.com/services/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";
            //string username = lateUser.ToString();
            //SlackClient client = new SlackClient(urlWithAccessToken);

            //client.PostMessage(username: "attendotron",
            //           text: "If you havent signed in yet, you can do so here: ",
            //           channel: "@" + username);



        }


        //public void SendLateMessage2()
        //{

        //    ApplicationDbContext db = new ApplicationDbContext();
        //    string userID = User.Identity.GetUserId();  //get current userID
        //    var user = db.Users.Where(u => u.Id == userID).FirstOrDefault();    //get user 
        //    var student = db.Students.Where(s => s.UserID == user.Id).FirstOrDefault(); //get the corresponding student
        //    DateTime today = DateTime.Now.Date;
        //    var signedIn = db.SignIns.Where(s => s.Date >= today && s.StudentID == student.ID); //pull signin entries where the student matches and the date is today
        //    if (student == null)
        //    {
        //        return View("Index", "Home");
        //    }
        //    else if (signedIn.Count() == 0) //if there are none
        //    {
        //        ViewBag.Message = "NOT Signed In.";
        //    }
        //    else //if there is one
        //    {
        //        ViewBag.Message = "Signed In!";
        //    }
        //}

        //public void TestPostMessage()
        //{
        //    string urlWithAccessToken = "https://hooks.slack.com/services/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";
        //    string username = lateUsers;
        //    SlackClient client = new SlackClient(urlWithAccessToken);

        //    client.PostMessage(username: "attendotron",
        //               text: "If you havent signed in yet, you can do so here: ",
        //               channel: "@" + username);
        //}



    }
}
using Microsoft.Owin;
using Owin;
using Hangfire;
using devCodeCampAttendanceV2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartupAttribute(typeof(devCodeCampAttendanceV2.Startup))]
namespace devCodeCampAttendanceV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("DefaultConnection");
            app.UseHangfireServer();
            app.UseHangfireDashboard();
            //SlackClientTest slackClient = new SlackClientTest();
            //slackClient.TestPostMessage();
        }

        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // Create Admin Role and default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                // Create role  
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Create user                  
                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";

                string userPWD = "password!";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            // Create Instructor  
            if (!roleManager.RoleExists("Instructor"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Instructor";
                roleManager.Create(role);

            }

            // creating Creating Employee role    
            if (!roleManager.RoleExists("Student"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Student";
                roleManager.Create(role);

            }
        }
    }
}

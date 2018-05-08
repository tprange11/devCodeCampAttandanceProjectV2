using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(devCodeCampAttendance.Startup))]
namespace devCodeCampAttendance
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TimesheetWeb.Startup))]
namespace TimesheetWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

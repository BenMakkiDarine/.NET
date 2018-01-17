using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EasyMission.WebApp.Startup))]
namespace EasyMission.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

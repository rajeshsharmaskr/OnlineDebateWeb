using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineDebateWeb.Startup))]
namespace OnlineDebateWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

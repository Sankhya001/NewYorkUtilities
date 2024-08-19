using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewYorkUtilities.Startup))]
namespace NewYorkUtilities
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

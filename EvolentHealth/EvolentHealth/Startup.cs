using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EvolentHealth.Startup))]
namespace EvolentHealth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

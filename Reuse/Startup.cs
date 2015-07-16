using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Reuse.Startup))]
namespace Reuse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LayoutApoio.Startup))]
namespace LayoutApoio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

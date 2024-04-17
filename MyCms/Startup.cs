using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyCms.Startup))]
namespace MyCms
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

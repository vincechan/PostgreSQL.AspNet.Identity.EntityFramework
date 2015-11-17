using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Demo.Startup))]
namespace Demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

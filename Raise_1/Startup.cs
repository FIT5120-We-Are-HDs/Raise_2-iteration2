using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Raise_1.Startup))]
namespace Raise_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

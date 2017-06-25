using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Emerson1.Startup))]
namespace Emerson1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

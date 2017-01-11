using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kancelaria.Startup))]
namespace Kancelaria
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

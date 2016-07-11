using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Net.Startup))]
namespace Net
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

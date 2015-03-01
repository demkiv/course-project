using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeanerySystem.Startup))]
namespace DeanerySystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

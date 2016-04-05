using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DeanerySystem.UI.Startup))]
namespace DeanerySystem.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
